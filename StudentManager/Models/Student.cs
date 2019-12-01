using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManager.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [MaxLength(150)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string SchoolYear { get; set; }
        [Required]
        [ForeignKey("Major")]
        public int MajorRefId { get; set; }
        public Major Major { get; set; }
    }
}