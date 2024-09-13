using BlockchainExplorer.App.Data;
using BlockchainExplorer.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BlockchainExplorer.App.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BlockchainContext _context;

        public TransactionRepository(BlockchainContext context)
        {
            _context = context;
        }

        public async Task AddTransactionAsync(TransactionModel transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<TransactionModel?> GetTransactionByIdAsync(string txid)
        {
            return await _context.Transactions.FirstOrDefaultAsync(t => t.TransactionId == txid);
        }

        public async Task<IEnumerable<TransactionModel>> GetAllTransactionsAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task DeleteTransactionAsync(string txid)
        {
            var transaction = await GetTransactionByIdAsync(txid);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }


    }
}