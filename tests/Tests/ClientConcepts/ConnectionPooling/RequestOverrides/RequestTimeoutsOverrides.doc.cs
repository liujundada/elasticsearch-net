// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Threading.Tasks;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Elasticsearch.Net.VirtualizedCluster;
using Elasticsearch.Net.VirtualizedCluster.Audit;
using Tests.Framework;
using static Elastic.Transport.AuditEvent;

namespace Tests.ClientConcepts.ConnectionPooling.RequestOverrides
{
	public class RequestTimeoutsOverrides
	{
		/**[[request-timeout]]
		* === Request timeouts
		*
		* While you can specify Request time out globally you can override this per request too
		*/

		[U]
		public async Task RespectsRequestTimeoutOverride()
		{

			/** we set up a 10 node cluster with a global time out of 20 seconds.
			* Each call on a node takes 10 seconds. So we can only try this call on 2 nodes
			* before the max request time out kills the client call.
			*/
			var audit = new Auditor(() => VirtualClusterWith
				.Nodes(10)
				.ClientCalls(r => r.FailAlways().Takes(TimeSpan.FromSeconds(10)))
				.ClientCalls(r => r.OnPort(9209).SucceedAlways())
				.StaticConnectionPool()
				.Settings(s => s.DisablePing().RequestTimeout(TimeSpan.FromSeconds(20)))
			);

			audit = await audit.TraceCalls(
				new ClientCall {
					{ BadResponse, 9200 },
					{ BadResponse, 9201 },
					{ MaxTimeoutReached }
				},
				/**
				* On the second request we specify a request timeout override to 80 seconds
				* We should now see more nodes being tried.
				*/
				new ClientCall(r => r.RequestTimeout(TimeSpan.FromSeconds(80)))
				{
					{ BadResponse, 9203 },
					{ BadResponse, 9204 },
					{ BadResponse, 9205 },
					{ BadResponse, 9206 },
					{ BadResponse, 9207 },
					{ BadResponse, 9208 },
					{ HealthyResponse, 9209 },
				}
			);

		}

		/**[float]
		* === Connect timeouts
		*
		* Connect timeouts can be overridden on a per request basis.
		*
		* Whilst the underlying `WebRequest` in the case of Desktop CLR
		* and `HttpClient` in the case of Core CLR cannot distinguish between connect and retry timeouts,
		* we use a separate configuration value for ping requests to allow ping to be configured
		* independently.
		*/
		[U]
		public async Task RespectsConnectTimeoutOverride()
		{
			/** We set up a 10 node cluster with a global time out of 20 seconds.
			* Each call on a node takes 10 seconds. So we can only try this call on 2 nodes
			* before the max request time out kills the client call.
			*/
			var audit = new Auditor(() => VirtualClusterWith
				.Nodes(10)
				.Ping(p => p.SucceedAlways().Takes(TimeSpan.FromSeconds(20)))
				.ClientCalls(r => r.SucceedAlways())
				.StaticConnectionPool()
				.Settings(s => s.RequestTimeout(TimeSpan.FromSeconds(10)).PingTimeout(TimeSpan.FromSeconds(10)))
			);

			audit = await audit.TraceCalls(
				/**
				* The first call uses the configured global settings, request times out after 10 seconds and ping
				* calls always take 20, so we should see a single ping failure
				*/
				new ClientCall {
					{ PingFailure, 9200 },
					{ MaxTimeoutReached }
				},
				/**
				* On the second request we set a request ping timeout override of 2 seconds
				* We should now see more nodes being tried before the request timeout is hit.
				*/
				new ClientCall(r => r.PingTimeout(TimeSpan.FromSeconds(2)))
				{
					{ PingFailure, 9202 },
					{ PingFailure, 9203 },
					{ PingFailure, 9204 },
					{ PingFailure, 9205 },
					{ PingFailure, 9206 },
					{ MaxTimeoutReached }
				}
			);

		}
	}
}
