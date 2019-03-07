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
    public class ServicePersonTest
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServicePerson _servicePerson = _serviceLocator.GetService<IServicePerson>();

        [TestMethod]
        public void ServicePersonTest_Add()
        {
            var person = MockHelper.Get_Persons(false)[0];

            _servicePerson.Add(person);

            _servicePerson.Commit();

            var result1 = _servicePerson.GetById(person.Id);

            Assert.AreEqual(result1, person);
        }

        [TestMethod]
        public void ServicePersonTest_Update()
        {
            var person = MockHelper.Get_Persons(false)[0];

            _servicePerson.Add(person);
            _servicePerson.Commit();

            person.FirstName = "Test Update";

            _servicePerson.Update(person);

            _servicePerson.Commit();

            var result1 = _servicePerson.GetById(person.Id);

            Assert.AreEqual(person.FirstName, result1.FirstName);
        }

        [TestMethod]
        public void ServicePersonTest_Delete()
        {
            var person = MockHelper.Get_Persons(false)[0];

            _servicePerson.Add(person);
            _servicePerson.Commit();

            _servicePerson.Delete(person);
            _servicePerson.Commit();

            var result1 = _servicePerson.GetById(person.Id);
            Assert.IsNull(result1);
        }

        [TestMethod]
        public void ServicePersonTest_GetById()
        {
            var person1 = MockHelper.Get_Persons(false)[0];
            var person2 = MockHelper.Get_Persons(false)[1];

            _servicePerson.Add(person1);
            _servicePerson.Add(person2);
            _servicePerson.Commit();

            var result1 = _servicePerson.GetById(person1.Id);
            var result2 = _servicePerson.GetById(person2.Id);

            Assert.AreEqual(person1, result1);
            Assert.AreEqual(person2, result2);
        }

        [TestMethod]
        public void ServicePersonTest_GetAll()
        {
            var lstDeleted = _servicePerson.GetAll();

            lstDeleted.ForEach(p => _servicePerson.Delete(p));
            _servicePerson.Commit();

            var persons = MockHelper.Get_Persons(false);

            persons.ForEach(p => _servicePerson.Add(p));
            _servicePerson.Commit();

            var result1 = _servicePerson.GetAll();

            CollectionAssert.AreEqual(persons, result1);
        }
    }
}
