using Kognit.Models;
using Kognit.Services;

namespace Kognit.Repository
{
    public class WalletRepository
    {
        private readonly WalletService _wallet;

        public WalletRepository()
        {
            _wallet = new WalletService();
        }

        public List<Wallet> GetWallets
        {
            get
            {
                return _wallet.GetWallets();
            }
        }

        public List<Wallet> GetWalletsByUser(int id)
        {
            return _wallet.GetWalletsByUser(id);
        }

        public Wallet GetWalletById(int id)
        {
            return _wallet.GetWalletById(id);
        }

        public void InserirWallet(Wallet wallet)
        {
            _wallet.InsertWallet(wallet);
        }

        public void Delete(int id)
        {
            _wallet.Delete(id);
        }

        public void Update(Wallet wallet)
        {
            _wallet.Update(wallet);
        }
    }
}
