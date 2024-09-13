

namespace BlockchainExplorer.App.Services
{
    public interface IBlockchainService 
    {
        Task<string> GetTransactionAsync(string txid);
        Task<string> GetAddressInfoAsync(string address);
    }
}