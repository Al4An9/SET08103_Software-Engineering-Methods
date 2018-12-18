using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation;

namespace BuildABikeTest
{
    [TestClass]
    public class BuildABikeTest
    {
        [TestMethod]
        public void BikeTotalCostCalculation()
        {
            //arrange
            int style = 20;
            int color = 20;
            int size = 100;
            int gear = 20;
            int saddle = 20;
            int handlebars = 20;
            int wheels = 30;
            int brakes = 20;
            int warranty = 50;
            int buildingandtesting = 100;
            int expectedTotalCost = 400;

            //act
            int totalCost = style + color + size + gear + saddle + handlebars + wheels + brakes + warranty + buildingandtesting;
            //assert
            int actualTotalCost = totalCost;
            Assert.AreEqual(expectedTotalCost, actualTotalCost, 400, "Total cost is correct");
        }
        [TestMethod]
        public void BikeTotalTimeScale()
        {
            //arrange
            int buildingAndTesting = 1;
            int daysForRestock = 7;
            int expectedTimeScale= 8;
            

            //act
            int timeEstimated = buildingAndTesting + daysForRestock;

            //assert
            int actualTimeScale = timeEstimated;
            Assert.AreEqual(expectedTimeScale, actualTimeScale, 8, "Timescale is correct");
        }
    }
}
