using System;
using MediatR;

namespace CoreWiki.Requests
{
	public class DetailsPostRequest : IRequest<bool>
    {
	    public DetailsPostRequest(int articleId, string displayName, string email, string content, Guid authorId)
	    {
		    ArticleId = articleId;
		    DisplayName = displayName;
		    Email = email;
		    Content = content;
		    AuthorId = authorId;
	    }

		public int ArticleId { get; set; }
		public string DisplayName { get; set; }
		public string Email { get; set; }
		public string Content { get; set; }
	    public Guid AuthorId { get; set; }
    }
}
