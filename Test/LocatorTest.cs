using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Customers;
using Customers.Entity;

namespace Test
{
    [TestClass]
    public class LocatorTest
    {
        public const double Threshold = 0.001;

        [TestMethod]
        public void GetRadiansTestZero() => Assert.AreEqual(0, Locator.GetRadians(0));

        [TestMethod]
        public void GetRadiansTestOne() => Assert.IsTrue(Math.Abs(0.0174 - Locator.GetRadians(1)) < Threshold);


        [TestMethod]
        public void GetDistanceBetweenTestGalwayMinsk() =>
            Assert.IsTrue(Math.Abs(2381.56 - Locator.GetDistanceBetween(new Location(53.2836565, -9.0379137), new Location(53.882887, 27.4301247))) < Threshold);

        [TestMethod]
        public void GetDistanceBetweenTestDublinSanFrancisco() =>
            Assert.IsTrue(Math.Abs(8184.336 - Locator.GetDistanceBetween(new Location(53.3394238, -6.2583594), new Location(37.434637, -121.9223545))) < Threshold);
    }
}
