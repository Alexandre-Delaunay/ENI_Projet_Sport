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
        //public virtual DbSet<Arme> Armes { get; set; }

        //public virtual DbSet<Samourai> Samourais { get; set; }

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

