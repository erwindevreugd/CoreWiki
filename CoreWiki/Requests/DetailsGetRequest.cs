using CoreWiki.Data.Models;
using MediatR;

namespace CoreWiki.Requests
{
	public class DetailsGetRequest : IRequest<Article>
    {
	    public DetailsGetRequest(string slug)
	    {
		    Slug = slug;
	    }

		public string Slug { get; set; }
    }
}
