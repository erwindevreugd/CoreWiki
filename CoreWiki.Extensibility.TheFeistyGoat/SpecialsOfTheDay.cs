using CoreWiki.Extensibility.Common;
using CoreWiki.Extensibility.Common.Events;
using System;
using System.Text;
using Microsoft.Extensions.Logging;

namespace CoreWiki.Extensibility.TheFeistyGoat
{
	public class SpecialsOfTheDay : ICoreWikiModule
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
			_logger = coreWikiModuleHost.LoggerFactory.CreateLogger(nameof(SpecialsOfTheDay));
			_logger.LogInformation("SpecialsOfTheDay CoreWikiModule Initialized");
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
			// get specials from a data store
			var specials = SpecialItem.GetSpecials();

			StringBuilder builder = new StringBuilder();
			builder.AppendLine();
			builder.AppendLine("------- The Feisty Goat :: daily specials -------");
			foreach (var item in specials)
				builder.AppendLine(string.Format("{0} - regular price {1:#.00}, today: {2:#.00}", item.Item, item.RegularPrice, item.SpecialPrice));

			e.Content += builder.ToString();
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
