using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingSession11Project.Models
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions option) : base(option)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
