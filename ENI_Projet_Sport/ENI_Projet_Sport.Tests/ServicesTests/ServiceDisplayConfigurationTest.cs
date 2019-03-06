using BO.Base;
using BO.Models;
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
    public class ServiceDisplayConfigurationTest
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServiceDisplayConfiguration _serviceDisplayConfiguration = _serviceLocator.GetService<IServiceDisplayConfiguration>();

        [TestMethod]
        public void ServiceDisplayConfigurationTest_Add()
        {
            var displayConfiguration = MockHelper.Get_DisplayConfigurations()[0];

            _serviceDisplayConfiguration.Add(displayConfiguration);

            var result1 = _serviceDisplayConfiguration.GetById(displayConfiguration.Id);

            Assert.IsNull(result1);

            _serviceDisplayConfiguration.Commit();

            var result2 = _serviceDisplayConfiguration.GetById(displayConfiguration.Id);

            Assert.AreEqual(result2, displayConfiguration);
        }

        [TestMethod]
        public void ServiceDisplayConfigurationTest_Update()
        {
            var displayConfiguration = MockHelper.Get_DisplayConfigurations()[0];

            displayConfiguration.TypeUnite = TypeUnit.MeterPerHour;

            _serviceDisplayConfiguration.Update(displayConfiguration);

            var result1 = _serviceDisplayConfiguration.GetById(displayConfiguration.Id);

            Assert.AreNotEqual(displayConfiguration, result1);

            _serviceDisplayConfiguration.Commit();

            var result2 = _serviceDisplayConfiguration.GetById(displayConfiguration.Id);

            Assert.AreEqual(displayConfiguration.TypeUnite, result2.TypeUnite);
        }

        [TestMethod]
        public void ServiceDisplayConfigurationTest_Delete()
        {
            var displayConfiguration = MockHelper.Get_DisplayConfigurations()[0];

            _serviceDisplayConfiguration.Add(displayConfiguration);
            _serviceDisplayConfiguration.Commit();

            _serviceDisplayConfiguration.Delete(displayConfiguration);

            var result1 = _serviceDisplayConfiguration.GetById(displayConfiguration.Id);
            Assert.AreEqual(displayConfiguration, result1);

            _serviceDisplayConfiguration.Commit();

            var result2 = _serviceDisplayConfiguration.GetById(displayConfiguration.Id);
            Assert.IsNull(result2);
        }

        [TestMethod]
        public void ServiceDisplayConfigurationTest_GetById()
        {
            var displayConfiguration1 = MockHelper.Get_DisplayConfigurations()[0];
            var displayConfiguration2 = MockHelper.Get_DisplayConfigurations()[1];

            _serviceDisplayConfiguration.Add(displayConfiguration1);
            _serviceDisplayConfiguration.Add(displayConfiguration2);
            _serviceDisplayConfiguration.Commit();

            var result1 = _serviceDisplayConfiguration.GetById(displayConfiguration1.Id);
            var result2 = _serviceDisplayConfiguration.GetById(displayConfiguration2.Id);

            Assert.AreEqual(displayConfiguration1, result1);
            Assert.AreEqual(displayConfiguration2, result2);
        }

        [TestMethod]
        public void ServiceDisplayConfigurationTest_GetAll()
        {
            var result1 = _serviceDisplayConfiguration.GetAll();
            Assert.IsNull(result1);

            var displayConfigurations = MockHelper.Get_DisplayConfigurations();

            foreach (var displayConfiguration in displayConfigurations)
            {
                _serviceDisplayConfiguration.Add(displayConfiguration);
            }

            var result2 = _serviceDisplayConfiguration.GetAll();

            CollectionAssert.AreEqual(displayConfigurations, result2);
        }
    }
}
