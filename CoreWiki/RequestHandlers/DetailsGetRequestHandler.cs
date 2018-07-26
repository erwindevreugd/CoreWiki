using CoreWiki.Data;
using CoreWiki.Data.Data.Interfaces;
using CoreWiki.Data.Models;
using CoreWiki.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CoreWiki.RequestHandlers
{
	public class DetailsGetRequestHandler : IRequestHandler<DetailsGetRequest, Article>
    {
	    private readonly IArticleRepository _articleRepository;
		private readonly ISlugHistoryRepository _slugHistoryRepository;

		public DetailsGetRequestHandler(IArticleRepository articleRepository, ISlugHistoryRepository slugHistoryRepository)
	    {
		    _articleRepository = articleRepository;
		    _slugHistoryRepository = slugHistoryRepository;
	    }

	    public async Task<Article> Handle(DetailsGetRequest request, CancellationToken cancellationToken)
	    {
		    var article = await _articleRepository.GetArticleBySlug(request.Slug);
		    var historical = await _slugHistoryRepository.GetSlugHistoryWithArticle(request.Slug);

		    if (article != null) return article;
		    if (historical != null) return historical.Article;

		    throw new ArticleNotFoundException();
	    }
    }
}
