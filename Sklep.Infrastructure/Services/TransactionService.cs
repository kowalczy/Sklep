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
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task Add(Transaction t)
        {
            await _transactionRepository.AddAsync(t);

        }

        public async Task<IEnumerable<TransactionDTO>> BrowseAll()
        {
            IEnumerable<Transaction> z = await _transactionRepository.BrowseAllAsync();
            if (z == null)
            {
                return null;
            }
            return z.Select(x => new TransactionDTO()
            {
                Id = x.Id
            });
        }

        public async Task Del(int id)
        {
            await _transactionRepository.DelAsync(id);
        }

        public async Task<TransactionDTO> Get(int id)
        {
            Transaction transaction = await _transactionRepository.GetAsync(id);
            if (transaction == null)
            {
                return null;
            }
            return new TransactionDTO()
            {
                Id = transaction.Id,
                DateTime = transaction.DateTime
            };
        }


        public async Task Update(Transaction t, int id)
        {
            await _transactionRepository.UpdateAsync(t, id);
        }

       
    }
}
