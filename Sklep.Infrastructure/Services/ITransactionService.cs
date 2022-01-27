using Sklep.Core.Domain;
using Sklep.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Infrastructure.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDTO>> BrowseAll();
        Task Add(Transaction t);
        Task Del(int id);
        Task<TransactionDTO> Get(int id);
        Task Update(Transaction t, int id);
    }
}
