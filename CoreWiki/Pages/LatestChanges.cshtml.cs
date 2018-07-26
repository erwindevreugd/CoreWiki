using CoreWiki.Data.Data.Interfaces;
using CoreWiki.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWiki.Pages
{
	public class LatestChangesModel : PageModel
	{
		private readonly IArticleRepository _articleRepo;

		public LatestChangesModel(IArticleRepository articleRepo)
		{
			_articleRepo = articleRepo;
		}


		public IList<ArticleSummaryDTO> Articles { get; set; }


		public async Task OnGetAsync()
		{
			Articles = (from article in await _articleRepo.GetLatestArticles(10)
				select new ArticleSummaryDTO
				{
					Slug = article.Slug,
					Topic = article.Topic,
					Published = article.Published,
					ViewCount = article.ViewCount
				}).ToList();
		}
	}
}
