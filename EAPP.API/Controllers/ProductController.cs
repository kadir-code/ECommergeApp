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
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllProducts()
        {
            if (ModelState.IsValid)
            {
                var data = await _repository.GetAllAsync(x => x.Status != Status.Removed);
                return Ok(data);
            }
            return BadRequest("Error");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            if (ModelState.IsValid)
            {
                var product = await _repository.GetDefaultAsync(x => x.Id == id);
                var result = _mapper.Map<GetProductDTO>(product);
                return Ok(result);
            }
            return BadRequest("Error");
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO dto)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(dto);
                await _repository.CreateAsync(product);
                return Created("", product);
            }
            return BadRequest("Error");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deletedEntity = await _repository.GetDefaultAsync(x => x.Id == id);
            if (ModelState.IsValid)
            {
                deletedEntity.Status = Status.Removed;
                deletedEntity.RemovedDate = DateTime.Now;
                await _repository.DeleteAsync(deletedEntity);
                return Ok(deletedEntity);
            }
            return BadRequest("Error");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateCategoryDTO dto)
        {
            var updatedEntity = await _repository.GetDefaultAsync(x => x.Id == dto.Id);
            if (ModelState.IsValid)
            {
                updatedEntity.Price = dto.Price;
                updatedEntity.Name = dto.Name;
                updatedEntity.StockCode = dto.StockCode;
                updatedEntity.ModifiedDate = DateTime.Now;
                updatedEntity.Status = Status.Modified;
                await _repository.UpdateAsync(updatedEntity);
                return Ok("Updated");
            }
            return BadRequest("Error");

        }
       
    }
}
