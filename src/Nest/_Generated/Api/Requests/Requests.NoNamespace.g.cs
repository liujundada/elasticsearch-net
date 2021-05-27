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
// Run the following in the root of the repository:
//
// ------------------------------------------------

using System;
using System.Text.Json.Serialization;
using Elastic.Transport;
using System.Collections.Generic;

#nullable restore
namespace Nest
{
	[ConvertAs(typeof(IndexRequest<>))]
	public partial interface IIndexRequest<TDocument> : IRequest<IndexRequestParameters>
	{
	}

	public partial class IndexRequest<TDocument> : PlainRequestBase<IndexRequestParameters>, IIndexRequest<TDocument>
	{
		protected IIndexRequest<TDocument> Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceIndex;
		protected override HttpMethod HttpMethod => HttpMethod.PUT;
		protected override bool SupportsBody => true;
		protected override bool CanBeEmpty => false;
		protected override bool IsEmpty => false;
		///<summary>/{index}/_doc/{id}</summary>
        public IndexRequest(IndexName index, Id id) : base(r => r.Required("index", index).Optional("id", id))
		{
		}

		///<summary>/{index}/_doc</summary>
        public IndexRequest(IndexName index) : base(r => r.Required("index", index))
		{
		}

		public TDocument Document { get; set; }

		[JsonIgnore]
		public long? IfPrimaryTerm { get => Q<long?>("if_primary_term"); set => Q("if_primary_term", value); }

		[JsonIgnore]
		public SequenceNumber? IfSeqNo { get => Q<SequenceNumber?>("if_seq_no"); set => Q("if_seq_no", value); }

		[JsonIgnore]
		public OpType? OpType { get => Q<OpType?>("op_type"); set => Q("op_type", value); }

		[JsonIgnore]
		public string? Pipeline { get => Q<string?>("pipeline"); set => Q("pipeline", value); }

		[JsonIgnore]
		public Refresh? Refresh { get => Q<Refresh?>("refresh"); set => Q("refresh", value); }

		[JsonIgnore]
		public Routing? Routing { get => Q<Routing?>("routing"); set => Q("routing", value); }

		[JsonIgnore]
		public Time? Timeout { get => Q<Time?>("timeout"); set => Q("timeout", value); }

		[JsonIgnore]
		public VersionNumber? Version { get => Q<VersionNumber?>("version"); set => Q("version", value); }

		[JsonIgnore]
		public VersionType? VersionType { get => Q<VersionType?>("version_type"); set => Q("version_type", value); }

		[JsonIgnore]
		public WaitForActiveShards? WaitForActiveShards { get => Q<WaitForActiveShards?>("wait_for_active_shards"); set => Q("wait_for_active_shards", value); }

		[JsonIgnore]
		public bool? RequireAlias { get => Q<bool?>("require_alias"); set => Q("require_alias", value); }
	}

	[ConvertAs(typeof(PingRequest))]
	public partial interface IPingRequest : IRequest<PingRequestParameters>
	{
	}

	public partial class PingRequest : PlainRequestBase<PingRequestParameters>, IPingRequest
	{
		protected IPingRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespacePing;
		protected override HttpMethod HttpMethod => HttpMethod.HEAD;
		protected override bool SupportsBody => false;
		protected override bool CanBeEmpty => true;
		protected override bool IsEmpty => true;
		///<summary>/</summary>
        public PingRequest() : base()
		{
		}
	}

	[ConvertAs(typeof(SearchRequest))]
	public partial interface ISearchRequest : IRequest<SearchRequestParameters>
	{
	}

	public partial class SearchRequest : PlainRequestBase<SearchRequestParameters>, ISearchRequest
	{
		protected ISearchRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceSearch;
		protected override HttpMethod HttpMethod => HttpMethod.POST;
		protected override bool SupportsBody => true;
		protected override bool CanBeEmpty => true;
		protected override bool IsEmpty => Aggs is null && Aggregations is null && Collapse is null && Highlight is null && IndicesBoost is null && MinScore is null && PostFilter is null && Profile is null && Query is null && Rescore is null && ScriptFields is null && SearchAfter is null && Slice is null && Fields is null && Suggest is null && Pit is null && RuntimeMappings is null;
		///<summary>/_search</summary>
        public SearchRequest() : base()
		{
		}

