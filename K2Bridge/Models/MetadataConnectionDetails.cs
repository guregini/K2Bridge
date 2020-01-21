// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

namespace K2Bridge.Models
{
    using System;
    using Microsoft.Extensions.Configuration;

    internal class MetadataConnectionDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataConnectionDetails"/> class.
        /// </summary>
        /// <param name="metadataEndpoint">URI for metadata Elasticsearch endpoint.</param>
        private MetadataConnectionDetails(string metadataEndpoint)
        {
            if (string.IsNullOrEmpty(metadataEndpoint))
            {
                throw new ArgumentException("URI for metadata Elasticsearch endpoint is required, for example http://127.0.0.1:8080");
            }

            MetadataEndpoint = metadataEndpoint;
        }

        public string MetadataEndpoint { get; private set; }

        public static MetadataConnectionDetails MakeFromConfiguration(IConfigurationRoot config) =>
            new MetadataConnectionDetails(
                config["metadataElasticAddress"]);
    }
}