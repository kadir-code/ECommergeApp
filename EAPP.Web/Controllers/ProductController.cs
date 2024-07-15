using EAPP.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace EAPP.Web.Controllers
{
    //[Authorize]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> List()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5127/api/Product/ListAllProducts");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<ProductListModel>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                return View(result);
            }

            return View();
        }
        public async Task<IActionResult> Create()
        {
            var model = new CreateProductModel();
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5127/api/Order/GetOrders");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<List<OrderListModel>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                model.Orders = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(data, "Id", "TotalPrice");
                return View(model);
            }

            return RedirectToAction("List");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonSerializer.Serialize(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"http://localhost:5127/api/Product/CreateProduct", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            ModelState.AddModelError("", "Error");
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"http://localhost:5127/api/Product/DeleteProduct/{id}");
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseProduct = await client.GetAsync($"http://localhost:5127/api/Product/GetProductById/{id}");
            if (responseProduct.IsSuccessStatusCode)
            {
                var jsonData=await responseProduct.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<UpdateProductModel>(jsonData,new JsonSerializerOptions
                {
                    PropertyNamingPolicy=JsonNamingPolicy.CamelCase
                });
                var responseOrder = await client.GetAsync("http://localhost:5127/api/Order/GetOrders");
                if (responseOrder.IsSuccessStatusCode)
                {
                    var jsonOrderData=await responseOrder.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<List<OrderListModel>>(jsonOrderData);
                    if (result != null)
                    {
                        result.Orders = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(data,"Id", "TotalPrice");
                    }
                    return View(result);
                }
            }
            return RedirectToAction("List");


        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductModel model)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonSerializer.Serialize(model);
            var content=new StringContent(jsonData,Encoding.UTF8,"application/json");

            var response = await client.PutAsync($"http://localhost:5127/api/Product/UpdateProduct",content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            ModelState.AddModelError("","Error");
            return View(model);
        }

    }
}
