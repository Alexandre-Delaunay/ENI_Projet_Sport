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
        public virtual DbSet<CategoryPOI> CategoriesPOI { get; set; }
        public virtual DbSet<DisplayConfiguration> DisplayConfigurations { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<RaceType> RaceTypes { get; set; }
        public virtual DbSet<POI> POIs { get; set; }

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

