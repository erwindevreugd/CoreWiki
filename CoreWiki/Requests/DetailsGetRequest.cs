using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWiki.Data.Models;
using MediatR;

namespace CoreWiki.Requests
{
    public class DetailsGetRequest : IRequest<Article>
    {
		public string Slug { get; set; }
    }
}
