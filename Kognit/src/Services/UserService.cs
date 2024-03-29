﻿using Kognit.Models;

using Microsoft.Extensions.Configuration;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Kognit.Services
{
    public class UserService
    {
        string conexao = DadosDaConexao.StringDeConexao;

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM USER_KOG", conn))
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var user = new User();
                                user.Id = Convert.ToInt32(reader["ID"]);
                                user.Nome = reader["NOME"].ToString();
                                user.Nascimento = Convert.ToDateTime(reader["NASCIMENTO"]);
                                user.Cpf = reader["CPF"].ToString();
                                users.Add(user);
                            }
                        }
                    }
                }
            }

            return users;
        }

        public User GetUserById(int id)
        {
            User user = new User();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM USER_KOG WHERE ID = @ID", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                user.Id = Convert.ToInt32(reader["ID"]);
                                user.Nome = reader["NOME"].ToString();
                                user.Nascimento = Convert.ToDateTime(reader["NASCIMENTO"]);
                                user.Cpf = reader["CPF"].ToString();
                            }
                        }
                    }
                }
            }

            return user;
        }

        public void InsertUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO USER_KOG (NOME, NASCIMENTO, CPF) VALUES(@NOME, @NASCIMENTO, @CPF)", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", user.Id);
                    cmd.Parameters.AddWithValue("@NOME", user.Nome);
                    cmd.Parameters.AddWithValue("@NASCIMENTO", user.Nascimento);
                    cmd.Parameters.AddWithValue("@CPF", user.Cpf);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM USER_KOG WHERE ID = @ID", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(User user)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE USER_KOG SET NOME = @NOME, NASCIMENTO = @NASCIMENTO, CPF = @CPF WHERE ID = @ID", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", user.Id);
                    cmd.Parameters.AddWithValue("@NOME", user.Nome);
                    cmd.Parameters.AddWithValue("@NASCIMENTO", user.Nascimento);
                    cmd.Parameters.AddWithValue("@CPF", user.Cpf);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
