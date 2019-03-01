using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BO.Models;
using ENI_Projet_Sport.ViewModels;
using ENI_Projet_Sport.Extensions;
using ENI_Projet_Sport.App_Start;

namespace ENI_Projet_Sport.Tests
{
    /// <summary>
    /// Description résumée pour MapperConfigTest
    /// </summary>
    [TestClass]
    public class MapperConfigTest
    {
        public MapperConfigTest()
        {
            //
            // TODO: ajoutez ici la logique du constructeur
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void MappingRace_test()
        {
            MapperConfig.InitMapper();

            // Date
            var date = DateTime.Now;
            // Race
            Race race1 = new Race
            {
                Id = 1,
                City = "Nantes",
                ZipCode = "44000",
                Name = "Race 1",
                Description = "Description race 1",
                PlacesNumber = 50,
                Price = 8,
                DateMAJ = date,
                Persons = new List<Person>(),
                POIs = new List<POI>()
            };
            // RaceViewModel
            RaceViewModel raceVM1 = new RaceViewModel
            {
                Id = 1,
                City = "Nantes",
                ZipCode = "44000",
                Name = "Race 1",
                Description = "Description race 1",
                PlacesNumber = 50,
                Price = 8,
                DateMAJ = date,
                Persons = new List<PersonViewModel>(),
                POIs = new List<POIViewModel>()
            };

            // Mapping Race -> RaceViewModel
            RaceViewModel resultRaceVM1 = race1.Map<RaceViewModel>();

            // Tests
            Assert.AreEqual(raceVM1.Id, resultRaceVM1.Id);
            Assert.AreEqual(raceVM1.City, resultRaceVM1.City);
            Assert.AreEqual(raceVM1.ZipCode, resultRaceVM1.ZipCode);
            Assert.AreEqual(raceVM1.Name, resultRaceVM1.Name);
            Assert.AreEqual(raceVM1.Description, resultRaceVM1.Description);
            Assert.AreEqual(raceVM1.PlacesNumber, resultRaceVM1.PlacesNumber);
            Assert.AreEqual(raceVM1.Price, resultRaceVM1.Price);
            Assert.AreEqual(raceVM1.DateMAJ, resultRaceVM1.DateMAJ);
            CollectionAssert.AreEqual(raceVM1.Persons, resultRaceVM1.Persons);
            CollectionAssert.AreEqual(raceVM1.POIs, resultRaceVM1.POIs);

            // Mapping RaceViewModel -> Race
            Race resultRace1 = raceVM1.Map<Race>();

            // Tests
            Assert.AreEqual(race1.Id, resultRace1.Id);
            Assert.AreEqual(race1.City, resultRace1.City);
            Assert.AreEqual(race1.ZipCode, resultRace1.ZipCode);
            Assert.AreEqual(race1.Name, resultRace1.Name);
            Assert.AreEqual(race1.Description, resultRace1.Description);
            Assert.AreEqual(race1.PlacesNumber, resultRace1.PlacesNumber);
            Assert.AreEqual(race1.Price, resultRace1.Price);
            Assert.AreEqual(race1.DateMAJ, resultRace1.DateMAJ);
            CollectionAssert.AreEqual(race1.Persons, resultRace1.Persons);
            CollectionAssert.AreEqual(race1.POIs, resultRace1.POIs);

            
        }
    }
}
