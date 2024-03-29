﻿using ENI_Projet_Sport.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ENI_Projet_Sport.Tests.ControllersTests
{
    [TestClass]
    public class CategoryPOIControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            CategoryPOIController controller = new CategoryPOIController();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            CategoryPOIController controller = new CategoryPOIController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            CategoryPOIController controller = new CategoryPOIController();

            // Act
            ViewResult result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            CategoryPOIController controller = new CategoryPOIController();

            // Act
            ViewResult result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
