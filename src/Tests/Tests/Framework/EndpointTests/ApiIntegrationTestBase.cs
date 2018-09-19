﻿using System;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Elastic.Managed.Ephemeral;
using Elasticsearch.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using Nest;
using Tests.Core.Client;
using Tests.Core.Extensions;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;

namespace Tests.Framework
{
	public abstract class ApiIntegrationTestBase<TCluster, TResponse, TInterface, TDescriptor, TInitializer>
		: ApiTestBase<TCluster, TResponse, TInterface, TDescriptor, TInitializer>
		where TCluster : IEphemeralCluster<EphemeralClusterConfiguration>, INestTestCluster , new()
		where TResponse : class, IResponse
		where TDescriptor : class, TInterface
		where TInitializer : class, TInterface
		where TInterface : class
	{
		protected abstract int ExpectStatusCode { get; }
		protected abstract bool ExpectIsValid { get; }
		protected virtual void ExpectResponse(TResponse response) { }

		protected ApiIntegrationTestBase(TCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override TInitializer Initializer => Activator.CreateInstance<TInitializer>();

		protected override IElasticClient Client => this.Cluster.Client;

		[I] public async virtual Task HandlesStatusCode() =>
			await this.AssertOnAllResponses(r => r.ApiCall.HttpStatusCode.Should().Be(this.ExpectStatusCode));

		[I] public async virtual Task ReturnsExpectedIsValid() =>
			await this.AssertOnAllResponses(r => r.ShouldHaveExpectedIsValid(this.ExpectIsValid));

		[I] public async virtual Task ReturnsExpectedResponse() => await this.AssertOnAllResponses(ExpectResponse);

		protected override Task AssertOnAllResponses(Action<TResponse> assert)
		{
			if (!this.ExpectIsValid) return base.AssertOnAllResponses(assert);

			return base.AssertOnAllResponses((r) =>
			{
				if (TestClient.Configuration.RunIntegrationTests && !r.IsValid && r.ApiCall.OriginalException != null
					&& IsNotRequestExceptionType(r.ApiCall.OriginalException.GetType()))
				{
					ExceptionDispatchInfo.Capture(r.ApiCall.OriginalException).Throw();
					return;
				}

				using (var scope = new AssertionScope())
				{
					assert(r);
					var failures = scope.Discard();
					if (failures.Length <= 0) return;
					
					var failure = failures[0];
					scope.AddReportable("Failure", failure);
					scope.AddReportable("DebugInformation", r.DebugInformation);
					scope.FailWith( $@"{{Failure}}
Response Under Test:
{{DebugInformation}}");

				}
			});
		}

		private static bool IsNotRequestExceptionType(Type exceptionType)
		{
#if DOTNETCORE
			return exceptionType != typeof(System.Net.Http.HttpRequestException);
#else
			return exceptionType != typeof(WebException);
#endif
		}
	}
}