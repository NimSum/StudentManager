using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace StudentManager.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {
        }

        public DbSet<Major> Majors { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
