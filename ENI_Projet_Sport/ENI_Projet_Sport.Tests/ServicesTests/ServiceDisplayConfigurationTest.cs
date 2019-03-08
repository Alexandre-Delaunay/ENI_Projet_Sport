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
    [TestClass]
    public class ServiceDisplayConfigurationTest
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServiceDisplayConfiguration _serviceDisplayConfiguration = _serviceLocator.GetService<IServiceDisplayConfiguration>();

        [TestMethod]
        public void ServiceDisplayConfigurationTest_Add()
        {
            var displayConfiguration = MockHelper.Get_DisplayConfigurations(false)[0];

            _serviceDisplayConfiguration.Add(displayConfiguration);

            _serviceDisplayConfiguration.Commit();

            var result1 = _serviceDisplayConfiguration.GetById(displayConfiguration.Id);

            Assert.AreEqual(result1, displayConfiguration);
        }

        [TestMethod]
        public void ServiceDisplayConfigurationTest_Update()
        {
            var displayConfiguration = MockHelper.Get_DisplayConfigurations(false)[0];

            _serviceDisplayConfiguration.Add(displayConfiguration);
            _serviceDisplayConfiguration.Commit();

            displayConfiguration.TypeUnite = TypeUnit.Miles;

            _serviceDisplayConfiguration.Update(displayConfiguration);

            _serviceDisplayConfiguration.Commit();

            var result1 = _serviceDisplayConfiguration.GetById(displayConfiguration.Id);

            Assert.AreEqual(displayConfiguration.TypeUnite, result1.TypeUnite);
        }

        [TestMethod]
        public void ServiceDisplayConfigurationTest_Delete()
        {
            var displayConfiguration = MockHelper.Get_DisplayConfigurations(false)[0];

            _serviceDisplayConfiguration.Add(displayConfiguration);
            _serviceDisplayConfiguration.Commit();

            _serviceDisplayConfiguration.Delete(displayConfiguration);
            _serviceDisplayConfiguration.Commit();

            var result1 = _serviceDisplayConfiguration.GetById(displayConfiguration.Id);
            Assert.IsNull(result1);
        }

        [TestMethod]
        public void ServiceDisplayConfigurationTest_GetById()
        {
            var displayConfiguration1 = MockHelper.Get_DisplayConfigurations(false)[0];
            var displayConfiguration2 = MockHelper.Get_DisplayConfigurations(false)[1];

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
            var lstDeleted = _serviceDisplayConfiguration.GetAll();

            lstDeleted.ForEach(d => _serviceDisplayConfiguration.Delete(d));
            _serviceDisplayConfiguration.Commit();

            var displayConfigurations = MockHelper.Get_DisplayConfigurations(false);

            displayConfigurations.ForEach(d => _serviceDisplayConfiguration.Add(d));
            _serviceDisplayConfiguration.Commit();

            var result1 = _serviceDisplayConfiguration.GetAll();

            CollectionAssert.AreEqual(displayConfigurations, result1);
        }
    }
}
