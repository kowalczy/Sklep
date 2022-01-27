using Sklep.Core.Domain;
using Sklep.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Product p)
        {
            try
            {
                _appDbContext.Product.Add(p);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Product>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Product);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Product.Remove(_appDbContext.Product.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Product> GetAsync(int id)
        {
            try
            {
                return await Task.FromResult(_appDbContext.Product.FirstOrDefault(x => x.Id == id));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
            return null;
        }

        public async Task UpdateAsync(Product p, int id)
        {
            try
            {
                var z = _appDbContext.Product.FirstOrDefault(x => x.Id == id);
                z.Name = p.Name;
                z.Price = p.Price;
                z.Brand = p.Brand;
                z.Category = p.Category;
                z.Transaction = p.Transaction;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
