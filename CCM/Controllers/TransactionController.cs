using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Controllers
{
    [ApiController]
    [Route(TransactionRoute.ApiPrefix)]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _service;

        public TransactionController(TransactionService service)
        {
            _service = service;
        }

        [HttpPost(TransactionRoute.List)]
        public Task<List<Transaction>> GetAllTransactions()
        {
            return _service.ListAllTransactionsAsync();
        }

        [HttpPost(TransactionRoute.GetById)]
        public Task<Transaction> GetTransactionById(ulong id)
        {
            return _service.GetTransactionByIdAsync(id);
        }

        [HttpPost(TransactionRoute.Create)]
        public Task CreateTransaction(Transaction transaction)
        {
            return _service.CreateTransactionAsync(transaction);
        }

        [HttpPost(TransactionRoute.Update)]
        public Task UpdateTransaction(ulong id, Transaction transaction)
        {
            transaction.Id = id; // Ensure the provided id matches the entity id
            return _service.UpdateTransactionAsync(transaction);
        }

        [HttpPost(TransactionRoute.Delete)]
        public Task DeleteTransaction(ulong id)
        {
            return _service.DeleteTransactionAsync(id);
        }

        [HttpPost(TransactionRoute.Count)]
        public Task<int> GetTransactionCount()
        {
            return _service.CountTransactionsAsync();
        }
    }
}