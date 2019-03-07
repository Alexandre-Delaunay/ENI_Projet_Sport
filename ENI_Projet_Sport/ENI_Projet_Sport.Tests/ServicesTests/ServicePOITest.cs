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
    public class ServicePOITest
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServicePOI _servicePOI = _serviceLocator.GetService<IServicePOI>();

        [TestMethod]
        public void ServicePOITest_Add()
        {
            var pOI = MockHelper.Get_POIs(false)[0];

            _servicePOI.Add(pOI);

            _servicePOI.Commit();

            var result1 = _servicePOI.GetById(pOI.Id);

            Assert.AreEqual(result1, pOI);
        }

        [TestMethod]
        public void ServicePOITest_Update()
        {
            var pOI = MockHelper.Get_POIs(false)[0];

            _servicePOI.Add(pOI);
            _servicePOI.Commit();

            pOI.Latitude = 5415;

            _servicePOI.Update(pOI);

            _servicePOI.Commit();

            var result1 = _servicePOI.GetById(pOI.Id);

            Assert.AreEqual(pOI.Latitude, result1.Latitude);
        }

        [TestMethod]
        public void ServicePOITest_Delete()
        {
            var pOI = MockHelper.Get_POIs(false)[0];

            _servicePOI.Add(pOI);
            _servicePOI.Commit();

            _servicePOI.Delete(pOI);
            _servicePOI.Commit();

            var result1 = _servicePOI.GetById(pOI.Id);
            Assert.IsNull(result1);
        }

        [TestMethod]
        public void ServicePOITest_GetById()
        {
            var pOI1 = MockHelper.Get_POIs(false)[0];
            var pOI2 = MockHelper.Get_POIs(false)[1];

            _servicePOI.Add(pOI1);
            _servicePOI.Add(pOI2);
            _servicePOI.Commit();

            var result1 = _servicePOI.GetById(pOI1.Id);
            var result2 = _servicePOI.GetById(pOI2.Id);

            Assert.AreEqual(pOI1, result1);
            Assert.AreEqual(pOI2, result2);
        }

        [TestMethod]
        public void ServicePOITest_GetAll()
        {
            var lstDeleted = _servicePOI.GetAll();

            lstDeleted.ForEach(p => _servicePOI.Delete(p));
            _servicePOI.Commit();

            var pOIs = MockHelper.Get_POIs(false);

            pOIs.ForEach(p => _servicePOI.Add(p));
            _servicePOI.Commit();

            var result1 = _servicePOI.GetAll();

            CollectionAssert.AreEqual(pOIs, result1);
        }
    }
}
