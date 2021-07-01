using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarNS;
using System;

namespace CarTests
{
    [TestClass]
    public class CarTests
    {
        Car car1;

        [TestInitialize]
        public void InitializeObject()
        {
            car1 = new Car("Toyota", "Camry", 30, 45);

        }

        [TestCleanup]
        public void CleanUp()
        {
            car1 = null;
        }


        //TODO: add emptyTest so we can configure our runtime environment (remove this test before pushing to your personal GitHub account)
        [TestMethod]
        public static void emptyTest()
        {
            Assert.AreEqual(1, 1, .01);
        }

        //TODO: constructor sets gasTankLevel properly
        [TestMethod]
        public void GasTankLevelSetProperly()
        {
            
            Assert.AreEqual(30, car1.GasTankSize, .1);
            
        }
        //TODO: gasTankLevel is accurate after driving within tank range
        [TestMethod]
        public void GasTankLevelWithinTankRange()
        {
         

            double totalRange = 1350;

            car1.Drive(50);
            
            Assert.AreEqual(1300, car1.GasTankLevel, .1);
        }
        //TODO: gasTankLevel is accurate after attempting to drive past tank range
        [TestMethod]
        public void GasTankLevelPastRange()
        {
           
            double totalRange = car1.GasTankSize * car1.MilesPerGallon;

            Assert.IsTrue(totalRange < 1400);
        }
        //TODO: can't have more gas than tank size, expect an exception
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GasOverTankSize()
        {
            

            car1.AddGas(5);

            Assert.Fail("Shouldn\'t get here, car cannot have more gas in tank than the size of the tank");

        }

    }
}
