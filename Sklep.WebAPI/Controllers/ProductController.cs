using Microsoft.AspNetCore.Mvc;
using Sklep.Core.Domain;
using Sklep.Infrastructure.Commands;
using Sklep.Infrastructure.Services;
using System.Threading.Tasks;

namespace Sklep.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // product
        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var z = await _productService.BrowseAll();
            return Json(z);
        }

        //localhost/product/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var z = await _productService.Get(id);
            return Json(z);
        }

        //product
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProduct product)
        {
            Product p = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                Brand = product.Brand,
                Category = product.Category
            };
            await _productService.Add(p);
            return Json(p);
        }

        //product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct([FromBody] UpdateProduct product, int id)
        {
            Product p = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                Brand = product.Brand,
                Category = product.Category
            };
            await _productService.Update(p, id);
            return Json(p);
        }

        //product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.Del(id);
            return Json(id);
        }
    }
}
