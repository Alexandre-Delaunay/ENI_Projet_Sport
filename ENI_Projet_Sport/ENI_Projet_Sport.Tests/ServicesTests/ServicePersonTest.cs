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
    public class ServicePersonTest
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServicePerson _servicePerson = _serviceLocator.GetService<IServicePerson>();

        [TestMethod]
        public void ServicePersonTest_Add()
        {
            var person = MockHelper.Get_Persons()[0];

            _servicePerson.Add(person);

            var result1 = _servicePerson.GetById(person.Id);

            Assert.IsNull(result1);

            _servicePerson.Commit();

            var result2 = _servicePerson.GetById(person.Id);

            Assert.AreEqual(result2, person);
        }

        [TestMethod]
        public void ServicePersonTest_Update()
        {
            var person = MockHelper.Get_Persons()[0];

            person.FirstName = "Test Update";

            _servicePerson.Update(person);

            var result1 = _servicePerson.GetById(person.Id);

            Assert.AreNotEqual(person, result1);

            _servicePerson.Commit();

            var result2 = _servicePerson.GetById(person.Id);

            Assert.AreEqual(person.FirstName, result2.FirstName);
        }

        [TestMethod]
        public void ServicePersonTest_Delete()
        {
            var person = MockHelper.Get_Persons()[0];
            _servicePerson.Add(person);
            _servicePerson.Commit();

            _servicePerson.Delete(person);

            var result1 = _servicePerson.GetById(person.Id);
            Assert.AreEqual(person, result1);

            _servicePerson.Commit();

            var result2 = _servicePerson.GetById(person.Id);
            Assert.IsNull(result2);
        }

        [TestMethod]
        public void ServicePersonTest_GetById()
        {
            var person1 = MockHelper.Get_Persons()[0];
            var person2 = MockHelper.Get_Persons()[1];

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
            var result1 = _servicePerson.GetAll();
            Assert.IsNull(result1);

            var persons = MockHelper.Get_Persons();

            foreach (var person in persons)
            {
                _servicePerson.Add(person);
            }

            var result2 = _servicePerson.GetAll();

            CollectionAssert.AreEqual(persons, result2);
        }
    }
}
