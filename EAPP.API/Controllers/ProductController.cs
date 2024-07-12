using AutoMapper;
using EApp.Domain.Entities.Concrete;
using EApp.Domain.Enums;
using EApp.Infrastructure.Repositories.Interfaces.ConcreteRepositories;
using EAPP.API.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAPP.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllProducts(ProductListDTO dto)
        {
            var data=_mapper.Map<Product>(dto);
            if (ModelState.IsValid)
            {
                var result = await _repository.GetAllAsync(x => x.Status != Status.Removed);

                return Ok(result);
            }
            return BadRequest("Error");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDTO dto)
        {
            if (ModelState.IsValid)
            {
                var product=_mapper.Map<Product>(dto);
                await _repository.CreateAsync(product);
                return Created("",product);
            }
            return BadRequest("Error");

        }
    }
}
