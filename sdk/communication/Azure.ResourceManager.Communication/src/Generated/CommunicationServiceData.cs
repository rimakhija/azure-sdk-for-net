// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Communication.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Communication
{
    /// <summary> A class representing the CommunicationService data model. </summary>
    public partial class CommunicationServiceData : Resource
    {
        /// <summary> Initializes a new instance of CommunicationServiceData. </summary>
        public CommunicationServiceData()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of CommunicationServiceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="systemData"> Metadata pertaining to creation and last modification of the resource. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <param name="hostName"> FQDN of the CommunicationService instance. </param>
        /// <param name="dataLocation"> The location where the communication service stores its data at rest. </param>
        /// <param name="notificationHubId"> Resource ID of an Azure Notification Hub linked to this resource. </param>
        /// <param name="version"> Version of the CommunicationService resource. Probably you need the same or higher version of client SDKs. </param>
        /// <param name="immutableResourceId"> The immutable resource Id of the communication service. </param>
        /// <param name="location"> The Azure location where the CommunicationService is running. </param>
        /// <param name="tags"> Tags of the service which is a list of key value pairs that describe the resource. </param>
        internal CommunicationServiceData(ResourceIdentifier id, string name, ResourceType type, SystemData systemData, ProvisioningState? provisioningState, string hostName, string dataLocation, string notificationHubId, string version, string immutableResourceId, string location, IDictionary<string, string> tags) : base(id, name, type)
        {
            SystemData = systemData;
            ProvisioningState = provisioningState;
            HostName = hostName;
            DataLocation = dataLocation;
            NotificationHubId = notificationHubId;
            Version = version;
            ImmutableResourceId = immutableResourceId;
            Location = location;
            Tags = tags;
        }

        /// <summary> Metadata pertaining to creation and last modification of the resource. </summary>
        public SystemData SystemData { get; }
        /// <summary> Provisioning state of the resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
        /// <summary> FQDN of the CommunicationService instance. </summary>
        public string HostName { get; }
        /// <summary> The location where the communication service stores its data at rest. </summary>
        public string DataLocation { get; set; }
        /// <summary> Resource ID of an Azure Notification Hub linked to this resource. </summary>
        public string NotificationHubId { get; }
        /// <summary> Version of the CommunicationService resource. Probably you need the same or higher version of client SDKs. </summary>
        public string Version { get; }
        /// <summary> The immutable resource Id of the communication service. </summary>
        public string ImmutableResourceId { get; }
        /// <summary> The Azure location where the CommunicationService is running. </summary>
        public string Location { get; set; }
        /// <summary> Tags of the service which is a list of key value pairs that describe the resource. </summary>
        public IDictionary<string, string> Tags { get; }
    }
}
