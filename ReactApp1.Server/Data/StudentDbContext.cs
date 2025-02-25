using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ReactApp1.Server.Entities;

namespace ReactApp1.Server.Data
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
