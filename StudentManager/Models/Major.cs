using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManager.Models
{
    public class Major
    {
        [Key]
        public int MajorId { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(300)]
        [Required]
        public string Details { get; set; }

        public Major()
        {
        }
    }
}
