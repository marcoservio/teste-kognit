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

        [HttpGet("getWallets")]
        public ActionResult<IEnumerable<Wallet>> Get()
        {
            var wallets = _walletRepository.GetWallets;

            if (wallets == null)
                return NotFound();

            return wallets;
        }

        [HttpGet("getWalletsByUser")]
        public ActionResult<IEnumerable<Wallet>> GetByUsers(int id)
        {
            var wallets = _walletRepository.GetWalletsByUser(id);

            if (wallets == null)
                return NotFound();

            return wallets;
        }

        [HttpGet("getWalletById")]
        public ActionResult<Wallet> GetById(int id)
        {
            var wallet = _walletRepository.GetWalletById(id);

            if (wallet == null)
                return NotFound();

            return wallet;
        }

        [HttpPost("createWallet")]
        public ActionResult Create([FromBody] Wallet wallet)
        {
            if (wallet == null)
                return NotFound();

            _walletRepository.InserirWallet(wallet);

            return NoContent();
        }

        [HttpDelete("deleteWallet")]
        public ActionResult<Wallet> Delete(int id)
        {
            var walletToDelete = _walletRepository.GetWalletById(id);

            if (walletToDelete == null)
                return NotFound();

            _walletRepository.Delete(walletToDelete.Id);

            return NoContent();
        }

        [HttpPut("updateWallet")]
        public ActionResult Update(int id, [FromBody] Wallet wallet)
        {
            if (id != wallet.Id)
                return BadRequest();

            _walletRepository.Update(wallet);

            return NoContent();
        }
    }
}
