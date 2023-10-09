using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceHost.Classe;

namespace WCFServiceHost
{
    public class UserWcfService : IUserWcfService
    {
        public List<UserWcf> GetAllUsers()
        {

            //Recupera os dados do DB para DEV e HOM no Webconfig
            var connectionString = ConfigurationManager.ConnectionStrings["DevConnection"].ConnectionString;

            List<UserWcf> listUser = new List<UserWcf>();
                  
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Abertura de conexão com o DB
                connection.Open();

                //Montagem da tabela
                string sqlQuery = "SELECT * FROM Usuarios";

                //Inicio da configuração de conexao com DB
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Monta retorno em objeto
                            UserWcf user = new UserWcf
                            {
                                Id = (int)reader["Id"],
                                Nome = reader["Nome"].ToString(),
                                Email = reader["Email"].ToString(),
                                CpfCnpj = reader["CpfCnpj"].ToString(),
                                CreateAt = reader["CreateAt"].ToString(),
                                UpdateAt = reader["UpdateAt"].ToString()
                            };

                            //Armazena em lista
                            listUser.Add(user);
                        }
                    }                   
                }
                //Fechando conexão com DB
                connection.Close();
            }

            return listUser;


        }
        public UserWcf GetUserById(int productId)
        {
            UserWcf user = new UserWcf();

            return user;
        }
        public void AddUser(UserWcf user)
        {
            //Recupera os dados do DB para DEV e HOM no Webconfig
            var connectionString = ConfigurationManager.ConnectionStrings["DevConnection"].ConnectionString;

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                //Montagem da tabela
                string sqlQuery = "INSERT INTO Usuarios (Nome, Email, CpfCnpj, CreateAt, UpdateAt) VALUES (@Nome, @Email, @CpfCnpj, @CreateAt, @UpdateAt)";
                
                using (SqlCommand comando = new SqlCommand( sqlQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", user.Nome);
                    comando.Parameters.AddWithValue("@Email", user.Email);
                    comando.Parameters.AddWithValue("@CpfCnpj", user.CpfCnpj);
                    comando.Parameters.AddWithValue("@CreateAt", user.CreateAt);
                    comando.Parameters.AddWithValue("@UpdateAt", user.UpdateAt);
                    comando.ExecuteNonQuery();
                }                    
               
                conexao.Close();
            }
        }
        public void UpdateUser(UserWcf user)
        {
            //Recupera os dados do DB para DEV e HOM no Webconfig
            var connectionString = ConfigurationManager.ConnectionStrings["DevConnection"].ConnectionString;

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                //Montagem da tabela
                string sqlQuery = "UPDATE Usuarios SET Nome = @Nome , Email = @Email , CpfCnpj = @CpfCnpj, UpdateAt = @UpdateAt WHERE ID = @Id";

                using (SqlCommand comando = new SqlCommand(sqlQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@Id", user.Id);
                    comando.Parameters.AddWithValue("@Nome", user.Nome);
                    comando.Parameters.AddWithValue("@Email", user.Email);
                    comando.Parameters.AddWithValue("@CpfCnpj", user.CpfCnpj);
                    comando.Parameters.AddWithValue("@CreateAt", user.CreateAt);
                    comando.Parameters.AddWithValue("@UpdateAt", user.UpdateAt);                    
                    comando.ExecuteNonQuery();
                }

                conexao.Close();
            }
        }
        public void DeleteUser(int id)
        {
            //Recupera os dados do DB para DEV e HOM no Webconfig
            var connectionString = ConfigurationManager.ConnectionStrings["DevConnection"].ConnectionString;

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                //Montagem da tabela
                string sqlQuery = "DELETE FROM Usuarios WHERE ID = @Id";

                using (SqlCommand comando = new SqlCommand(sqlQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@Id", id);
                
                    comando.ExecuteNonQuery();
                }

                conexao.Close();
            }
        }
    }
}
