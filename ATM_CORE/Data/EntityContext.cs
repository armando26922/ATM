using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ATM_CORE.Models;

namespace ATM_CORE.Data
{
    public class EntityContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public EntityContext (DbContextOptions<EntityContext> options)
            : base(options)
        {


        }
     
        public DbSet<ATM_CORE.Models.Cards> Cards { get; set; }
        public DbSet<ATM_CORE.Models.Operations> Operations { get; set; }

    }
}
