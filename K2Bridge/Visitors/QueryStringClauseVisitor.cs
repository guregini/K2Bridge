﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace K2Bridge.Visitors
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using K2Bridge.Models.Request.Queries;

    internal partial class ElasticSearchDSLVisitor : IVisitor
    {
        public void Visit(QueryStringClause queryStringClause)
        {
            List<string> phraseList = this.Parse(queryStringClause.Phrase);
            if (phraseList != null)
            {
                foreach (var match in phraseList)
                {
                    if (match.Equals("or") || match.Equals("and"))
                    {
                        queryStringClause.KQL += $" {match} ";
                    }
                    else if (match.Equals("not"))
                    {
                        queryStringClause.KQL += $"{match} ";
                    }
                    else
                    {
                        queryStringClause.KQL += $"(* {KQLOperators.Contains} {match})";
                    }
                }
            }
        }

        private List<string> Parse(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
            {
                return null;
            }

            var regex = new Regex("\\s+AND\\s+|\\s+OR\\s+|\\s*NOT\\s+|\"[^\"]*\"|\\S+|\\s+");
            var matches = regex.Matches(phrase);
            return matches.Select(i => i.ToString()).Select(this.Translate).ToList();
        }

        private string Translate(string match)
        {
            if (match.All(c => c.Equals(' ')))
            {
                return "or";
            }

            var str = match.Trim(' ');
            if (str.Equals("AND") || str.Equals("OR") || str.Equals("NOT"))
            {
                return str.ToLower();
            }

            return this.ToQuotedString(str);
        }

        private string ToQuotedString(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || (str.StartsWith('"') && str.EndsWith('"')))
            {
                return str;
            }

            return $"\"{str}\"";
        }
    }
}