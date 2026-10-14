using System.ComponentModel.DataAnnotations;
namespace pract4_97.Database.Entities
{
    public class User
    {
        public int UserId { get; set; }
        [Required] public string? UserName { get; set; }
        public string? Address { get; set; }
        public string? Contact { get; set; }
    }
}
