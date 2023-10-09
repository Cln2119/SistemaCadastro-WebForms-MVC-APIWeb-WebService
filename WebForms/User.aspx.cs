using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class User : System.Web.UI.Page
    {     

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var listUser = BindGridView();
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
            UserWCF.IUserWcfService user = new UserWCF.UserWcfServiceClient();

            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string cpfCnpj = txtCpfCnpj.Text;
            string dataInclusao = DateTime.Now.ToString();
            string dataAlteracao = DateTime.Now.ToString();

            var userDados = new UserWCF.UserWcf
            {
                Nome = nome,
                Email = email,
                CpfCnpj = cpfCnpj,
                CreateAt = dataInclusao,
                UpdateAt = dataAlteracao
            };

             user.AddUser(userDados);
        }

        protected void btnAlteracao_Click(object sender, EventArgs e)
        {
            UserWCF.IUserWcfService user = new UserWCF.UserWcfServiceClient();

            int id = 1;
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string cpfCnpj = txtCpfCnpj.Text;
            string dataInclusao = DateTime.Now.ToString();
            string dataAlteracao = DateTime.Now.ToString();

            var userDados = new UserWCF.UserWcf
            {
                Id = id,
                Nome = nome,
                Email = email,
                CpfCnpj = cpfCnpj,
                CreateAt = dataInclusao,
                UpdateAt = dataAlteracao
            };

            user.UpdateUser(userDados);
        }

        protected void btnExclusao_Click(object sender, EventArgs e)
        {
            UserWCF.IUserWcfService user = new UserWCF.UserWcfServiceClient();

            int id = 1;

            user.DeleteUser(id);
        }
    }
}