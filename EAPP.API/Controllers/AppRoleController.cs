using AutoMapper;
using EApp.Domain.Entities.Concrete;
using EApp.Infrastructure.Context;
using EApp.Infrastructure.Repositories.Interfaces.ConcreteRepositories;
using EAPP.API.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAPP.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppRoleController : ControllerBase
    {
        private readonly IAppRoleRepository _roleRepository;
        private readonly IMapper _mapper;


        public AppRoleController(IAppRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleDTO dto)
        {
            if (ModelState.IsValid)
            {
                var role = _mapper.Map<AppRole>(dto);
                await _roleRepository.CreateAsync(role);
                return Created("", role);
            }
            return BadRequest("Error");
        }
    }
}
