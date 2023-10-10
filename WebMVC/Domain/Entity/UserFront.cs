namespace WebMVC.Models
{
    public class UserFront : IUserFront
    {
        public int Id { get; set; }       
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? CpfCnpj { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
