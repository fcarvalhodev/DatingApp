using AutoMapper;
using DatingAppApi.DTOs;
using DatingAppApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingAppApi.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            return Ok(_mapper.Map<IEnumerable<MemberDto>>(await _userRepository.GetUsersAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return _mapper.Map<MemberDto>(await _userRepository.GetUserByUsernameAsync(username.ToLower()));
        }

    }
}
