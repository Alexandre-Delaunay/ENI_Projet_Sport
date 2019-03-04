using BO.Base;
using BO.Services;
using ENI_Projet_Sport.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENI_Projet_Sport.Tests
{
    public class ServiceRaceTypeTest
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServiceRaceType _serviceRaceType = _serviceLocator.GetService<IServiceRaceType>();

        [TestMethod]
        public void ServiceRaceTypeTest_Add()
        {
            var raceType = MockHelper.Get_RaceTypes()[0];

            _serviceRaceType.Add(raceType);

            var result1 = _serviceRaceType.GetById(raceType.Id);

            Assert.IsNull(result1);

            _serviceRaceType.Commit();

            var result2 = _serviceRaceType.GetById(raceType.Id);

            Assert.AreEqual(result2, raceType);
        }

        [TestMethod]
        public void ServiceRaceTypeTest_Update()
        {
            var raceType = MockHelper.Get_RaceTypes()[0];

            raceType.Name = "Test Update";

            _serviceRaceType.Update(raceType);

            var result1 = _serviceRaceType.GetById(raceType.Id);

            Assert.AreNotEqual(raceType, result1);

            _serviceRaceType.Commit();

            var result2 = _serviceRaceType.GetById(raceType.Id);

            Assert.AreEqual(raceType.Name, result2.Name);
        }

        [TestMethod]
        public void ServiceRaceTypeTest_Delete()
        {
            var raceType = MockHelper.Get_RaceTypes()[0];
            _serviceRaceType.Add(raceType);
            _serviceRaceType.Commit();

            _serviceRaceType.Delete(raceType);

            var result1 = _serviceRaceType.GetById(raceType.Id);
            Assert.AreEqual(raceType, result1);

            _serviceRaceType.Commit();

            var result2 = _serviceRaceType.GetById(raceType.Id);
            Assert.IsNull(result2);
        }

        [TestMethod]
        public void ServiceRaceTypeTest_GetById()
        {
            var raceType1 = MockHelper.Get_RaceTypes()[0];
            var raceType2 = MockHelper.Get_RaceTypes()[1];

            _serviceRaceType.Add(raceType1);
            _serviceRaceType.Add(raceType2);
            _serviceRaceType.Commit();

            var result1 = _serviceRaceType.GetById(raceType1.Id);
            var result2 = _serviceRaceType.GetById(raceType2.Id);

            Assert.AreEqual(raceType1, result1);
            Assert.AreEqual(raceType2, result2);
        }

        [TestMethod]
        public void ServiceRaceTypeTest_GetAll()
        {
            var result1 = _serviceRaceType.GetAll();
            Assert.IsNull(result1);

            var raceTypes = MockHelper.Get_RaceTypes();

            foreach (var raceType in raceTypes)
            {
                _serviceRaceType.Add(raceType);
            }

            var result2 = _serviceRaceType.GetAll();

            CollectionAssert.AreEqual(raceTypes, result2);
        }
    }
}
