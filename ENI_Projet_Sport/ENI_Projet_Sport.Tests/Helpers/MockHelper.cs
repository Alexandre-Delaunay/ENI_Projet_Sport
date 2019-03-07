using BO.Base;
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
        public static List<RaceType> Get_RaceTypes(bool withId)
        {
            var lst = new List<RaceType>();

            var raceType1 = new RaceType()
            {
                DateMAJ = DateTime.Now,
                Name = "Boat",
            };

            var raceType2 = new RaceType()
            {
                DateMAJ = DateTime.Now,
                Name = "Car",
            };

            var raceType3 = new RaceType()
            {
                DateMAJ = DateTime.Now,
                Name = "Horse",
            };

            lst.Add(raceType1);
            lst.Add(raceType2);
            lst.Add(raceType3);

            if (withId)
            {
                lst = UpdateListId(lst);
            }

            return lst;
        }
        public static List<DisplayConfiguration> Get_DisplayConfigurations(bool withId)
        {
            var lst = new List<DisplayConfiguration>();

            var displayConfiguration1 = new DisplayConfiguration
            {
                DateMAJ = DateTime.Now,
                TypeUnite = TypeUnit.KmPerHour,
            };

            var displayConfiguration2 = new DisplayConfiguration
            {
                DateMAJ = DateTime.Now,
                TypeUnite = TypeUnit.MeterPerHour,
            };

            lst.Add(displayConfiguration1);
            lst.Add(displayConfiguration2);

            if (withId)
            {
                lst = UpdateListId(lst);
            }

            return lst;
        }
        public static List<CategoryPOI> Get_CategoryPOIs(bool withId)
        {
            var lst = new List<CategoryPOI>();

            var CategoryPOI1 = new CategoryPOI()
            {
                DateMAJ = DateTime.Now,
                Name = "Checkpoint 1",
            };

            var CategoryPOI2 = new CategoryPOI()
            {
                DateMAJ = DateTime.Now,
                Name = "Checkpoint 2",
            };

            var CategoryPOI3 = new CategoryPOI()
            {
                DateMAJ = DateTime.Now,
                Name = "End line",
            };

            lst.Add(CategoryPOI1);
            lst.Add(CategoryPOI2);
            lst.Add(CategoryPOI3);

            if (withId)
            {
                lst = UpdateListId(lst);
            }

            return lst;
        }
        public static List<Person> Get_Persons(bool withId)
        {
            var lst = new List<Person>();

            var person1 = new Person()
            {
                FirstName = "John",
                LastName = "Rachid",
                DateMAJ = DateTime.Now,
                PhoneNumber = "0625145241",
                BirthDate = new DateTime(1980, 5, 20)
            };

            var person2 = new Person()
            {
                FirstName = "Tony",
                LastName = "Montana",
                DateMAJ = DateTime.Now,
                PhoneNumber = "0625535241",
                BirthDate = new DateTime(1995, 10, 15)
            };

            lst.Add(person1);
            lst.Add(person2);

            if (withId)
            {
                lst = UpdateListId(lst);
            }

            return lst;
        }
        public static List<POI> Get_POIs(bool withId)
        {
            var lst = new List<POI>();

            var poi1 = new POI()
            {
                DateMAJ = DateTime.Now,
                Latitude = -2541,
                Longitude = 5412,
                CategoryPOI = Get_CategoryPOIs(true)[0],
            };

            var poi2 = new POI()
            {
                DateMAJ = DateTime.Now,
                Latitude = -3565,
                Longitude = 1452,
                CategoryPOI = Get_CategoryPOIs(true)[1],
            };

            var poi3 = new POI()
            {
                DateMAJ = DateTime.Now,
                Latitude = -2542,
                Longitude = 1520,
                CategoryPOI = Get_CategoryPOIs(true)[2],
            };

            lst.Add(poi1);
            lst.Add(poi2);
            lst.Add(poi3);

            if (withId)
            {
                lst = UpdateListId(lst);
            }

            return lst;
        }
        public static List<Race> Get_Races(bool withId)
        {
            var lst = new List<Race>();

            var race1 = new Race()
            {
                City = "New York",
                DateMAJ = DateTime.Now,
                Description = "A amazing tour in NY",
                Name = "New York carting race",
                Price = 25,
                PlacesNumber = 1500,
                ZipCode = "47200",
                Persons = Get_Persons(true),
                POIs = Get_POIs(true),
            };

            var race2 = new Race()
            {
                City = "Monaco",
                DateMAJ = DateTime.Now,
                Description = "A amazing tour in Monaco",
                Name = "Monaco boat race",
                Price = 2000,
                PlacesNumber = 35,
                ZipCode = "48752",
                Persons = Get_Persons(true),
                POIs = Get_POIs(true),
            };

            lst.Add(race1);
            lst.Add(race2);

            if (withId)
            {
                lst = UpdateListId(lst);
            }

            return lst;
        }

        public static List<T> UpdateListId<T>(List<T> lst) where T : BaseOV
        {
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i] is BaseOV)
                {
                    var baseOV = lst[i] as BaseOV;
                    baseOV.Id = i + 1;
                }
            }

            return lst;
        }
    }
}
