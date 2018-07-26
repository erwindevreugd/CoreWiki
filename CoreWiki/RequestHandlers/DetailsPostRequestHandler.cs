using CoreWiki.Data.Data.Interfaces;
using CoreWiki.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CoreWiki.Data;
using CoreWiki.Data.Models;
using CoreWiki.Data.Security;
using Microsoft.AspNetCore.Identity;
using NodaTime;

namespace CoreWiki.RequestHandlers
{
	public class DetailsPostRequestHandler : IRequestHandler<DetailsPostRequest, bool>
    {
	    private readonly IArticleRepository _articleRepository;
	    private readonly ISlugHistoryRepository _slugHistoryRepository;
	    private readonly ICommentRepository _commentRepository;
	    private readonly UserManager<CoreWikiUser> _userManager;
		private readonly IClock _clock;

		public DetailsPostRequestHandler(
			IArticleRepository articleRepository,
			ISlugHistoryRepository slugHistoryRepository,
			ICommentRepository commentRepository,
			UserManager<CoreWikiUser> userManager,
			IClock clock)
	    {
		    _articleRepository = articleRepository;
		    _slugHistoryRepository = slugHistoryRepository;
		    _commentRepository = commentRepository;
		    _userManager = userManager;
		    _clock = clock;
	    }

	    public async Task<bool> Handle(DetailsPostRequest request, CancellationToken cancellationToken)
	    {
		    var article = await _articleRepository.GetArticleById(request.ArticleId);

		    if (article == null) throw new ArticleNotFoundException();

		    var comment = new Comment()
		    {
				Id = 0,
				IdArticle = request.ArticleId,
				AuthorId = request.AuthorId,
				Article = article,
				DisplayName = request.DisplayName,
				Email = request.Email,
				Submitted = _clock.GetCurrentInstant(),
		    };

		    await _commentRepository.CreateComment(comment);

		    return true;
	    }
    }
}
