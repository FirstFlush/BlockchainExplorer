using Microsoft.AspNetCore.Mvc;
using BlockchainExplorer.App.Services;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using Serilog;

namespace BlockchainExplorer.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlockchainController : ControllerBase
    {
        private readonly IBlockchainService _blockchainService;
    
        public BlockchainController(IBlockchainService blockchainService)
        {
            _blockchainService = blockchainService;
        }

        public async Task<IActionResult> GetTransaction(string txid)
        {
            var result = await _blockchainService.GetTransactionAsync(txid);
            if (result == null)
            {
                return NotFound($"TXID {txid} not found.");    
            }
            return Ok(result);
            
        }

        public async Task<IActionResult> GetAddress(string address)
        {
            var addressInfo = await _blockchainService.GetAddressInfoAsync(address);
            if (address == null) 
            {
                return NotFound($"Address {address} not found.");
            }
            return Ok(addressInfo);
        }

    }
}