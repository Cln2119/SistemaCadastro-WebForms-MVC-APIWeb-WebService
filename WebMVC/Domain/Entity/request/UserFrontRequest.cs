namespace WebMVC.Domain.Entity.request
{
    public class UserFrontRequest
    {       
        public string? nome { get; set; }
        public string? email { get; set; }
        public string? cpfCnpj { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }
    }
}
