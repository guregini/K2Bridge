﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

namespace K2Bridge.Models.Request.Queries
{
    using K2Bridge.JsonConverters;
    using K2Bridge.Models.Request;
    using K2Bridge.Visitors;
    using Newtonsoft.Json;

    [JsonConverter(typeof(MatchPhraseClauseConverter))]
    internal class MatchPhraseClause : KustoQLBase, IVisitable, ILeafClause
    {
        public string FieldName { get; set; }

        public string Phrase { get; set; }

        /// <inheritdoc/>
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
