using System;
using Microsoft.EntityFrameworkCore;

namespace StudentManager.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
