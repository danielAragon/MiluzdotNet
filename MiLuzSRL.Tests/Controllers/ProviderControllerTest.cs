using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiLuzSRL.Models;
using Moq;
using FluentAssertions;
using System.Collections.Generic;
using System.Data.Entity;
using MiLuzSRL.Controllers;
using System.Collections;

namespace MiLuzSRL.Tests.Controllers
{
    [TestClass]
    public class ProviderControllerTest
    {
        [TestMethod]
        public void C_Provider_Index_View_Contains_ListOfProviders_Model()
        {
            try
            {
                //Arrange
                Mock<IProviderRepository> mock = new Mock<IProviderRepository>();

                mock.Setup(m => m.GetProviders()).Returns(new List<Provider>()
            {
                new Provider {Id = 1, Name = "Coca Cola", PhoneNumber = "12345", Currency = "Bolivianos", HasDebt = false },
                new Provider {Id = 2, Name = "Costa", PhoneNumber = "54321", Currency = "Dollars", HasDebt = true },
                new Provider {Id = 3, Name = "Mondelez", PhoneNumber = "13579", Currency = "Bolivianos", HasDebt = true }
            }.As<IEnumerable<Provider>>);

                ProvidersController controller = new ProvidersController(mock.Object);

                //Act
                var actual = (List<Provider>)controller.Index().Model;

                //Assert
                Assert.IsInstanceOfType(actual, typeof(List<Provider>));
            }
            catch (Exception e)
            {
                Assert.Fail("Fallo la prueba: " + e.Message);
            }
        }

        [TestMethod]
        public void D_Provider_Index_View_Does_Not_Contain_ListOfProviders_Model()
        {
            try
            {
                //Arrange
                Mock<IProviderRepository> mock = new Mock<IProviderRepository>();

                mock.Setup(m => m.GetProviders()).Returns(new List<Provider>()
                {
                }.As<IEnumerable<Provider>>);

                ProvidersController controller = new ProvidersController(mock.Object);

                //Act
                List<Provider> actual = (List<Provider>)controller.Index().Model;

                //Assert
                Assert.IsTrue(!Convert.ToBoolean(actual.Count));
            }
            catch (Exception e)
            {
                Assert.Fail("Fallo la prueba: " + e.Message);
            }
        }

        [TestMethod]
        public void A_Provider_Insert()
        {
            try
            {
                //Arrange
                Mock<IProviderRepository> mock = new Mock<IProviderRepository>();

                Provider provider = new Provider()
                {
                    Id = 1,
                    Name = "Coca Cola",
                    PhoneNumber = "12345",
                    Currency = "Bolivianos",
                    HasDebt = false
                };

                mock.Setup(m => m.Save(provider)).Returns(provider);

                ProvidersController controller = new ProvidersController(mock.Object);

                //Act
                Provider actual = (Provider)controller.Save(provider).Model;

                //Assert
                Assert.IsTrue(provider.Id > 0);
            }
            catch (Exception e)
            {
                Assert.Fail("Fallo la prueba: " + e.Message);
            }
        }

        [TestMethod]
        public void B_Provider_Delete()
        {
            try
            {
                //Arrange
                Mock<IProviderRepository> mock = new Mock<IProviderRepository>();

                Provider provider = new Provider()
                {
                    Id = 1,
                    Name = "Coca Cola",
                    PhoneNumber = "12345",
                    Currency = "Bolivianos",
                    HasDebt = false
                };

                mock.Setup(m => m.Save(provider)).Returns(provider);
                mock.Setup(m => m.Delete(provider));

                ProvidersController controller = new ProvidersController(mock.Object);

                //Act
                Provider actual = new Provider();
                mock.Setup(m => m.FindById(provider.Id)).Returns(actual);

                //Assert
                Assert.IsFalse(actual.Id > 0);
            }
            catch (Exception e)
            {
                Assert.Fail("Fallo la prueba: " + e.Message);
            }
        }


    }
}
