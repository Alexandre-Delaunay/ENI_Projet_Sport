using ENI_Projet_Sport.Models;
using ENI_Projet_Sport.OV;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENI_Projet_Sport.Base
{
    public class BaseContext : DbContext
    {
        public virtual DbSet<OV.ApplicationUser> ApplicationUsers{ get; set; }
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

