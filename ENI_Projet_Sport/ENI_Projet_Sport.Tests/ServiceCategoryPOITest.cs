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
    public class ServiceCategoryPOITest
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServiceCategoryPOI _serviceCategoryPOI = _serviceLocator.GetService<IServiceCategoryPOI>();

        [TestMethod]
        public void ServiceCategoryPOITest_Add()
        {
            var categoryPOI = MockHelper.Get_CategoryPOIs()[0];

            _serviceCategoryPOI.Add(categoryPOI);

            var result1 = _serviceCategoryPOI.GetById(categoryPOI.Id);

            Assert.IsNull(result1);

            _serviceCategoryPOI.Commit();

            var result2 = _serviceCategoryPOI.GetById(categoryPOI.Id);

            Assert.AreEqual(result2, categoryPOI);
        }

        [TestMethod]
        public void ServiceCategoryPOITest_Update()
        {
            var categoryPOI = MockHelper.Get_CategoryPOIs()[0];

            categoryPOI.Name = "Test Update";

            _serviceCategoryPOI.Update(categoryPOI);

            var result1 = _serviceCategoryPOI.GetById(categoryPOI.Id);

            Assert.AreNotEqual(categoryPOI, result1);

            _serviceCategoryPOI.Commit();

            var result2 = _serviceCategoryPOI.GetById(categoryPOI.Id);

            Assert.AreEqual(categoryPOI.Name, result2.Name);
        }

        [TestMethod]
        public void ServiceCategoryPOITest_Delete()
        {
            var categoryPOI = MockHelper.Get_CategoryPOIs()[0];
            _serviceCategoryPOI.Add(categoryPOI);
            _serviceCategoryPOI.Commit();

            _serviceCategoryPOI.Delete(categoryPOI);

            var result1 = _serviceCategoryPOI.GetById(categoryPOI.Id);
            Assert.AreEqual(categoryPOI, result1);

            _serviceCategoryPOI.Commit();

            var result2 = _serviceCategoryPOI.GetById(categoryPOI.Id);
            Assert.IsNull(result2);
        }

        [TestMethod]
        public void ServiceCategoryPOITest_GetById()
        {
            var categoryPOI1 = MockHelper.Get_CategoryPOIs()[0];
            var categoryPOI2 = MockHelper.Get_CategoryPOIs()[1];

            _serviceCategoryPOI.Add(categoryPOI1);
            _serviceCategoryPOI.Add(categoryPOI2);
            _serviceCategoryPOI.Commit();

            var result1 = _serviceCategoryPOI.GetById(categoryPOI1.Id);
            var result2 = _serviceCategoryPOI.GetById(categoryPOI2.Id);

            Assert.AreEqual(categoryPOI1, result1);
            Assert.AreEqual(categoryPOI2, result2);
        }

        [TestMethod]
        public void ServiceCategoryPOITest_GetAll()
        {
            var result1 = _serviceCategoryPOI.GetAll();
            Assert.IsNull(result1);

            var categoryPOIs = MockHelper.Get_CategoryPOIs();

            foreach (var categoryPOI in categoryPOIs)
            {
                _serviceCategoryPOI.Add(categoryPOI);
            }

            var result2 = _serviceCategoryPOI.GetAll();

            CollectionAssert.AreEqual(categoryPOIs, result2);
        }
    }
}
