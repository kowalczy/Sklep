using Sklep.Core.Domain;
using Sklep.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Infrastructure.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> BrowseAll();
        Task Add(Product p);
        Task Del(int id);
        Task<ProductDTO> Get(int id);
        Task Update(Product p, int id);
    }
}
