﻿namespace WebMVC.Models
{
    public class UserFront
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Data_Expedicao { get; set; }
        public string Orgao_Expedicao { get; set; }
        public string UF { get; set; }
        public string DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Estado_Civil { get; set; }
        public DadosEndereco Endereco { get; set; }
    }

    public class DadosEndereco
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public int Id_Cliente { get; set; }
    }
}
