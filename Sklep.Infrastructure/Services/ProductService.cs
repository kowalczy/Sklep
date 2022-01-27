using Sklep.Core.Domain;
using Sklep.Core.Repositories;
using Sklep.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task Add(Product p)
        {
            await _productRepository.AddAsync(p);

        }

        public async Task<IEnumerable<ProductDTO>> BrowseAll()
        {
            IEnumerable<Product> z = await _productRepository.BrowseAllAsync();
            if (z == null)
            {
                return null;
            }
            return z.Select(x => new ProductDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Brand = x.Brand,
                Category = x.Category
            });
        }

        public async Task Del(int id)
        {
            await _productRepository.DelAsync(id);
        }

        public async Task<ProductDTO> Get(int id)
        {
            Product product = await _productRepository.GetAsync(id);
            if (product == null)
            {
                return null;
            }
            return new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Brand = product.Brand,
                Category = product.Category
            };
        }

        
        public async Task Update(Product p, int id)
        {
            await _productRepository.UpdateAsync(p, id);
        }
    }
}
