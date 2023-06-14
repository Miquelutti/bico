using AutoMapper;
using Fatec.Domain.Entities.Request;
using Fatec.Domain.Services.Interfaces.Request;
using Microsoft.AspNetCore.Mvc;
using ProjectFatec.WebApi.Models.Request;
using ProjectFatec.WebApi.Models.Response.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProjectFatec.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public RequestController(IMapper mapper, IRequestService requestService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _requestService = requestService ?? throw new ArgumentNullException(nameof(requestService));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateRequest(RequestRequest request)
        {
            var req = _mapper.Map<Request>(request);

            var response = await _requestService.CreateRequest(req);

            if(!response)
                return BadRequest();
                
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(RequestViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRequests()
        {
            var requests = _mapper.Map<IEnumerable<RequestViewModel>>(await _requestService.GetRequests());

            if (requests == null)
                return BadRequest();

            return Ok(requests);
        }

        [HttpGet]
        [ProducesResponseType(typeof(RequestViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var request = _mapper.Map<RequestDetailsViewModel>(await _requestService.GetById(id));

            if (request == null)
                return BadRequest();

            return Ok(request);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("{id}")]
        public async Task<IActionResult> Approval(long id, bool action)
        {
            var request = await _requestService.Approval(id, action);

            if (!request)
                return BadRequest();

            return Ok();
        }
    }
}
