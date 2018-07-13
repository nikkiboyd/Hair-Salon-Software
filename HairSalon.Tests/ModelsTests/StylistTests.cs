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

        [TestMethod]
        public void GetClients_RetrievesAllClientsByStylist_ClientList()
        {
            Stylist newStylist = new Stylist(1, "Margot Tenenbaum");

            Client firstClient = new Client(1, "test name", "test phone", "test email");
            firstClient.Save();

            Client secondClient = new Client(1, "test name", "test phone", "test email");
            secondClient.Save();

            List<Client> testClientList = new List<Client> { firstClient, secondClient };
            List<Client> result = newStylist.GetClientsByStylist(1);

            CollectionAssert.AreEqual(testClientList, result);
        }
    }
}