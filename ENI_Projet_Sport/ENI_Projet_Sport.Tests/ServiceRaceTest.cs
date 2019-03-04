using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BO.Models;
using System.Collections.Generic;
using BO.Base;
using BO.Services;
using ENI_Projet_Sport.Tests.Helpers;

namespace ENI_Projet_Sport.Tests
{
    [TestClass]
    public class ServiceRaceTest
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServiceRace _serviceRace = _serviceLocator.GetService<IServiceRace>();

        [TestMethod]
        public void ServiceRaceTest_Add()
        {
            var race = MockHelper.Get_Races()[0];

            _serviceRace.Add(race);

            var result1 = _serviceRace.GetById(race.Id);

            Assert.IsNull(result1);

            _serviceRace.Commit();

            var result2 = _serviceRace.GetById(race.Id);

            Assert.AreEqual(result2, race);
        }

        [TestMethod]
        public void ServiceRaceTest_Update()
        {
            var race = MockHelper.Get_Races()[0];

            race.City = "Test Update";

            _serviceRace.Update(race);

            var result1 = _serviceRace.GetById(race.Id);

            Assert.AreNotEqual(race, result1);

            _serviceRace.Commit();

            var result2 = _serviceRace.GetById(race.Id);

            Assert.AreEqual(race.City, result2.City);
        }

        [TestMethod]
        public void ServiceRaceTest_Delete()
        {
            var race = MockHelper.Get_Races()[0];
            _serviceRace.Add(race);
            _serviceRace.Commit();

            _serviceRace.Delete(race);

            var result1 = _serviceRace.GetById(race.Id);
            Assert.AreEqual(race, result1);

            _serviceRace.Commit();

            var result2 = _serviceRace.GetById(race.Id);
            Assert.IsNull(result2);
        }

        [TestMethod]
        public void ServiceRaceTest_GetById()
        {
            var race1 = MockHelper.Get_Races()[0];
            var race2 = MockHelper.Get_Races()[1];

            _serviceRace.Add(race1);
            _serviceRace.Add(race2);
            _serviceRace.Commit();

            var result1 = _serviceRace.GetById(race1.Id);
            var result2 = _serviceRace.GetById(race2.Id);

            Assert.AreEqual(race1, result1);
            Assert.AreEqual(race2, result2);
        }

        [TestMethod]
        public void ServiceRaceTest_GetAll()
        {
            var result1 = _serviceRace.GetAll();
            Assert.IsNull(result1);

            var races = MockHelper.Get_Races();

            foreach (var race in races)
            {
                _serviceRace.Add(race);
            }

            var result2 = _serviceRace.GetAll();

            CollectionAssert.AreEqual(races, result2);
        }
    }
}
