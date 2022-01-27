using Sklep.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> BrowseAllAsync();
        Task<Product> GetAsync(int id);
        Task DelAsync(int id);
        Task UpdateAsync(Product product, int id);
        Task AddAsync(Product product);
    }
}
