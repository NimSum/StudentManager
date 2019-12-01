using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace StudentManager.Models
{
    public class MajorContext : DbContext
    {
        public MajorContext(DbContextOptions<MajorContext> options): base(options)
        {
        }

    }
}
