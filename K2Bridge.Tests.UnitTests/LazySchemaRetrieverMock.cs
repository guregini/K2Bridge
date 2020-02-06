﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

namespace Tests
{
    using System.Threading.Tasks;
    using K2Bridge.DAL;
    using K2Bridge.Models.Response.Metadata;
    using Microsoft.Extensions.Logging;
    using Moq;

    public static class LazySchemaRetrieverMock
    {
        public static ILazySchemaRetrieverFactory CreateMockSchemaRetriever()
        {
            var response = new FieldCapabilityResponse();
            response.AddField(
                new FieldCapabilityElement
                {
                    Name = "dayOfWeek",
                    Type = "string",
                });
            var responseTask = Task.FromResult(response);

            var mockDAL = new Mock<IKustoDataAccess>();
            mockDAL.Setup(kusto => kusto.GetFieldCapsAsync(It.IsNotNull<string>())).Returns(responseTask);

            var mockLogger = new Mock<ILogger<LazySchemaRetriever>>();
            return new LazySchemaRetrieverFactory(mockLogger.Object, mockDAL.Object);
        }

        public static ILazySchemaRetrieverFactory CreateMockNumericSchemaRetriever()
        {
            var response = new FieldCapabilityResponse();
            response.AddField(
                new FieldCapabilityElement
                {
                    Name = "dayOfWeek",
                    Type = "long",
                });
            var responseTask = Task.FromResult(response);

            var mockDAL = new Mock<IKustoDataAccess>();
            mockDAL.Setup(kusto => kusto.GetFieldCapsAsync(It.IsNotNull<string>())).Returns(responseTask);

            var mockLogger = new Mock<ILogger<LazySchemaRetriever>>();
            return new LazySchemaRetrieverFactory(mockLogger.Object, mockDAL.Object);
        }
    }
}