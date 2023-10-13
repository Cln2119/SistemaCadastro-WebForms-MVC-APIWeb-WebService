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
                string sqlQuery = "SELECT Cliente.id," 
                                    + "Cliente.CPF,"
                                    + "Cliente.Nome,"
                                    + "Cliente.RG,"
                                    + "Cliente.Data_Expedicao,"
                                    + "Cliente.Orgao_Expedicao,"
                                    + "Cliente.UF,"
                                    + "Cliente.Data_Nascimento,"
                                    + "Cliente.Sexo,"
                                    + "Cliente.Estado_Civil,"
                                    + "Endereco_Cliente.id_cliente AS EnderecoID,"
                                    + "Endereco_Cliente.CEP,"
                                    + "Endereco_Cliente.Logradouro,"
                                    + "Endereco_Cliente.Numero,"
                                    + "Endereco_Cliente.Complemento,"
                                    + "Endereco_Cliente.Bairro,"
                                    + "Endereco_Cliente.Cidade,"
                                    + "Endereco_Cliente.UF,"
                                    + "Endereco_Cliente.id_cliente FROM Cliente INNER JOIN Endereco_Cliente ON Cliente.id = Endereco_Cliente.id_cliente;";

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
                                Id = (int)reader["id"],                             
                                CPF = reader["CPF"].ToString(),
                                Nome = reader["Nome"].ToString(),
                                RG = reader["RG"].ToString(),
                                Data_Expedicao = DateTime.Parse(reader["Data_Expedicao"].ToString()),
                                Orgao_Expedicao = reader["Orgao_Expedicao"].ToString(),
                                UF = reader["UF"].ToString(),
                                DataNascimento = DateTime.Parse(reader["Data_Nascimento"].ToString()),
                                Sexo = reader["Sexo"].ToString(),
                                Estado_Civil = reader["Estado_Civil"].ToString(),
                                    Endereco_Cliente = new Endereco
                                    {
                                        CEP = reader["CEP"].ToString(),
                                        Logradouro = reader["Logradouro"].ToString(),
                                        Numero = reader["Numero"].ToString(),
                                        Complemento = reader["Complemento"].ToString(),
                                        Bairro = reader["Bairro"].ToString(),
                                        Cidade = reader["Cidade"].ToString(),
                                        UF = reader["UF"].ToString(),
                                        Id_Cliente = int.Parse(reader["id_cliente"].ToString())
                                    }

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
        public UserWcf GetUserById(int id)
        {
            //Recupera os dados do DB para DEV e HOM no Webconfig
            var connectionString = ConfigurationManager.ConnectionStrings["DevConnection"].ConnectionString;

            UserWcf user = new UserWcf();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Abertura de conexão com o DB
                connection.Open();

                //Montagem da tabela
                string sqlQuery = "SELECT Cliente.id,"
                                   + "Cliente.CPF,"
                                   + "Cliente.Nome,"
                                   + "Cliente.RG,"
                                   + "Cliente.Data_Expedicao,"
                                   + "Cliente.Orgao_Expedicao,"
                                   + "Cliente.UF,"
                                   + "Cliente.Data_Nascimento,"
                                   + "Cliente.Sexo,"
                                   + "Cliente.Estado_Civil,"
                                   + "Endereco_Cliente.id_cliente AS EnderecoID,"
                                   + "Endereco_Cliente.CEP,"
                                   + "Endereco_Cliente.Logradouro,"
                                   + "Endereco_Cliente.Numero,"
                                   + "Endereco_Cliente.Complemento,"
                                   + "Endereco_Cliente.Bairro,"
                                   + "Endereco_Cliente.Cidade,"
                                   + "Endereco_Cliente.UF,"
                                   + "Endereco_Cliente.id_cliente FROM Cliente INNER JOIN Endereco_Cliente ON Cliente.id = Endereco_Cliente.id_cliente WHERE Cliente.id = @ClienteId;";
                                 

                //Inicio da configuração de conexao com DB
                using (SqlCommand comando = new SqlCommand(sqlQuery, connection))
                {
                    comando.Parameters.AddWithValue("@ClienteId", id);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        reader.Read();

                        user = new UserWcf
                        {
                            Id = (int)reader["id"],
                            CPF = reader["CPF"].ToString(),
                            Nome = reader["Nome"].ToString(),
                            RG = reader["RG"].ToString(),
                            Data_Expedicao = DateTime.Parse(reader["Data_Expedicao"].ToString()),
                            Orgao_Expedicao = reader["Orgao_Expedicao"].ToString(),
                            UF = reader["UF"].ToString(),
                            DataNascimento = DateTime.Parse(reader["Data_Nascimento"].ToString()),
                            Sexo = reader["Sexo"].ToString(),
                            Estado_Civil = reader["Estado_Civil"].ToString(),
                            Endereco_Cliente = new Endereco
                            {
                                CEP = reader["CEP"].ToString(),
                                Logradouro = reader["Logradouro"].ToString(),
                                Numero = reader["Numero"].ToString(),
                                Complemento = reader["Complemento"].ToString(),
                                Bairro = reader["Bairro"].ToString(),
                                Cidade = reader["Cidade"].ToString(),
                                UF = reader["UF"].ToString(),
                                Id_Cliente = int.Parse(reader["id_cliente"].ToString())
                            }

                        };
                    }
                }

                //Fechando conexão com DB
                connection.Close();
            }

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
                string sqlQuery = "BEGIN TRANSACTION;"
                                + "INSERT INTO Cliente (CPF, Nome, RG, Data_Expedicao, Orgao_Expedicao, UF, Data_Nascimento, Sexo, Estado_Civil)"
                                + "VALUES (@CPF, @Nome, @RG, @Data_Expedicao, @Orgao_Expedicao, @UFORGAO, @Data_Nascimento, @Sexo, @Estado_Civil);"
                                + "DECLARE @ClienteID INT;"
                                + "SET @ClienteID = SCOPE_IDENTITY();"
                                + "INSERT INTO Endereco_Cliente (CEP, Logradouro, Numero, Complemento, Bairro, Cidade, UF, id_cliente)"
                                + "VALUES (@CEP, @Logradouro, @Numero, @Complemento, @Bairro, @Cidade, @UFESTADO, @ClienteID);"
                                + "COMMIT;"; 
                
                using (SqlCommand comando = new SqlCommand( sqlQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@CPF", user.CPF);
                    comando.Parameters.AddWithValue("@Nome", user.Nome);
                    comando.Parameters.AddWithValue("@RG", user.RG);
                    comando.Parameters.AddWithValue("@Orgao_Expedicao", user.Orgao_Expedicao);
                    comando.Parameters.AddWithValue("@Data_Expedicao", user.Data_Expedicao);
                    comando.Parameters.AddWithValue("@UFORGAO", user.UF);
                    comando.Parameters.AddWithValue("@Data_Nascimento", user.DataNascimento);
                    comando.Parameters.AddWithValue("@Sexo", user.Sexo);
                    comando.Parameters.AddWithValue("@Estado_Civil", user.Estado_Civil);
                    comando.Parameters.AddWithValue("@CEP", user.Endereco_Cliente.CEP);
                    comando.Parameters.AddWithValue("@Logradouro", user.Endereco_Cliente.Logradouro);
                    comando.Parameters.AddWithValue("@Numero", user.Endereco_Cliente.Numero);
                    comando.Parameters.AddWithValue("@Complemento", user.Endereco_Cliente.Complemento);
                    comando.Parameters.AddWithValue("@Bairro", user.Endereco_Cliente.Bairro);
                    comando.Parameters.AddWithValue("@Cidade", user.Endereco_Cliente.Cidade);
                    comando.Parameters.AddWithValue("@UFESTADO", user.Endereco_Cliente.UF);                   

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
                string sqlQuery = "UPDATE Cliente SET Nome = @Nome, CPF = @CPF, Orgao_Expedicao = @Orgao_Expedicao, Data_Expedicao= @Data_Expedicao,UF = @UFORGAO, Data_Nascimento = @Data_Nascimento,  Sexo = @Sexo, Estado_Civil = @Estado_Civil WHERE id = @Id "
                    + "UPDATE Endereco_Cliente SET  CEP = @CEP, Logradouro = @Logradouro, Numero = @Numero, Complemento = @Complemento, Bairro = @Bairro, Cidade = @Cidade, UF = @UFESTADO WHERE id_cliente = @Id; ";
                  

                using (SqlCommand comando = new SqlCommand(sqlQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@Id", user.Id);
                    comando.Parameters.AddWithValue("@CPF", user.CPF);
                    comando.Parameters.AddWithValue("@Nome", user.Nome);
                    comando.Parameters.AddWithValue("@RG", user.RG);
                    comando.Parameters.AddWithValue("@Orgao_Expedicao", user.Orgao_Expedicao);
                    comando.Parameters.AddWithValue("@Data_Expedicao", user.Data_Expedicao);
                    comando.Parameters.AddWithValue("@UFORGAO", user.UF);
                    comando.Parameters.AddWithValue("@Data_Nascimento", user.DataNascimento);
                    comando.Parameters.AddWithValue("@Sexo", user.Sexo);
                    comando.Parameters.AddWithValue("@Estado_Civil", user.Estado_Civil);
                    comando.Parameters.AddWithValue("@CEP", user.Endereco_Cliente.CEP);
                    comando.Parameters.AddWithValue("@Logradouro", user.Endereco_Cliente.Logradouro);
                    comando.Parameters.AddWithValue("@Numero", user.Endereco_Cliente.Numero);
                    comando.Parameters.AddWithValue("@Complemento", user.Endereco_Cliente.Complemento);
                    comando.Parameters.AddWithValue("@Bairro", user.Endereco_Cliente.Bairro);
                    comando.Parameters.AddWithValue("@Cidade", user.Endereco_Cliente.Cidade);
                    comando.Parameters.AddWithValue("@UFESTADO", user.Endereco_Cliente.UF);
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
                string sqlQuery = "DELETE FROM Endereco_Cliente WHERE id_cliente = @Id DELETE FROM Cliente WHERE id = @Id ";

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
