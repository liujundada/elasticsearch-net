using System;
using System.Collections.Generic;
using System.IO;
using ApiGenerator.Configuration;
using ApiGenerator.Domain;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using RazorLight;
using RazorLight.Generation;
using RazorLight.Razor;
using ShellProgressBar;

namespace ApiGenerator.Generator.Razor
{
	public abstract class RazorGeneratorBase
	{
		private static readonly RazorLightEngine Engine = new RazorLightEngineBuilder()
			.UseProject(new FileSystemRazorProject(Path.GetFullPath(ViewLocations.Root)))
			.UseMemoryCachingProvider()
			.Build();

		protected void DoRazor<TModel>(TModel model, string viewLocation, string targetLocation, string cacheNameSuffix = null)
		{
			try
			{
				var name = GetType().Name + cacheNameSuffix;
				var sourceFileContents = File.ReadAllText(viewLocation);
				var generated = Engine.CompileRenderStringAsync(name, sourceFileContents,  model).GetAwaiter().GetResult();
				WriteFormattedCsharpFile(targetLocation, generated);
			}
			catch (TemplateGenerationException e)
			{
				foreach (var d in e.Diagnostics) Console.WriteLine(d.GetMessage());
				throw;
			}
		}

		protected void DoRazorDependantFiles<TModel>(
			ProgressBar pbar, IReadOnlyCollection<TModel> items, string viewLocation, 
			Func<TModel, string> identifier, Func<string, string> target)
		{
			using (var c = pbar.Spawn(items.Count, "Generating namespaces", new ProgressBarOptions { ForegroundColor = ConsoleColor.Yellow }))
			{
				foreach (var item in items)
				{
					var id = identifier(item);
					var targetLocation = target(id);
					DoRazor(item, viewLocation, targetLocation, id);
					c.Tick($"{Title}: {id}");
				}
			}
		}
		
		protected static void WriteFormattedCsharpFile(string path, string contents)
		{
			var tree = CSharpSyntaxTree.ParseText(contents);
			var root = tree.GetRoot().NormalizeWhitespace(indentation:"\t", "\n");
			contents = root.ToFullString();
			File.WriteAllText(path, contents);
		}

		public abstract string Title { get; }
		public abstract void Generate(RestApiSpec spec, ProgressBar progressBar);
	}
}