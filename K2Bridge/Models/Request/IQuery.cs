﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

namespace K2Bridge.Models.Request
{
    using K2Bridge.JsonConverters;
    using Newtonsoft.Json;

    [JsonConverter(typeof(IQueryConverter))]
    internal interface IQuery
    {
    }
}
