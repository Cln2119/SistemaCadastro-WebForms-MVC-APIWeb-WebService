namespace WebMVC.Models
{
    public interface IUserFront
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Email { get; set; }
        string CpfCnpj { get; set; }
        DateTime CreateAt { get; set; }
        DateTime UpdateAt { get; set; }
    }
}