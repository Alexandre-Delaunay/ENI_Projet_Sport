using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENI_Projet_Sport.Tests.Helpers
{
    public sealed class MockHelper
    {
        public static List<RaceType> Get_RaceTypes()
        {
            var lst = new List<RaceType>();

            var raceType1 = new RaceType()
            {
                Id = 1,
                DateMAJ = DateTime.Now,
                Name = "Boat",
            };

            var raceType2 = new RaceType()
            {
                Id = 2,
                DateMAJ = DateTime.Now,
                Name = "Car",
            };

            var raceType3 = new RaceType()
            {
                Id = 3,
                DateMAJ = DateTime.Now,
                Name = "Horse",
            };

            return lst;
        }
        public static List<DisplayConfiguration> Get_DisplayConfigurations()
        {
            var lst = new List<DisplayConfiguration>();

            var displayConfiguration1 = new DisplayConfiguration
            {
                Id = 1,
                DateMAJ = DateTime.Now,
                TypeUnite = TypeUnit.KmPerHour,
            };

            var displayConfiguration2 = new DisplayConfiguration
            {
                Id = 2,
                DateMAJ = DateTime.Now,
                TypeUnite = TypeUnit.MeterPerHour,
            };

            lst.Add(displayConfiguration1);
            lst.Add(displayConfiguration2);

            return lst;
        }
        public static List<CategoryPOI> Get_CategoryPOIs()
        {
            var lst = new List<CategoryPOI>();

            var CategoryPOI1 = new CategoryPOI()
            {
                Id = 1,
                DateMAJ = DateTime.Now,
                Name = "Checkpoint 1",
            };

            var CategoryPOI2 = new CategoryPOI()
            {
                Id = 2,
                DateMAJ = DateTime.Now,
                Name = "Checkpoint 2",
            };

            var CategoryPOI3 = new CategoryPOI()
            {
                Id = 3,
                DateMAJ = DateTime.Now,
                Name = "End line",
            };

            lst.Add(CategoryPOI1);
            lst.Add(CategoryPOI2);
            lst.Add(CategoryPOI3);

            return lst;
        }
        public static List<Person> Get_Persons()
        {
            var lst = new List<Person>();

            var person1 = new Person()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Rachid",
                DateMAJ = DateTime.Now,
                PhoneNumber = "0625145241",
                BirthDate = new DateTime(1980, 5, 20)
            };

            var person2 = new Person()
            {
                Id = 2,
                FirstName = "Tony",
                LastName = "Montana",
                DateMAJ = DateTime.Now,
                PhoneNumber = "0625535241",
                BirthDate = new DateTime(1995, 10, 15)
            };

            lst.Add(person1);
            lst.Add(person2);

            return lst;
        }
        public static List<POI> Get_POIs()
        {
            var lst = new List<POI>();

            var poi1 = new POI()
            {
                Id = 1,
                DateMAJ = DateTime.Now,
                Latitude = -2541,
                Longitude = 5412,
                CategoryPOI = Get_CategoryPOIs()[0],
            };

            var poi2 = new POI()
            {
                Id = 2,
                DateMAJ = DateTime.Now,
                Latitude = -3565,
                Longitude = 1452,
                CategoryPOI = Get_CategoryPOIs()[1],
            };

            var poi3 = new POI()
            {
                Id = 3,
                DateMAJ = DateTime.Now,
                Latitude = -2542,
                Longitude = 1520,
                CategoryPOI = Get_CategoryPOIs()[2],
            };

            return lst;
        }
        public static List<Race> Get_Races()
        {
            var lst = new List<Race>();

            var race1 = new Race()
            {
                Id = 1,
                City = "New York",
                DateMAJ = DateTime.Now,
                Description = "A amazing tour in NY",
                Name = "New York carting race",
                Price = 25,
                PlacesNumber = 1500,
                ZipCode = "47200",
                Persons = Get_Persons(),
                POIs = Get_POIs(),
            };

            var race2 = new Race()
            {
                Id = 2,
                City = "Monaco",
                DateMAJ = DateTime.Now,
                Description = "A amazing tour in Monaco",
                Name = "Monaco boat race",
                Price = 2000,
                PlacesNumber = 35,
                ZipCode = "48752",
                Persons = Get_Persons(),
                POIs = Get_POIs(),
            };

            lst.Add(race1);
            lst.Add(race2);

            return lst;
        }
    }
}
