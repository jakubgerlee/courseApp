using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Register.Business.Layer.Service;

namespace Register.Business.Layer.Test
{
    [TestClass]
    public class RaportServiceTests
    {
        [TestMethod]
        public void WhenCheckingIfParcentIsHiher_GiveParcentAndThreshold_ReturnHiger()
        {
            //Arrange
            string higer = "zaliczone";
            int parcent = 80;
            int threshold = 70;
            RaportService raportService = new RaportService();

            //Act
            var result =
                raportService.CheckIfResultsIsHigherThanThreshold(parcent, threshold);
            
            //Assert
            Assert.AreSame(higer, result);
        }

        [TestMethod]
        public void WhenCheckingIfParcentIsLower_GiveParcentAndThreshold_ReturnLower()
        {
            //Arrange
            string lower = "niezaliczone";
            int parcent = 60;
            int threshold = 70;
            RaportService raportService = new RaportService();

            //Act
            var result =
                raportService.CheckIfResultsIsHigherThanThreshold(parcent, threshold);

            //Assert
            Assert.AreSame(lower, result);
        }

        [TestMethod]
        public void CalculateParcent_GiveMaxPointsAndPoints_ReturnCalculateParcent()
        {
            //Arrange
            int maxPoints = 100;
            int points = 70;
            RaportService raportService = new RaportService();

            //Act
            var result =
                raportService.CheckHowManyParcent(maxPoints, points);

            //Assert
            Assert.AreEqual(70, result);
        }

    }
}
