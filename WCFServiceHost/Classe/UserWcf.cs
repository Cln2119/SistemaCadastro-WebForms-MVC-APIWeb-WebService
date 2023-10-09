using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFServiceHost.Classe
{
    public class UserWcf
    {
        public Mensagem Status { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CpfCnpj { get; set; }
        public string CreateAt { get; set; }
        public string UpdateAt { get; set; }        

    }

    public class Mensagem
    {
        public bool Status { get; set; }
        public string MoreInformation { get; set; }
    }
}