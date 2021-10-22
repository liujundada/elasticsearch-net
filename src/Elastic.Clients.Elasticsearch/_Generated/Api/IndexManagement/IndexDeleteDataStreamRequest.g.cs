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

using Elastic.Clients.Elasticsearch.Experimental;
using Elastic.Transport;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable restore
namespace Elastic.Clients.Elasticsearch.IndexManagement
{
	public class IndexDeleteDataStreamRequestParameters : RequestParameters<IndexDeleteDataStreamRequestParameters>
	{
		[JsonIgnore]
		public Elastic.Clients.Elasticsearch.ExpandWildcards? ExpandWildcards { get => Q<Elastic.Clients.Elasticsearch.ExpandWildcards?>("expand_wildcards"); set => Q("expand_wildcards", value); }
	}

	public partial class IndexDeleteDataStreamRequest : PlainRequestBase<IndexDeleteDataStreamRequestParameters>
	{
		public IndexDeleteDataStreamRequest(Elastic.Clients.Elasticsearch.DataStreamNames name) : base(r => r.Required("name", name))
		{
		}

		internal override ApiUrls ApiUrls => ApiUrlsLookups.IndexManagementDeleteDataStream;
		protected override HttpMethod HttpMethod => HttpMethod.DELETE;
		protected override bool SupportsBody => false;
		[JsonIgnore]
		public Elastic.Clients.Elasticsearch.ExpandWildcards? ExpandWildcards { get => Q<Elastic.Clients.Elasticsearch.ExpandWildcards?>("expand_wildcards"); set => Q("expand_wildcards", value); }
	}

	[JsonConverter(typeof(IndexDeleteDataStreamRequestDescriptorConverter))]
	public partial class IndexDeleteDataStreamRequestDescriptor : RequestDescriptorBase<IndexDeleteDataStreamRequestDescriptor, IndexDeleteDataStreamRequestParameters>
	{
		public IndexDeleteDataStreamRequestDescriptor(Elastic.Clients.Elasticsearch.DataStreamNames name) : base(r => r.Required("name", name))
		{
		}

		internal override ApiUrls ApiUrls => ApiUrlsLookups.IndexManagementDeleteDataStream;
		protected override HttpMethod HttpMethod => HttpMethod.DELETE;
		protected override bool SupportsBody => false;
		public IndexDeleteDataStreamRequestDescriptor ExpandWildcards(Elastic.Clients.Elasticsearch.ExpandWildcards? expandWildcards) => Qs("expand_wildcards", expandWildcards);
	}

	internal sealed class IndexDeleteDataStreamRequestDescriptorConverter : JsonConverter<IndexDeleteDataStreamRequestDescriptor>
	{
		public override IndexDeleteDataStreamRequestDescriptor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotImplementedException();
		public override void Write(Utf8JsonWriter writer, IndexDeleteDataStreamRequestDescriptor value, JsonSerializerOptions options)
		{
			writer.WriteStartObject();
			writer.WriteEndObject();
		}
	}
}