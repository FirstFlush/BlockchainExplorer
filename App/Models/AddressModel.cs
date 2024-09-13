

namespace BlockchainExplorer.App.Models
{
    public class AddressModel(string transactionId, string address, bool isMine, bool isWatchOnly, decimal balance)
    {
        public string TransactionId { get; set; } = transactionId;
        public string Address { get; set; } = address;
        public bool IsMine { get; set; } = isMine;
        public bool IsWatchOnly { get; set; } = isWatchOnly;
        public decimal Balance { get; set; } = balance;
    }
}