// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information.
//
// ███╗   ██╗ ██████╗ ████████╗██╗ ██████╗███████╗
// ████╗  ██║██╔═══██╗╚══██╔══╝██║██╔════╝██╔════╝
// ██╔██╗ ██║██║   ██║   ██║   ██║██║     █████╗
// ██║╚██╗██║██║   ██║   ██║   ██║██║     ██╔══╝
// ██║ ╚████║╚██████╔╝   ██║   ██║╚██████╗███████╗
// ╚═╝  ╚═══╝ ╚═════╝    ╚═╝   ╚═╝ ╚═════╝╚══════╝
// ------------------------------------------------
//
// This file is automatically generated.
// Please do not edit these files manually.
//
// ------------------------------------------------

using Elastic.Transport;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable restore
namespace Elastic.Clients.Elasticsearch.Cluster
{
	public class ClusterDeleteVotingConfigExclusionsRequestParameters : RequestParameters<ClusterDeleteVotingConfigExclusionsRequestParameters>
	{
		[JsonIgnore]
		public bool? WaitForRemoval { get => Q<bool?>("wait_for_removal"); set => Q("wait_for_removal", value); }
	}

	[InterfaceConverterAttribute(typeof(ClusterDeleteVotingConfigExclusionsRequestDescriptorConverter<ClusterDeleteVotingConfigExclusionsRequest>))]
	public partial interface IClusterDeleteVotingConfigExclusionsRequest : IRequest<ClusterDeleteVotingConfigExclusionsRequestParameters>
	{
	}

	public partial class ClusterDeleteVotingConfigExclusionsRequest : PlainRequestBase<ClusterDeleteVotingConfigExclusionsRequestParameters>, IClusterDeleteVotingConfigExclusionsRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.ClusterDeleteVotingConfigExclusions;
		protected override HttpMethod HttpMethod => HttpMethod.DELETE;
		protected override bool SupportsBody => false;
		[JsonIgnore]
		public bool? WaitForRemoval { get => Q<bool?>("wait_for_removal"); set => Q("wait_for_removal", value); }
	}

	public partial class ClusterDeleteVotingConfigExclusionsRequestDescriptor : RequestDescriptorBase<ClusterDeleteVotingConfigExclusionsRequestDescriptor, ClusterDeleteVotingConfigExclusionsRequestParameters, IClusterDeleteVotingConfigExclusionsRequest>, IClusterDeleteVotingConfigExclusionsRequest
	{
		///<summary>/_cluster/voting_config_exclusions</summary>
        public ClusterDeleteVotingConfigExclusionsRequestDescriptor() : base()
		{
		}

		internal override ApiUrls ApiUrls => ApiUrlsLookups.ClusterDeleteVotingConfigExclusions;
		protected override HttpMethod HttpMethod => HttpMethod.DELETE;
		protected override bool SupportsBody => false;
		public ClusterDeleteVotingConfigExclusionsRequestDescriptor WaitForRemoval(bool? waitForRemoval) => Qs("wait_for_removal", waitForRemoval);
	}

	public class ClusterDeleteVotingConfigExclusionsRequestDescriptorConverter<TReadAs> : JsonConverter<IClusterDeleteVotingConfigExclusionsRequest> where TReadAs : class, IClusterDeleteVotingConfigExclusionsRequest
	{
		public override IClusterDeleteVotingConfigExclusionsRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => JsonSerializer.Deserialize<TReadAs>(ref reader, options);
		public override void Write(Utf8JsonWriter writer, IClusterDeleteVotingConfigExclusionsRequest value, JsonSerializerOptions options)
		{
			writer.WriteStartObject();
			writer.WriteEndObject();
		}
	}
}