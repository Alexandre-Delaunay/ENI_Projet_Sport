using BO.Base;
using BO.Services;
using ENI_Projet_Sport.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENI_Projet_Sport.ServicesTests.Tests
{
    [TestClass]
    public class ServiceRaceTypeTest
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServiceRaceType _serviceRaceType = _serviceLocator.GetService<IServiceRaceType>();

        [TestMethod]
        public void ServiceRaceTypeTest_Add()
        {
            var raceType = MockHelper.Get_RaceTypes(false)[0];

            _serviceRaceType.Add(raceType);

            _serviceRaceType.Commit();

            var result1 = _serviceRaceType.GetById(raceType.Id);

            Assert.AreEqual(result1, raceType);
        }

        [TestMethod]
        public void ServiceRaceTypeTest_Update()
        {
            var raceType = MockHelper.Get_RaceTypes(false)[0];

            _serviceRaceType.Add(raceType);
            _serviceRaceType.Commit();

            raceType.Name = "Test Update";

            _serviceRaceType.Update(raceType);

            _serviceRaceType.Commit();

            var result1 = _serviceRaceType.GetById(raceType.Id);

            Assert.AreEqual(raceType.Name, result1.Name);
        }

        [TestMethod]
        public void ServiceRaceTypeTest_Delete()
        {
            var raceType = MockHelper.Get_RaceTypes(false)[0];

            _serviceRaceType.Add(raceType);
            _serviceRaceType.Commit();

            _serviceRaceType.Delete(raceType);
            _serviceRaceType.Commit();

            var result1 = _serviceRaceType.GetById(raceType.Id);
            Assert.IsNull(result1);
        }

        [TestMethod]
        public void ServiceRaceTypeTest_GetById()
        {
            var raceType1 = MockHelper.Get_RaceTypes(false)[0];
            var raceType2 = MockHelper.Get_RaceTypes(false)[1];

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
            var lstDeleted = _serviceRaceType.GetAll();

            lstDeleted.ForEach(r => _serviceRaceType.Delete(r));
            _serviceRaceType.Commit();

            var raceTypes = MockHelper.Get_RaceTypes(false);

            raceTypes.ForEach(r => _serviceRaceType.Add(r));
            _serviceRaceType.Commit();

            var result1 = _serviceRaceType.GetAll();

            CollectionAssert.AreEqual(raceTypes, result1);
        }
    }
}
