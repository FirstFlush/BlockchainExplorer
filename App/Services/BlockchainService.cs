using NBitcoin;
using NBitcoin.RPC;
using System.Net;
using System.Threading.Tasks;
using BlockchainExplorer.App.Exceptions;

namespace BlockchainExplorer.App.Services
{
    public class BlockchainService : IBlockchainService
    {
        private readonly RPCClient _rpcClient;

        public BlockchainService(NetworkCredential credentials, Uri uri, Network network)
        {
            _rpcClient = new RPCClient(credentials, uri, network);
            
        }

        public async Task<string> GetTransactionAsync(string txid)
        {
            var transaction = await _rpcClient.GetRawTransactionAsync(uint256.Parse(txid));
            return transaction.ToString() ?? throw new TransactionNotFound($"Transaction {txid} not found.");
        }

        public async Task<string> GetAddressInfoAsync(string address)
        {
            var addressInfo = await _rpcClient.GetAddressInfoAsync(BitcoinAddress.Create(address, Network.Main));
            return addressInfo.ToString() ?? throw new AddressNotFound($"Address {address} not found on the blockchain.");;
        }
    }
}