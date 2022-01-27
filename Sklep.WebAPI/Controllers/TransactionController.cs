using Microsoft.AspNetCore.Mvc;
using Sklep.Core.Domain;
using Sklep.Infrastructure.Commands;
using Sklep.Infrastructure.Services;
using System.Threading.Tasks;

namespace Sklep.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // transaction
        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var z = await _transactionService.BrowseAll();
            return Json(z);
        }

        //localhost/transaction/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var z = await _transactionService.Get(id);
            return Json(z);
        }

        //transaction
        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] CreateTransaction transaction)
        {
            Transaction t = new Transaction()
            {
                DateTime = transaction.DateTime
            };
            await _transactionService.Add(t);
            return Json(t);
        }

        //transaction/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> EditTransaction([FromBody] UpdateTransaction transaction, int id)
        {
            Transaction t = new Transaction()
            {
                DateTime = transaction.DateTime
            };
            await _transactionService.Update(t, id);
            return Json(t);
        }

        //transaction/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            await _transactionService.Del(id);
            return Json(id);
        }
    }
}
