using ENI_Projet_Sport.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ENI_Projet_Sport.Tests.ControllersTests
{
    public class DisplayConfigurationControllerTest
    {
        [TestMethod]
        public void Edit()
        {
            // Arrange
            DisplayConfigurationController controller = new DisplayConfigurationController();

            // Act
            ViewResult result = controller.Edit() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
