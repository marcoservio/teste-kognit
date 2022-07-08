using Kognit.Models;
using System.Data.SqlClient;
using System.Data;

namespace Kognit.Services
{
    public class WalletService
    {
        string conexao = @"Data Source=MARCOSERVIO\SQLEXPRESS;Initial Catalog=KOGNIT;Integrated Security=True";

        public List<Wallet> GetWallets()
        {
            List<Wallet> wallets = new List<Wallet>();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM WALLET_KOG", conn))
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var wallet = new Wallet();
                                wallet.Id = Convert.ToInt32(reader["ID"]);
                                wallet.UserId = Convert.ToInt32(reader["USER_ID"]);
                                wallet.ValorAtual = Convert.ToDecimal(reader["VALOR_ATUAL"]);
                                wallet.UltimaAtualizacao = Convert.ToDateTime(reader["ULTIMA_ATUALIZACAO"]);
                                
                                wallets.Add(wallet);
                            }
                        }
                    }
                }
            }

            return wallets;
        }

        public List<Wallet> GetWalletsByUser(int id)
        {
            List<Wallet> wallets = new List<Wallet>();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM WALLET_KOG WHERE USER_ID = @USER_ID", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@USER_ID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var wallet = new Wallet();
                                wallet.Id = Convert.ToInt32(reader["ID"]);
                                wallet.UserId = Convert.ToInt32(reader["USER_ID"]);
                                wallet.ValorAtual = Convert.ToDecimal(reader["VALOR_ATUAL"]);
                                wallet.UltimaAtualizacao = Convert.ToDateTime(reader["ULTIMA_ATUALIZACAO"]);

                                wallets.Add(wallet);
                            }
                        }
                    }
                }
            }

            return wallets;
        }

        public void InsertWallet(Wallet wallet)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO WALLET_KOG (USER_ID, VALOR_ATUAL, BANCO, ULTIMA_ATUALIZACAO) VALUES(@USER_ID, @VALOR_ATUAL, @BANCO, @ULTIMA_ATUALIZACAO)", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", wallet.Id);
                    cmd.Parameters.AddWithValue("@USER_ID", wallet.UserId);
                    cmd.Parameters.AddWithValue("@VALOR_ATUAL", wallet.ValorAtual);
                    cmd.Parameters.AddWithValue("@BANCO", wallet.Banco);
                    cmd.Parameters.AddWithValue("@ULTIMA_ATUALIZACAO", wallet.UltimaAtualizacao);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
