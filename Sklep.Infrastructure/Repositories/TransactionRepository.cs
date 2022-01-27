using Sklep.Core.Domain;
using Sklep.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Infrastructure.Repositories
{
    public class TransactionRepository :ITransactionRepository
    {
        private AppDbContext _appDbContext;
        public TransactionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Transaction u)
        {
            try
            {
                _appDbContext.Transaction.Add(u);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Transaction>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Transaction);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Transaction.Remove(_appDbContext.Transaction.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Transaction> GetAsync(int id)
        {
            try
            {
                return await Task.FromResult(_appDbContext.Transaction.FirstOrDefault(x => x.Id == id));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
            return null;
        }

        public async Task UpdateAsync(Transaction t, int id)
        {
            try
            {
                var z = _appDbContext.Transaction.FirstOrDefault(x => x.Id == id);
                z.DateTime = t.DateTime;
                z.Products = t.Products;
                z.User = t.User;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
