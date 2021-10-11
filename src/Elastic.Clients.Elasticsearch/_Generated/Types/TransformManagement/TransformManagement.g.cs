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

using System;
using System.Text.Json.Serialization;

#nullable restore
namespace Elastic.Clients.Elasticsearch.TransformManagement
{
	public interface IPivotGroupByContainerVariant
	{
		void WrapInContainer(IPivotGroupByContainer container);
	}

	[ConvertAs(typeof(PivotGroupByContainer))]
	public partial interface IPivotGroupByContainer
	{
		[JsonInclude]
		[JsonPropertyName("date_histogram")]
		Aggregations.IDateHistogramAggregation? DateHistogram { get; set; }

		[JsonInclude]
		[JsonPropertyName("geotile_grid")]
		Aggregations.IGeoTileGridAggregation? GeotileGrid { get; set; }

		[JsonInclude]
		[JsonPropertyName("histogram")]
		Aggregations.IHistogramAggregation? Histogram { get; set; }

		[JsonInclude]
		[JsonPropertyName("terms")]
		Aggregations.ITermsAggregation? Terms { get; set; }
	}

	public partial class PivotGroupByContainer : TransformManagement.IPivotGroupByContainer
	{
		public PivotGroupByContainer(IPivotGroupByContainerVariant query)
		{
			if (query == null)
				return;
			query.WrapInContainer(this);
		}

		private Aggregations.IDateHistogramAggregation? _dateHistogram;
		private Aggregations.IGeoTileGridAggregation? _geotileGrid;
		private Aggregations.IHistogramAggregation? _histogram;
		private Aggregations.ITermsAggregation? _terms;
		Aggregations.IDateHistogramAggregation? IPivotGroupByContainer.DateHistogram { get => _dateHistogram; set => _dateHistogram = Set(value); }

		Aggregations.IGeoTileGridAggregation? IPivotGroupByContainer.GeotileGrid { get => _geotileGrid; set => _geotileGrid = Set(value); }

		Aggregations.IHistogramAggregation? IPivotGroupByContainer.Histogram { get => _histogram; set => _histogram = Set(value); }

		Aggregations.ITermsAggregation? IPivotGroupByContainer.Terms { get => _terms; set => _terms = Set(value); }

		[JsonIgnore]
		internal IPivotGroupByContainerVariant ContainedVariant { get; set; }

		private T Set<T>(T value)
			where T : IPivotGroupByContainerVariant
		{
			if (ContainedVariant != null)
				throw new Exception("TODO");
			ContainedVariant = value;
			return value;
		}
	}

	public partial class PivotGroupByContainerDescriptor : IPivotGroupByContainer
	{
		Aggregations.IDateHistogramAggregation? IPivotGroupByContainer.DateHistogram { get; set; }

		Aggregations.IGeoTileGridAggregation? IPivotGroupByContainer.GeotileGrid { get; set; }

		Aggregations.IHistogramAggregation? IPivotGroupByContainer.Histogram { get; set; }

		Aggregations.ITermsAggregation? IPivotGroupByContainer.Terms { get; set; }
	}
}