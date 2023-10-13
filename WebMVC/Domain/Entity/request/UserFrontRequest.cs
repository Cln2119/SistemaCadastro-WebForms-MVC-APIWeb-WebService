namespace WebMVC.Domain.Entity.request
{
    public class UserFrontRequest
    {      
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public DateTime Data_Expedicao { get; set; }
        public string Orgao_Expedicao { get; set; }
        public string UF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Estado_Civil { get; set; }
        public DadosEnderecoRequest Endereco { get; set; }
    }

    public class DadosEnderecoRequest
    {      
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }  
    }
}
