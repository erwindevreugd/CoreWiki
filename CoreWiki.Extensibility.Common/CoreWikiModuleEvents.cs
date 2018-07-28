﻿using System;
using CoreWiki.Extensibility.Common.Events;

namespace CoreWiki.Extensibility.Common
{
    public class CoreWikiModuleEvents : ICoreWikiModuleEvents
    {
        /// <summary>
        /// Raises an event in all registered CoreWikiModules before a new user is registered.
        /// </summary>
        public Action<PreRegisterUserEventArgs> PreRegisterUser { get; set; }

        /// <summary>
        /// Raises an event in all registered CoreWikiModules after a new user is registered.
        /// </summary>
        public Action<PostRegisterUserEventArgs> PostRegisterUser { get; set; }

        /// <summary>
        /// Raises an event in all registered CoreWikiModules before an article is created.
        /// </summary>
        public Action<PreArticleCreateEventArgs> PreCreateArticle { get; set; }

        /// <summary>
        /// Raises an event in all registered CoreWikiModules after an article was created.
        /// </summary>
        public Action<PostArticleCreateEventArgs> PostCreateArticle { get; set; }

        /// <summary>
        /// Raises an event in all registered CoreWikiModules before an article is created.
        /// </summary>
        public Action<PreArticleEditEventArgs> PreEditArticle { get; set; }

        /// <summary>
        /// Raises an event in all registered CoreWikiModules after an article was edited.
        /// </summary>
        public Action<PostArticleEditEventArgs> PostEditArticle { get; set; }

        /// <summary>
        /// Raises an event in all registered CoreWikiModules before a comment is created.
        /// </summary>
        public Action<PreCommentCreateEventArgs> PreCreateComment { get; set; }

        /// <summary>
        /// Raises an event in all registered CoreWikiModules after a comment was created.
        /// </summary>
        public Action<PostCommentCreateEventArgs> PostCreateComment { get; set; }
    }
}
