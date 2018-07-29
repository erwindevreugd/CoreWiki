using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CoreWiki.Extensibility.Common
{
	public abstract class ExtensibilityManagerBase : IDisposable
	{
		public const string ModulesPath = "CoreWikiModules";
		protected List<ICoreWikiModule> Modules;
		private bool _disposed;

		protected ExtensibilityManagerBase(ICoreWikiModuleHost coreWikiModuleHost, ICoreWikiModuleLoader moduleLoader)
		{
			RegisterCoreWikiModules(coreWikiModuleHost, moduleLoader);
		}

		private void RegisterCoreWikiModules(ICoreWikiModuleHost coreWikiModuleHost, ICoreWikiModuleLoader moduleLoader)
		{
			var rootModulesPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			var modulesPath = Path.Combine(rootModulesPath, ModulesPath);

			Modules = moduleLoader.Load(rootModulesPath, modulesPath);
			foreach (var coreWikiModule in Modules)
			{
				coreWikiModule.Initialize(coreWikiModuleHost);
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && !_disposed)
			{
				_disposed = true;
				foreach (var coreWikiModule in Modules)
				{
					coreWikiModule.Dispose();
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
