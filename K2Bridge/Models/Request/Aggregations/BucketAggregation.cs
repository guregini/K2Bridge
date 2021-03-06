﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

namespace K2Bridge.Models.Request.Aggregations
{
    internal abstract class BucketAggregation : LeafAggregation
    {
        public string Metric { get; set; } = "count()";
    }
}
