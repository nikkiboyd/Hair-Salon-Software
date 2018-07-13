using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTests
    {
        public StylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=nikki_boyd_test;";
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

        [TestMethod]
        public void GetAll_GetsAllStylistsFromDatabase_StylistList()
        {
            int result = Stylist.GetAll().Count;
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Find_FindsStylistInDatabase_Stylist()
        {
            Stylist foundStylist = Stylist.Find(1);
            string name = foundStylist.StylistName;

            Assert.AreEqual("Margot Tenenbaum", name);
        }

        [TestMethod]
        public void Save_SavesToDatabase_ClientList()
        {
            Stylist newStylist = new Stylist(1, "test name");

            newStylist.Save();`
            int result = Stylist.GetAll().Count;
            List<Stylist> testStylistList = new List<Stylist> { newStylist };

            Assert.AreEqual(9, result);
        }
    }
}