		///<summary>/{index}/_search</summary>
        public SearchRequest(Indices index) : base(r => r.Optional("index", index))
		{
		}

		[JsonIgnore]
		public bool? AllowNoIndices { get => Q<bool?>("allow_no_indices"); set => Q("allow_no_indices", value); }

		[JsonIgnore]
		public bool? AllowPartialSearchResults { get => Q<bool?>("allow_partial_search_results"); set => Q("allow_partial_search_results", value); }

		[JsonIgnore]
		public string? Analyzer { get => Q<string?>("analyzer"); set => Q("analyzer", value); }

		[JsonIgnore]
		public bool? AnalyzeWildcard { get => Q<bool?>("analyze_wildcard"); set => Q("analyze_wildcard", value); }

		[JsonIgnore]
		public long? BatchedReduceSize { get => Q<long?>("batched_reduce_size"); set => Q("batched_reduce_size", value); }

		[JsonIgnore]
		public bool? CcsMinimizeRoundtrips { get => Q<bool?>("ccs_minimize_roundtrips"); set => Q("ccs_minimize_roundtrips", value); }

		[JsonIgnore]
		public DefaultOperator? DefaultOperator { get => Q<DefaultOperator?>("default_operator"); set => Q("default_operator", value); }

		[JsonIgnore]
		public string? Df { get => Q<string?>("df"); set => Q("df", value); }

		[JsonIgnore]
		public Fields? DocvalueFields { get => Q<Fields?>("docvalue_fields"); set => Q("docvalue_fields", value); }

		[JsonIgnore]
		public ExpandWildcards? ExpandWildcards { get => Q<ExpandWildcards?>("expand_wildcards"); set => Q("expand_wildcards", value); }

		[JsonIgnore]
		public bool? Explain { get => Q<bool?>("explain"); set => Q("explain", value); }

		[JsonIgnore]
		public bool? IgnoreThrottled { get => Q<bool?>("ignore_throttled"); set => Q("ignore_throttled", value); }

		[JsonIgnore]
		public bool? IgnoreUnavailable { get => Q<bool?>("ignore_unavailable"); set => Q("ignore_unavailable", value); }

		[JsonIgnore]
		public bool? Lenient { get => Q<bool?>("lenient"); set => Q("lenient", value); }

		[JsonIgnore]
		public long? MaxConcurrentShardRequests { get => Q<long?>("max_concurrent_shard_requests"); set => Q("max_concurrent_shard_requests", value); }

		[JsonIgnore]
		public VersionString? MinCompatibleShardNode { get => Q<VersionString?>("min_compatible_shard_node"); set => Q("min_compatible_shard_node", value); }

		[JsonIgnore]
		public string? Preference { get => Q<string?>("preference"); set => Q("preference", value); }

		[JsonIgnore]
		public long? PreFilterShardSize { get => Q<long?>("pre_filter_shard_size"); set => Q("pre_filter_shard_size", value); }

		[JsonIgnore]
		public bool? RequestCache { get => Q<bool?>("request_cache"); set => Q("request_cache", value); }

		[JsonIgnore]
		public Routing? Routing { get => Q<Routing?>("routing"); set => Q("routing", value); }

		[JsonIgnore]
		public Time? Scroll { get => Q<Time?>("scroll"); set => Q("scroll", value); }

		[JsonIgnore]
		public SearchType? SearchType { get => Q<SearchType?>("search_type"); set => Q("search_type", value); }

		[JsonIgnore]
		public string[]? Stats { get => Q<string[]?>("stats"); set => Q("stats", value); }

		[JsonIgnore]
		public Fields? StoredFields { get => Q<Fields?>("stored_fields"); set => Q("stored_fields", value); }

		[JsonIgnore]
		public Field? SuggestField { get => Q<Field?>("suggest_field"); set => Q("suggest_field", value); }

		[JsonIgnore]
		public SuggestMode? SuggestMode { get => Q<SuggestMode?>("suggest_mode"); set => Q("suggest_mode", value); }

