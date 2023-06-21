using AutoMapper;
using Bico.Domain.Entities.User;
using Bico.WebApi.Authorization;
using Bico.WebApi.Models.Request;
using Fatec.Domain.Entities.User;
using Fatec.Domain.Services.Interfaces.Address;
using Fatec.Domain.Services.Interfaces.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectFatec.WebApi.Models.Request;
using ProjectFatec.WebApi.Models.Response.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MSAuthorize = Microsoft.AspNetCore.Authorization;

namespace ProjectFatec.WebApi.Controllers
{
    [MSAuthorize.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        private IJwtUtils _jwtUtils;

        public UserController(IUserService userService, IAddressService addressService, IMapper mapper, IJwtUtils jwtUtils)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _addressService = addressService ?? throw new ArgumentNullException(nameof(addressService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _jwtUtils = jwtUtils;
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] long id) 
        {
            var user = _mapper.Map<UserViewModel>(await _userService.GetUserById(id));

            if (user == null) 
                return BadRequest();

            return Ok(user);
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = _mapper.Map<IEnumerable<UserViewModel>>(await _userService.GetAllUsers());

            foreach (var user in users)
                user.Address = _mapper.Map<AddressViewModel>(await _addressService.GetAddressByUserId(user.Id));

            if (users == null)
                return BadRequest();

            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(AuthenticateResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Authenticate(AuthenticateRequestRequest model)
        {
            var response = await _userService.Authenticate(_mapper.Map<AuthenticateRequest>(model));

            if(response == null)
                return NotFound();

            var responseToAuthenticateResponse = _mapper.Map<AuthenticateResponse>(response);

            if (responseToAuthenticateResponse == null)
                return BadRequest();

            responseToAuthenticateResponse.Token = _jwtUtils.GenerateToken(response);

            return Ok(responseToAuthenticateResponse);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateUser(UserRequest request)
        {
            User user = _mapper.Map<User>(request);

            bool response = await _userService.CreateUser(user);

            if (!response)
                return BadRequest();

            return Ok(new { message = "Registration successful" });
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] long id, UserUpdateRequest request)
        {
            var user = _mapper.Map<User>(request);

            var response = await _userService.UpdateUser(id, user);

            if (!response)
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] long id)
        {
            var response = await _userService.DeleteUser(id);

            if (!response)
                return BadRequest();

            return Ok();
        }
    }
}
