using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormGTI
{
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listUser = BindGridView();
            if (listUser != null)
            {
                GridViewUsuarios.DataSource = listUser;
                GridViewUsuarios.DataBind();
            }
            
        }

        private List<UserWCF.UserWcf> BindGridView()
        {
            UserWCF.IUserWcfService user = new UserWCF.UserWcfServiceClient();

            var listUsers = user.GetAllUsers().ToList();

            return listUsers;
        }

        protected void btnInclusao_Click(object sender, EventArgs e)
        {
            int? id = Session["UserID"] as int?;

            if (id == null)
            {
                UserWCF.IUserWcfService user = new UserWCF.UserWcfServiceClient();

                //Dados clientes
                string cpf = txtCPF.Text;
                string nome = txtNome.Text;
                string RG = txtRG.Text;
                string data_expedicao = txtDataExpedicao.Text;
                string orgao_expedicao = orgao.Text;
                string orgaoUf = estados.Text;
                string dataNascimento = txtDataNascimento.Text;
                string sexo = txtSexo.Text;
                string estadoCivil = civil.Text;
                //Dados Endereço
                string cep = txtCEP.Text;
                string logradouro = txtRua.Text;
                string numero = txtNumero.Text;
                string complemento = txtComplemento.Text;
                string bairro = txtBairro.Text;
                string cidade = txtCidade.Text;
                string ufEstado = uf.Text;


                var userDados = new UserWCF.UserWcf
                {
                    CPF = cpf,
                    Nome = nome,
                    RG = RG,
                    Data_Expedicao = DateTime.Parse(data_expedicao),
                    Orgao_Expedicao = orgao_expedicao,
                    UF = orgaoUf,
                    DataNascimento = DateTime.Parse(dataNascimento),
                    Sexo = sexo,
                    Estado_Civil = estadoCivil,
                    Endereco_Cliente = new UserWCF.Endereco
                    {
                        CEP = cep,
                        Logradouro = logradouro,
                        Numero = numero,
                        Complemento = complemento,
                        Bairro = bairro,
                        Cidade = cidade,
                        UF = ufEstado,
                    }
                };

                user.AddUser(userDados);

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                UserWCF.IUserWcfService user = new UserWCF.UserWcfServiceClient();

                //Dados clientes
                string cpf = txtCPF.Text;
                string nome = txtNome.Text;
                string RG = txtRG.Text;
                string data_expedicao = txtDataExpedicao.Text;
                string orgao_expedicao = orgao.Text;
                string orgaoUf = estados.Text;
                string dataNascimento = txtDataNascimento.Text;
                string sexo = txtSexo.Text;
                string estadoCivil = civil.Text;
                //Dados Endereço
                string cep = txtCEP.Text;
                string logradouro = txtRua.Text;
                string numero = txtNumero.Text;
                string complemento = txtComplemento.Text;
                string bairro = txtBairro.Text;
                string cidade = txtCidade.Text;
                string ufEstado = uf.Text;


                var userDados = new UserWCF.UserWcf
                {                   
                    Id = id,
                    CPF = cpf,
                    Nome = nome,
                    RG = RG,
                    Data_Expedicao = DateTime.Parse(data_expedicao),
                    Orgao_Expedicao = orgao_expedicao,
                    UF = orgaoUf,
                    DataNascimento = DateTime.Parse(dataNascimento),
                    Sexo = sexo,
                    Estado_Civil = estadoCivil,
                    Endereco_Cliente = new UserWCF.Endereco
                    {
                        CEP = cep,
                        Logradouro = logradouro,
                        Numero = numero,
                        Complemento = complemento,
                        Bairro = bairro,
                        Cidade = cidade,
                        UF = ufEstado,
                    }
                };

                user.UpdateUser(userDados);

                Response.Redirect(Request.RawUrl);
            }

        }
        protected void btnExclusao_Click(object sender, EventArgs e)
        {
            LinkButton lnkEdit = (LinkButton)sender;
            int id = Convert.ToInt32(lnkEdit.Attributes["data-id"]);
            UserWCF.IUserWcfService user = new UserWCF.UserWcfServiceClient();
            user.DeleteUser(id);
            Session.Remove("UserID");

            Response.Redirect(Request.RawUrl);
        }
        protected void btnAtualizarCliente_Click(object sender, EventArgs e)
        {
            LinkButton lnkEdit = (LinkButton)sender;
            int id = Convert.ToInt32(lnkEdit.Attributes["data-id"]);
            Session["UserID"] = id;

            UserWCF.IUserWcfService user = new UserWCF.UserWcfServiceClient();
            var retornoUser = user.GetUserById(id);

            string dataNascimentoFormatada = retornoUser.DataNascimento.ToString("yyyy-MM-dd");
            string dataExpedicao = retornoUser.Data_Expedicao.ToString("yyyy-MM-dd");


            //Dados clientes
            txtCPF.Text = retornoUser.CPF;
            txtNome.Text = retornoUser.Nome;
            txtRG.Text = retornoUser.RG;
            txtDataExpedicao.Text = dataExpedicao;
            orgao.Text = retornoUser.Orgao_Expedicao;
            estados.Text = retornoUser.UF;
            txtDataNascimento.Text = dataNascimentoFormatada;
            txtSexo.Text = retornoUser.Sexo;
            civil.Text = retornoUser.Estado_Civil;        
            //Dados Endereço
            txtCEP.Text = retornoUser.Endereco_Cliente.CEP;
            txtRua.Text = retornoUser.Endereco_Cliente.Logradouro;
            txtNumero.Text = retornoUser.Endereco_Cliente.Numero;
            txtComplemento.Text = retornoUser.Endereco_Cliente.Complemento;
            txtBairro.Text = retornoUser.Endereco_Cliente.Bairro;
            txtCidade.Text = retornoUser.Endereco_Cliente.Cidade;
            uf.Text = retornoUser.Endereco_Cliente.UF;

            //string script = " $('#mymodal').modal('show');";
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }
    }
}