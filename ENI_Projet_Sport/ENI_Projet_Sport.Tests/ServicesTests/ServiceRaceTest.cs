using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BO.Models;
using System.Collections.Generic;
using BO.Base;
using BO.Services;
using ENI_Projet_Sport.Tests.Helpers;

namespace ENI_Projet_Sport.ServicesTests.Tests
{
    [TestClass]
    public class ServiceRaceTest
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServiceRace _serviceRace = _serviceLocator.GetService<IServiceRace>();

        [TestMethod]
        public void ServiceRaceTest_Add()
        {
            var race = MockHelper.Get_Races(false)[0];

            _serviceRace.Add(race);

            _serviceRace.Commit();

            var result1 = _serviceRace.GetById(race.Id);

            Assert.AreEqual(result1, race);
        }

        [TestMethod]
        public void ServiceRaceTest_Update()
        {
            var race = MockHelper.Get_Races(false)[0];

            _serviceRace.Add(race);
            _serviceRace.Commit();

            race.City = "Test Update";

            _serviceRace.Update(race);

            _serviceRace.Commit();

            var result1 = _serviceRace.GetById(race.Id);

            Assert.AreEqual(race.City, result1.City);
        }

        [TestMethod]
        public void ServiceRaceTest_Delete()
        {
            var race = MockHelper.Get_Races(false)[0];

            _serviceRace.Add(race);
            _serviceRace.Commit();

            _serviceRace.Delete(race);
            _serviceRace.Commit();

            var result1 = _serviceRace.GetById(race.Id);
            Assert.IsNull(result1);
        }

        [TestMethod]
        public void ServiceRaceTest_GetById()
        {
            var race1 = MockHelper.Get_Races(false)[0];
            var race2 = MockHelper.Get_Races(false)[1];

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
            var lstDeleted = _serviceRace.GetAll();

            lstDeleted.ForEach(r => _serviceRace.Delete(r));
            _serviceRace.Commit();

            var races = MockHelper.Get_Races(false);

            races.ForEach(r => _serviceRace.Add(r));
            _serviceRace.Commit();

            var result1 = _serviceRace.GetAll();

            CollectionAssert.AreEqual(races, result1);
        }
    }
}
