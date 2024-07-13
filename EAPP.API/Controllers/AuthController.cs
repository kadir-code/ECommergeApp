using AutoMapper;
using EApp.Domain.Entities.Concrete;
using EApp.Domain.Enums;
using EApp.Infrastructure.Repositories.Interfaces.BaseRepository;
using EApp.Infrastructure.Repositories.Interfaces.ConcreteRepositories;
using EAPP.API.Models.DTOs;
using EAPP.API.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAPP.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserRepository _userRepository;
        private readonly IMapper _maper;

        public AuthController(IMapper maper, IAppUserRepository userRepository)
        {
            _maper = maper;
            _userRepository = userRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateAppUserDTO dto)
        {
            if (ModelState.IsValid)
            {
                var user = _maper.Map<AppUser>(dto);
                await _userRepository.CreateAsync(user);
                return Created("", user);
            }
            return BadRequest("Error");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var dto = new CheckUserDTO();
            var user = await _userRepository.GetDefaultAsync(x => x.FirstName == loginDTO.FirstName && x.Password == loginDTO.Password);
            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.FirstName = user.FirstName;
                dto.Id = user.Id;
                dto.IsExist = true;
                return Created("", JwtTokenGenerator.GenerateToken(dto));
            }

            return BadRequest("Error");
        }


    }
}
