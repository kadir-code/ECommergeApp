using AutoMapper;
using EApp.Domain.Entities.Concrete;
using EApp.Domain.Enums;
using EApp.Infrastructure.Repositories.Interfaces.ConcreteRepositories;
using EAPP.API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAPP.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDTO dto)
        {
            if (ModelState.IsValid)
            {
                var order = _mapper.Map<Order>(dto);
                await _orderRepository.CreateAsync(order);
                return Created("",order);
            }
            return BadRequest("Error");
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            if (ModelState.IsValid)
            {
                var order = await _orderRepository.GetAllAsync(x=>x.Status!=Status.Removed);
                return Ok(order);

            }
            return BadRequest("Error");
        }
    }
}