		[JsonIgnore]
		public long? SuggestSize { get => Q<long?>("suggest_size"); set => Q("suggest_size", value); }

		[JsonIgnore]
		public string? SuggestText { get => Q<string?>("suggest_text"); set => Q("suggest_text", value); }

		[JsonIgnore]
		public long? TerminateAfter { get => Q<long?>("terminate_after"); set => Q("terminate_after", value); }

		[JsonIgnore]
		public Time? Timeout { get => Q<Time?>("timeout"); set => Q("timeout", value); }

		[JsonIgnore]
		public Union<bool, int>? TrackTotalHits { get => Q<Union<bool, int>?>("track_total_hits"); set => Q("track_total_hits", value); }

		[JsonIgnore]
		public bool? TrackScores { get => Q<bool?>("track_scores"); set => Q("track_scores", value); }

		[JsonIgnore]
		public bool? TypedKeys { get => Q<bool?>("typed_keys"); set => Q("typed_keys", value); }

		[JsonIgnore]
		public bool? RestTotalHitsAsInt { get => Q<bool?>("rest_total_hits_as_int"); set => Q("rest_total_hits_as_int", value); }

		[JsonIgnore]
		public bool? Version { get => Q<bool?>("version"); set => Q("version", value); }

		[JsonIgnore]
		public Union<bool, Fields>? Source { get => Q<Union<bool, Fields>?>("_source"); set => Q("_source", value); }

		[JsonIgnore]
		public Fields? SourceExcludes { get => Q<Fields?>("_source_excludes"); set => Q("_source_excludes", value); }

		[JsonIgnore]
		public Fields? SourceIncludes { get => Q<Fields?>("_source_includes"); set => Q("_source_includes", value); }

		[JsonIgnore]
		public bool? SeqNoPrimaryTerm { get => Q<bool?>("seq_no_primary_term"); set => Q("seq_no_primary_term", value); }

		[JsonIgnore]
		public string? QueryLuceneSyntax { get => Q<string?>("q"); set => Q("q", value); }

		[JsonIgnore]
		public int? Size { get => Q<int?>("size"); set => Q("size", value); }

		[JsonIgnore]
		public int? From { get => Q<int?>("from"); set => Q("from", value); }

		[JsonPropertyName("aggs")]
		public Dictionary<string, AggregationContainer>? Aggs
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}

		[JsonPropertyName("aggregations")]
		public Dictionary<string, AggregationContainer>? Aggregations
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}

		[JsonPropertyName("collapse")]
		public FieldCollapse? Collapse
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}

		[JsonPropertyName("highlight")]
		public Highlight? Highlight
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}

		[JsonPropertyName("indices_boost")]
		public IReadOnlyCollection<Dictionary<IndexName, double>>? IndicesBoost
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}

		[JsonPropertyName("min_score")]
		public double? MinScore
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}

		[JsonPropertyName("post_filter")]
		public QueryContainer? PostFilter
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}

		[JsonPropertyName("profile")]
		public bool? Profile
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}

		[JsonPropertyName("query")]
		public QueryContainer? Query
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}

		[JsonPropertyName("rescore")]
		public Union<Rescore, IReadOnlyCollection<Rescore>>? Rescore
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}

		[JsonPropertyName("script_fields")]
		public Dictionary<string, ScriptField>? ScriptFields
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}

		[JsonPropertyName("search_after")]
		public IReadOnlyCollection<Union<int, string>>? SearchAfter
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}

		[JsonPropertyName("slice")]
		public SlicedScroll? Slice
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}

		[JsonPropertyName("fields")]
		public IReadOnlyCollection<Union<Field, DateField>>? Fields
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}

		[JsonPropertyName("suggest")]
		public Union<SuggestContainer, Dictionary<string, SuggestContainer>>? Suggest
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}

		[JsonPropertyName("pit")]
		public PointInTimeReference? Pit
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}

		[JsonPropertyName("runtime_mappings")]
		public RuntimeFields? RuntimeMappings
		{
			get;
#if NET5_0
			init;
#else
			internal set;
#endif
		}
	}
}
