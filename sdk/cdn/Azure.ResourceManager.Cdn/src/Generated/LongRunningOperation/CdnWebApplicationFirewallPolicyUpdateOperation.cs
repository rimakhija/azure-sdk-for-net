// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Cdn;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> Update an existing CdnWebApplicationFirewallPolicy with the specified policy name under the specified subscription and resource group. </summary>
    public partial class CdnWebApplicationFirewallPolicyUpdateOperation : Operation<CdnWebApplicationFirewallPolicy>, IOperationSource<CdnWebApplicationFirewallPolicy>
    {
        private readonly OperationInternals<CdnWebApplicationFirewallPolicy> _operation;

        private readonly ArmResource _operationBase;

        /// <summary> Initializes a new instance of CdnWebApplicationFirewallPolicyUpdateOperation for mocking. </summary>
        protected CdnWebApplicationFirewallPolicyUpdateOperation()
        {
        }

        internal CdnWebApplicationFirewallPolicyUpdateOperation(ArmResource operationsBase, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<CdnWebApplicationFirewallPolicy>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "CdnWebApplicationFirewallPolicyUpdateOperation");
            _operationBase = operationsBase;
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override CdnWebApplicationFirewallPolicy Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<CdnWebApplicationFirewallPolicy>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<CdnWebApplicationFirewallPolicy>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        CdnWebApplicationFirewallPolicy IOperationSource<CdnWebApplicationFirewallPolicy>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = CdnWebApplicationFirewallPolicyData.DeserializeCdnWebApplicationFirewallPolicyData(document.RootElement);
            return new CdnWebApplicationFirewallPolicy(_operationBase, data);
        }

        async ValueTask<CdnWebApplicationFirewallPolicy> IOperationSource<CdnWebApplicationFirewallPolicy>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = CdnWebApplicationFirewallPolicyData.DeserializeCdnWebApplicationFirewallPolicyData(document.RootElement);
            return new CdnWebApplicationFirewallPolicy(_operationBase, data);
        }
    }
}
