﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FilterLists.Directory.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace FilterLists.Directory.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SyntaxesController : BaseController
    {
        private readonly IMediator _mediator;

        public SyntaxesController(IMemoryCache cache, IMediator mediator) : base(cache)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetSyntaxes.SyntaxVm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return await CacheGetOrCreateAsync(() => _mediator.Send(new GetSyntaxes.Query(), cancellationToken));
        }
    }
}
