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
using System.Collections.Generic;
using OneOf;
using Elastic.Transport;

#nullable restore
namespace Elastic.Clients.Elasticsearch
{
	public partial class ByteSize : Union<long, string>
	{
		public ByteSize(long item) : base(item)
		{
		}

		public ByteSize(string item) : base(item)
		{
		}
	}

	public partial class DataStreamNames : IUrlParameter
	{
		private readonly List<DataStreamName> _dataStreamNameList = new();
	}

	public partial class EpochMillis : Union<string, long>
	{
		public EpochMillis(string item) : base(item)
		{
		}

		public EpochMillis(long item) : base(item)
		{
		}
	}

	public partial class ExpandWildcards : Union<IReadOnlyCollection<Elastic.Clients.Elasticsearch.ExpandWildcardOptions>, string>
	{
		public ExpandWildcards(IReadOnlyCollection<Elastic.Clients.Elasticsearch.ExpandWildcardOptions> item) : base(item)
		{
		}

		public ExpandWildcards(string item) : base(item)
		{
		}
	}

	public partial class Fields : IUrlParameter
	{
		private readonly List<Field> _fieldList = new();
	}

	public partial class Fuzziness : Union<string, int>
	{
		public Fuzziness(string item) : base(item)
		{
		}

		public Fuzziness(int item) : base(item)
		{
		}
	}

	public partial class Ids : IUrlParameter
	{
		private readonly List<Id> _idList = new();
	}

	public partial class Indices : IUrlParameter
	{
		private readonly List<IndexName> _indexNameList = new();
	}

	public partial class Metrics : IUrlParameter
	{
		private readonly List<string> _stringList = new();
	}

	public partial class MinimumShouldMatch : Union<int, string>
	{
		public MinimumShouldMatch(int item) : base(item)
		{
		}

		public MinimumShouldMatch(string item) : base(item)
		{
		}
	}

	public partial class Names : IUrlParameter
	{
		private readonly List<Name> _nameList = new();
	}

	public partial class NodeIds : IUrlParameter
	{
		private readonly List<NodeId> _nodeIdList = new();
	}

	public partial class Percentage : Union<string, float>
	{
		public Percentage(string item) : base(item)
		{
		}

		public Percentage(float item) : base(item)
		{
		}
	}

	public partial class Refresh : Union<bool, Elastic.Clients.Elasticsearch.RefreshOptions>
	{
		public Refresh(bool item) : base(item)
		{
		}

		public Refresh(Elastic.Clients.Elasticsearch.RefreshOptions item) : base(item)
		{
		}
	}

	public partial class Script
	{
	}

	public partial class TaskId : Union<string, int>, IUrlParameter
	{
		public TaskId(string item) : base(item)
		{
		}

		public TaskId(int item) : base(item)
		{
		}

		public string GetString(ITransportConfiguration settings) =>  string . Empty ;
	}

	public partial class Time : Union<string, int>
	{
		public Time(string item) : base(item)
		{
		}

		public Time(int item) : base(item)
		{
		}
	}

	public partial class WaitForActiveShards : Union<int, Elastic.Clients.Elasticsearch.WaitForActiveShardOptions>
	{
		public WaitForActiveShards(int item) : base(item)
		{
		}

		public WaitForActiveShards(Elastic.Clients.Elasticsearch.WaitForActiveShardOptions item) : base(item)
		{
		}
	}
}