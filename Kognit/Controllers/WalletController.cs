using Kognit.Models;
using Kognit.Repository;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kognit.Controllers
{
    public class WalletController : Controller
    {
        private readonly WalletRepository _walletRepository;

        public WalletController()
        {
            _walletRepository = new WalletRepository();
        }

        [HttpGet("getWallet")]
        public ActionResult<IEnumerable<Wallet>> Get()
        {
            return _walletRepository.GetWallets;
        }

        [HttpGet("getWalletByUser")]
        public ActionResult<IEnumerable<Wallet>> Get(int id)
        {
            if(id > 0)
                return _walletRepository.GetWalletsByUser(id);
        }

        [HttpPost("createWallet")]
        public void Create([FromBody] Wallet wallet)
        {
            _walletRepository.InserirWallet(wallet);
        }


    }
}
