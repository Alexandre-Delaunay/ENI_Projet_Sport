using BO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Models
{
    public class Race : BaseOV
    {
        [MaxLength(50)]
        public virtual string Name { get; set; }

        public virtual int PlacesNumber { get; set; }

        [MaxLength(50)]
        public virtual string City { get; set; }

        public virtual string ZipCode { get; set; }

        public virtual float Price { get; set; }

        public virtual DateTime DateRace { get; set; }

        public virtual float Distance { get; set; }

        [MaxLength(200)]
        public virtual string Description { get; set; }

        public virtual List<POI> POIs { get; set; }

        public virtual List<Person> Persons { get; set; }

        public virtual RaceType RaceType { get; set; }

        public Race()
        {
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();

            POIs = new List<POI>();
            Persons = new List<Person>();
        }
    }
}
