using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTests : IDisposable
    {
        public StylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=nikki_boyd_test;";
        }

        public void Dispose()
        {
            Stylist.DeleteAll();
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfStylitsAreTheSame_True()
        {
            Stylist firstStylist = new Stylist(1, "test name");
            Stylist secondStylist = new Stylist(1, "test name");

            Assert.AreEqual(firstStylist, secondStylist);
        }
    }
}