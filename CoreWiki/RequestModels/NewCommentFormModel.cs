using System;

namespace CoreWiki.RequestModels
{
	public class NewCommentFormModel
    {
	    public int IdArticle { get; set; }
	    public string DisplayName { get; set; }
	    public string Email { get; set; }
	    public string Content { get; set; }
	    public Guid AuthorId { get; set; }
    }
}
