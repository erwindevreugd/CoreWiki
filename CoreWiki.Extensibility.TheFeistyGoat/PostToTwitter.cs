using CoreWiki.Extensibility.Common;
using CoreWiki.Extensibility.Common.Events;
using System;
using Microsoft.Extensions.Logging;

namespace CoreWiki.Extensibility.TheFeistyGoat
{
	public class PostToTwitter : ICoreWikiModule
	{
		private ICoreWikiModuleHost _coreWikiModuleHost;
		private ILogger _logger;

		public void Initialize(ICoreWikiModuleHost coreWikiModuleHost)
		{
			_coreWikiModuleHost = coreWikiModuleHost;
			_coreWikiModuleHost.Events.PreCreateArticle += OnPreSubmitArticle;
			_coreWikiModuleHost.Events.PostCreateArticle += OnPostSubmitArticle;
			_coreWikiModuleHost.Events.PreEditArticle += OnPreEditArticle;
			_coreWikiModuleHost.Events.PostEditArticle += OnPostEditArticle;
			_logger = coreWikiModuleHost.LoggerFactory.CreateLogger(nameof(PostToTwitter));
			_logger.LogInformation("PostToTwitter CoreWikiModule Initialized");
		}

		private void OnPostEditArticle(PostArticleEditEventArgs obj)
		{
			throw new NotImplementedException();
		}

		private void OnPreEditArticle(PreArticleEditEventArgs obj)
		{
			throw new NotImplementedException();
		}

		private void OnPreSubmitArticle(PreArticleCreateEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void OnPostSubmitArticle(PostArticleCreateEventArgs e)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
		}
	}
}
