using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using Simulate_Fishing;

namespace UnitTestFishing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_positive_fish_location_x()
        {
            // Arrange

            var form = new Form1();
            Point test_position_x = new Point(20,400);

            // Assert

            Assert.AreEqual(test_position_x.X, form.fish_position_p.X);


        }

        [TestMethod]
        public void Test_positive_fish_location_y()
        {
            // Arrange

            var form = new Form1();
            Point test_position_y = new Point(20, 400);

            // Assert

            Assert.AreEqual(test_position_y.Y, form.fish_position_p.Y);
        }


        [TestMethod]
        public void Test_neagtive_fish_location_x()
        {
            // Arrange

            var form = new Form1();
            Point test_position_x = new Point(20, 250);

            // Assert

            Assert.AreEqual(test_position_x.X, form.fish_position_n.X);


        }

        [TestMethod]
        public void Test_negative_fish_location_y()
        {
            // Arrange

            var form = new Form1();
            Point test_position_y = new Point(20, 250);

            // Assert

            Assert.AreEqual(test_position_y.Y, form.fish_position_n.Y);
        }
    }
}
