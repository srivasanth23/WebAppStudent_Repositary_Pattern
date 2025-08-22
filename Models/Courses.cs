using System.ComponentModel.DataAnnotations;

namespace WebAppStudent_Repositary_Pattern.Models
{
    public class Courses
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string Credits { get; set; }

        public Courses() { }

        public Courses(int id, string name, string description, string credits)
        {
            Id = id;
            Name = name;
            Description = description;
            Credits = credits;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Credits: {Credits}";
        }

    }
}
