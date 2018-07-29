using CoreWiki.Extensibility.Common;
using CoreWiki.Extensibility.Common.Events;
using Microsoft.Extensions.Logging;
using System;

namespace CoreWiki.Extensibility.TheChapel
{
    public class ProfanityCheck : ICoreWikiModule
    {
        public ProfanityCheck()
        {
            _BadWords = GetProfanityWords();
        }

        void ICoreWikiModule.Initialize(ICoreWikiModuleHost coreWikiModuleHost)
        {
	        _coreWikiModuleHost = coreWikiModuleHost;
	        _coreWikiModuleHost.Events.PreCreateArticle += OnPreSubmitArticle;
	        _coreWikiModuleHost.Events.PostCreateArticle += OnPostSubmitArticle;
	        _coreWikiModuleHost.Events.PreEditArticle += OnPreEditArticle;
	        _coreWikiModuleHost.Events.PostEditArticle += OnPostEditArticle;
            _logger = coreWikiModuleHost.LoggerFactory.CreateLogger(nameof(ProfanityCheck));
            _logger.LogInformation("ProfanityCheck CoreWikiModule Initialized");
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
            e.Topic = RemoveProfanity(e.Topic);
            e.Content = RemoveProfanity(e.Content);
        }

        private void OnPostSubmitArticle(PostArticleCreateEventArgs e)
        {
            throw new NotImplementedException();
        }

        string[] _BadWords;
        private ILogger _logger;
	    private ICoreWikiModuleHost _coreWikiModuleHost;

	    string RemoveProfanity(string text)
        {
            string newText = text;

            foreach (string badWord in _BadWords)
                newText = newText.Replace(badWord, "[No Profanity]");

            return newText;
        }

        string[] GetProfanityWords()
        {
            return new string[]
            {
                 "filth", "flarn"
            };
        }

        public void Dispose()
        {
        }
    }
}
