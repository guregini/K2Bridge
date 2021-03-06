﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

namespace K2Bridge.Models.Request.Aggregations
{
    using System.Collections.Generic;
    using K2Bridge.JsonConverters;
    using K2Bridge.Models.Request;
    using K2Bridge.Visitors;
    using Newtonsoft.Json;

    [JsonConverter(typeof(AggregationConverter))]
    internal class Aggregation : KustoQLBase, IVisitable
    {
        public LeafAggregation PrimaryAggregation { get; set; }

        public Dictionary<string, Aggregation> SubAggregations { get; set; }

        /// <inheritdoc/>
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
