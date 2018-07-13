using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTests : IDisposable
    {

        public void Dispose()
        {
            Client.DeleteAll();
        }

        public ClientTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=nikki_boyd_test;";
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfDetailsAreTheSame_True()
        {
            Client firstClient = new Client(1, "test name", "test phone", "test email");
            Client secondClient = new Client(1, "test name", "test phone", "test email");

            Assert.AreEqual(firstClient, secondClient);
        }

        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
            int result = Client.GetAll().Count;
            Assert.AreEqual(0, result);
        }
    }
}
