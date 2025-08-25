using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppStudent_Repositary_Pattern.Models
{
    public class Enrollments
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Students")]
        public int StudentId { get; set; }
        [ForeignKey("Courses")]
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual Students? Students { get; set; }

        public virtual Courses? Courses { get; set; }

        public Enrollments() { }
        public Enrollments(int id, int studentId, int courseId, DateTime enrollmentDate)
        {
            Id = id;
            StudentId = studentId;
            CourseId = courseId;
            EnrollmentDate = enrollmentDate;
        }

        public override string ToString()
        {
            return $"Id: {Id}, StudentId: {StudentId}, CourseId: {CourseId}, EnrollmentDate: {EnrollmentDate}, StudentName : {Students?.Name}";
        }
    }
}