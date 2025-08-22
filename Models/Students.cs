using System.ComponentModel.DataAnnotations;

namespace WebAppStudent_Repositary_Pattern.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string  Address { get; set; }

        public Students() { }

        public Students(int id, string name, string email, string address)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Email: {Email}, Address: {Address}";
        }
    }
}
