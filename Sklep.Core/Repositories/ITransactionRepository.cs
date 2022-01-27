using Sklep.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Core.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> BrowseAllAsync();
        Task<Transaction> GetAsync(int id);
        Task DelAsync(int id);
        Task UpdateAsync(Transaction transaction, int id);
        Task AddAsync(Transaction transaction);
    }
}
