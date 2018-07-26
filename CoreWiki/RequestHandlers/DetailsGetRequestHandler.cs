using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CoreWiki.Data.Models;
using CoreWiki.Requests;
using MediatR;

namespace CoreWiki.RequestHandlers
{
    public class DetailsGetRequestHandler : IRequestHandler<DetailsGetRequest, Article>
    {
	    public DetailsGetRequestHandler()
	    {

	    }

	    public async Task<Article> Handle(DetailsGetRequest request, CancellationToken cancellationToken)
	    {
		    throw new NotImplementedException();
	    }
    }
}
