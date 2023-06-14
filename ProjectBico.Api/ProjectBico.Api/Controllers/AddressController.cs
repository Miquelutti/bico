using AutoMapper;
using Fatec.Domain.Entities.Address;
using Fatec.Domain.Services.Interfaces.Address;
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
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AddressController(IMapper mapper, IAddressService addressService)
        {
            _addressService = addressService ?? throw new ArgumentNullException(nameof(addressService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAddress([FromRoute] long id, AddressRequest request)
        {
            var address = _mapper.Map<Address>(request);

            var response = await _addressService.UpdateAddress(id, address);

            if (!response)
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(AddressViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllAddresses() 
        {
            var addresses = _mapper.Map<IEnumerable<AddressViewModel>>(await _addressService.GetAllAddresses());

            if (addresses == null) 
                return BadRequest();

            return Ok(addresses);
        }

        [HttpGet]
        [ProducesResponseType(typeof(AddressViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("{id}")]
        public async Task<IActionResult> GetAddressById([FromRoute] long id)
        {
            var address = _mapper.Map<AddressViewModel>(await _addressService.GetAddressById(id));

            if (address == null)
                return BadRequest();

            return Ok(address);
        }

        [HttpGet]
        [ProducesResponseType(typeof(AddressViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("user/{id}")]
        public async Task<IActionResult> GetAddressByUserId([FromRoute] long id)
        {
            var address = _mapper.Map<AddressViewModel>(await _addressService.GetAddressByUserId(id));

            if (address == null)
                return BadRequest();

            return Ok(address);
        }
    }
}