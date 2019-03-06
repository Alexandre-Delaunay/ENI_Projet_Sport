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
    public class ServicePOITest
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServicePOI _servicePOI = _serviceLocator.GetService<IServicePOI>();

        [TestMethod]
        public void ServicePOITest_Add()
        {
            var pOI = MockHelper.Get_POIs()[0];

            _servicePOI.Add(pOI);

            var result1 = _servicePOI.GetById(pOI.Id);

            Assert.IsNull(result1);

            _servicePOI.Commit();

            var result2 = _servicePOI.GetById(pOI.Id);

            Assert.AreEqual(result2, pOI);
        }

        [TestMethod]
        public void ServicePOITest_Update()
        {
            var pOI = MockHelper.Get_POIs()[0];

            pOI.Latitude = 5415;

            _servicePOI.Update(pOI);

            var result1 = _servicePOI.GetById(pOI.Id);

            Assert.AreNotEqual(pOI, result1);

            _servicePOI.Commit();

            var result2 = _servicePOI.GetById(pOI.Id);

            Assert.AreEqual(pOI.Latitude, result2.Latitude);
        }

        [TestMethod]
        public void ServicePOITest_Delete()
        {
            var pOI = MockHelper.Get_POIs()[0];
            _servicePOI.Add(pOI);
            _servicePOI.Commit();

            _servicePOI.Delete(pOI);

            var result1 = _servicePOI.GetById(pOI.Id);
            Assert.AreEqual(pOI, result1);

            _servicePOI.Commit();

            var result2 = _servicePOI.GetById(pOI.Id);
            Assert.IsNull(result2);
        }

        [TestMethod]
        public void ServicePOITest_GetById()
        {
            var pOI1 = MockHelper.Get_POIs()[0];
            var pOI2 = MockHelper.Get_POIs()[1];

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
            var result1 = _servicePOI.GetAll();
            Assert.IsNull(result1);

            var pOIs = MockHelper.Get_POIs();

            foreach (var pOI in pOIs)
            {
                _servicePOI.Add(pOI);
            }

            var result2 = _servicePOI.GetAll();

            CollectionAssert.AreEqual(pOIs, result2);
        }
    }
}
