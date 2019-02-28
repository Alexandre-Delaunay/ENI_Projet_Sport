using BO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Base
{
    public class BaseContext : DbContext
    {
        public virtual DbSet<Models.ApplicationUser> ApplicationUsers{ get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DisplayConfiguration> DisplayConfigurations { get; set; }
        public virtual DbSet<Inscription> Inscriptions { get; set; }
        public virtual DbSet<Personne> Personnes { get; set; }
        public virtual DbSet<Race> Races { get; set; }

        public BaseContext()
            : base("BaseContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}

