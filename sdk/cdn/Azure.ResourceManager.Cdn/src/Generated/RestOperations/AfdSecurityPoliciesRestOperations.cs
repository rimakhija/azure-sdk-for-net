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
using Azure.ResourceManager;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Cdn
{
    internal partial class AfdSecurityPoliciesRestOperations
    {
        private Uri endpoint;
        private string apiVersion;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;
        private readonly string _userAgent;

        /// <summary> Initializes a new instance of AfdSecurityPoliciesRestOperations. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="options"> The client options used to construct the current client. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public AfdSecurityPoliciesRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, ArmClientOptions options, Uri endpoint = null, string apiVersion = default)
        {
            this.endpoint = endpoint ?? new Uri("https://management.azure.com");
            this.apiVersion = apiVersion ?? "2020-09-01";
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _userAgent = HttpMessageUtilities.GetUserAgentName(this, options);
        }

        internal HttpMessage CreateListByProfileRequest(string subscriptionId, string resourceGroupName, string profileName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Cdn/profiles/", false);
            uri.AppendPath(profileName, true);
            uri.AppendPath("/securityPolicies", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        /// <summary> Lists security policies associated with the profile. </summary>
        /// <param name="subscriptionId"> Azure Subscription ID. </param>
        /// <param name="resourceGroupName"> Name of the Resource group within the Azure subscription. </param>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, or <paramref name="profileName"/> is null. </exception>
        public async Task<Response<SecurityPolicyListResult>> ListByProfileAsync(string subscriptionId, string resourceGroupName, string profileName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (profileName == null)
            {
                throw new ArgumentNullException(nameof(profileName));
            }

            using var message = CreateListByProfileRequest(subscriptionId, resourceGroupName, profileName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SecurityPolicyListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SecurityPolicyListResult.DeserializeSecurityPolicyListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Lists security policies associated with the profile. </summary>
        /// <param name="subscriptionId"> Azure Subscription ID. </param>
        /// <param name="resourceGroupName"> Name of the Resource group within the Azure subscription. </param>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, or <paramref name="profileName"/> is null. </exception>
        public Response<SecurityPolicyListResult> ListByProfile(string subscriptionId, string resourceGroupName, string profileName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (profileName == null)
            {
                throw new ArgumentNullException(nameof(profileName));
            }

            using var message = CreateListByProfileRequest(subscriptionId, resourceGroupName, profileName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SecurityPolicyListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SecurityPolicyListResult.DeserializeSecurityPolicyListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest(string subscriptionId, string resourceGroupName, string profileName, string securityPolicyName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Cdn/profiles/", false);
            uri.AppendPath(profileName, true);
            uri.AppendPath("/securityPolicies/", false);
            uri.AppendPath(securityPolicyName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        /// <summary> Gets an existing security policy within a profile. </summary>
        /// <param name="subscriptionId"> Azure Subscription ID. </param>
        /// <param name="resourceGroupName"> Name of the Resource group within the Azure subscription. </param>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="securityPolicyName"> Name of the security policy under the profile. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="profileName"/>, or <paramref name="securityPolicyName"/> is null. </exception>
        public async Task<Response<AfdSecurityPolicyData>> GetAsync(string subscriptionId, string resourceGroupName, string profileName, string securityPolicyName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (profileName == null)
            {
                throw new ArgumentNullException(nameof(profileName));
            }
            if (securityPolicyName == null)
            {
                throw new ArgumentNullException(nameof(securityPolicyName));
            }

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, profileName, securityPolicyName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AfdSecurityPolicyData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AfdSecurityPolicyData.DeserializeAfdSecurityPolicyData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((AfdSecurityPolicyData)null, message.Response);
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Gets an existing security policy within a profile. </summary>
        /// <param name="subscriptionId"> Azure Subscription ID. </param>
        /// <param name="resourceGroupName"> Name of the Resource group within the Azure subscription. </param>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="securityPolicyName"> Name of the security policy under the profile. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="profileName"/>, or <paramref name="securityPolicyName"/> is null. </exception>
        public Response<AfdSecurityPolicyData> Get(string subscriptionId, string resourceGroupName, string profileName, string securityPolicyName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (profileName == null)
            {
                throw new ArgumentNullException(nameof(profileName));
            }
            if (securityPolicyName == null)
            {
                throw new ArgumentNullException(nameof(securityPolicyName));
            }

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, profileName, securityPolicyName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AfdSecurityPolicyData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AfdSecurityPolicyData.DeserializeAfdSecurityPolicyData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((AfdSecurityPolicyData)null, message.Response);
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCreateRequest(string subscriptionId, string resourceGroupName, string profileName, string securityPolicyName, AfdSecurityPolicyData securityPolicy)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Cdn/profiles/", false);
            uri.AppendPath(profileName, true);
            uri.AppendPath("/securityPolicies/", false);
            uri.AppendPath(securityPolicyName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(securityPolicy);
            request.Content = content;
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        /// <summary> Creates a new security policy within the specified profile. </summary>
        /// <param name="subscriptionId"> Azure Subscription ID. </param>
        /// <param name="resourceGroupName"> Name of the Resource group within the Azure subscription. </param>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="securityPolicyName"> Name of the security policy under the profile. </param>
        /// <param name="securityPolicy"> The security policy properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="profileName"/>, <paramref name="securityPolicyName"/>, or <paramref name="securityPolicy"/> is null. </exception>
        public async Task<Response> CreateAsync(string subscriptionId, string resourceGroupName, string profileName, string securityPolicyName, AfdSecurityPolicyData securityPolicy, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (profileName == null)
            {
                throw new ArgumentNullException(nameof(profileName));
            }
            if (securityPolicyName == null)
            {
                throw new ArgumentNullException(nameof(securityPolicyName));
            }
            if (securityPolicy == null)
            {
                throw new ArgumentNullException(nameof(securityPolicy));
            }

            using var message = CreateCreateRequest(subscriptionId, resourceGroupName, profileName, securityPolicyName, securityPolicy);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                case 202:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Creates a new security policy within the specified profile. </summary>
        /// <param name="subscriptionId"> Azure Subscription ID. </param>
        /// <param name="resourceGroupName"> Name of the Resource group within the Azure subscription. </param>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="securityPolicyName"> Name of the security policy under the profile. </param>
        /// <param name="securityPolicy"> The security policy properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="profileName"/>, <paramref name="securityPolicyName"/>, or <paramref name="securityPolicy"/> is null. </exception>
        public Response Create(string subscriptionId, string resourceGroupName, string profileName, string securityPolicyName, AfdSecurityPolicyData securityPolicy, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (profileName == null)
            {
                throw new ArgumentNullException(nameof(profileName));
            }
            if (securityPolicyName == null)
            {
                throw new ArgumentNullException(nameof(securityPolicyName));
            }
            if (securityPolicy == null)
            {
                throw new ArgumentNullException(nameof(securityPolicy));
            }

            using var message = CreateCreateRequest(subscriptionId, resourceGroupName, profileName, securityPolicyName, securityPolicy);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                case 202:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePatchRequest(string subscriptionId, string resourceGroupName, string profileName, string securityPolicyName, SecurityPolicyProperties securityPolicyProperties)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Cdn/profiles/", false);
            uri.AppendPath(profileName, true);
            uri.AppendPath("/securityPolicies/", false);
            uri.AppendPath(securityPolicyName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(securityPolicyProperties);
            request.Content = content;
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        /// <summary> Updates an existing Secret within a profile. </summary>
        /// <param name="subscriptionId"> Azure Subscription ID. </param>
        /// <param name="resourceGroupName"> Name of the Resource group within the Azure subscription. </param>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="securityPolicyName"> Name of the security policy under the profile. </param>
        /// <param name="securityPolicyProperties"> Security policy update properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="profileName"/>, <paramref name="securityPolicyName"/>, or <paramref name="securityPolicyProperties"/> is null. </exception>
        public async Task<Response> PatchAsync(string subscriptionId, string resourceGroupName, string profileName, string securityPolicyName, SecurityPolicyProperties securityPolicyProperties, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (profileName == null)
            {
                throw new ArgumentNullException(nameof(profileName));
            }
            if (securityPolicyName == null)
            {
                throw new ArgumentNullException(nameof(securityPolicyName));
            }
            if (securityPolicyProperties == null)
            {
                throw new ArgumentNullException(nameof(securityPolicyProperties));
            }

            using var message = CreatePatchRequest(subscriptionId, resourceGroupName, profileName, securityPolicyName, securityPolicyProperties);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Updates an existing Secret within a profile. </summary>
        /// <param name="subscriptionId"> Azure Subscription ID. </param>
        /// <param name="resourceGroupName"> Name of the Resource group within the Azure subscription. </param>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="securityPolicyName"> Name of the security policy under the profile. </param>
        /// <param name="securityPolicyProperties"> Security policy update properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="profileName"/>, <paramref name="securityPolicyName"/>, or <paramref name="securityPolicyProperties"/> is null. </exception>
        public Response Patch(string subscriptionId, string resourceGroupName, string profileName, string securityPolicyName, SecurityPolicyProperties securityPolicyProperties, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (profileName == null)
            {
                throw new ArgumentNullException(nameof(profileName));
            }
            if (securityPolicyName == null)
            {
                throw new ArgumentNullException(nameof(securityPolicyName));
            }
            if (securityPolicyProperties == null)
            {
                throw new ArgumentNullException(nameof(securityPolicyProperties));
            }

            using var message = CreatePatchRequest(subscriptionId, resourceGroupName, profileName, securityPolicyName, securityPolicyProperties);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteRequest(string subscriptionId, string resourceGroupName, string profileName, string securityPolicyName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Cdn/profiles/", false);
            uri.AppendPath(profileName, true);
            uri.AppendPath("/securityPolicies/", false);
            uri.AppendPath(securityPolicyName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        /// <summary> Deletes an existing security policy within profile. </summary>
        /// <param name="subscriptionId"> Azure Subscription ID. </param>
        /// <param name="resourceGroupName"> Name of the Resource group within the Azure subscription. </param>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="securityPolicyName"> Name of the Secret under the profile. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="profileName"/>, or <paramref name="securityPolicyName"/> is null. </exception>
        public async Task<Response> DeleteAsync(string subscriptionId, string resourceGroupName, string profileName, string securityPolicyName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (profileName == null)
            {
                throw new ArgumentNullException(nameof(profileName));
            }
            if (securityPolicyName == null)
            {
                throw new ArgumentNullException(nameof(securityPolicyName));
            }

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, profileName, securityPolicyName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Deletes an existing security policy within profile. </summary>
        /// <param name="subscriptionId"> Azure Subscription ID. </param>
        /// <param name="resourceGroupName"> Name of the Resource group within the Azure subscription. </param>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="securityPolicyName"> Name of the Secret under the profile. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="profileName"/>, or <paramref name="securityPolicyName"/> is null. </exception>
        public Response Delete(string subscriptionId, string resourceGroupName, string profileName, string securityPolicyName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (profileName == null)
            {
                throw new ArgumentNullException(nameof(profileName));
            }
            if (securityPolicyName == null)
            {
                throw new ArgumentNullException(nameof(securityPolicyName));
            }

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, profileName, securityPolicyName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListByProfileNextPageRequest(string nextLink, string subscriptionId, string resourceGroupName, string profileName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        /// <summary> Lists security policies associated with the profile. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Azure Subscription ID. </param>
        /// <param name="resourceGroupName"> Name of the Resource group within the Azure subscription. </param>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, or <paramref name="profileName"/> is null. </exception>
        public async Task<Response<SecurityPolicyListResult>> ListByProfileNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string profileName, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (profileName == null)
            {
                throw new ArgumentNullException(nameof(profileName));
            }

            using var message = CreateListByProfileNextPageRequest(nextLink, subscriptionId, resourceGroupName, profileName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SecurityPolicyListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SecurityPolicyListResult.DeserializeSecurityPolicyListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Lists security policies associated with the profile. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Azure Subscription ID. </param>
        /// <param name="resourceGroupName"> Name of the Resource group within the Azure subscription. </param>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, or <paramref name="profileName"/> is null. </exception>
        public Response<SecurityPolicyListResult> ListByProfileNextPage(string nextLink, string subscriptionId, string resourceGroupName, string profileName, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (profileName == null)
            {
                throw new ArgumentNullException(nameof(profileName));
            }

            using var message = CreateListByProfileNextPageRequest(nextLink, subscriptionId, resourceGroupName, profileName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SecurityPolicyListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SecurityPolicyListResult.DeserializeSecurityPolicyListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
