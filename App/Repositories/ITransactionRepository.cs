using BlockchainExplorer.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BlockchainExplorer.App.Repositories
{

    //This interface defines the CRUD operations available for the Transaction DB model
    public interface ITransactionRepository
    {
        Task AddTransactionAsync(TransactionModel transaction);
        Task<TransactionModel?> GetTransactionByIdAsync(string txid);
        Task<IEnumerable<TransactionModel>> GetAllTransactionsAsync();
        // Task UpdateTransactionAsync(TransactionModel transaction);
        Task DeleteTransactionAsync(string txid);
    }
}