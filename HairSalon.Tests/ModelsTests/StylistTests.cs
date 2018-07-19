using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTests : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
        }

        public StylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=nikki_boyd_test;";
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfStylitsAreTheSame_True()
        {
            Stylist firstStylist = new Stylist("test name");
            Stylist secondStylist = new Stylist("test name");

            Assert.AreEqual(firstStylist, secondStylist);
        }

        [TestMethod]
        public void GetClients_RetrievesAllClientsByStylist_ClientList()
        {
            Stylist newStylist = new Stylist("Margot Tenenbaum");

            Client firstClient = new Client(1, "test name", "test phone", "test email");
            firstClient.Save();

            Client secondClient = new Client(1, "test name", "test phone", "test email");
            secondClient.Save();

            List<Client> testClientList = new List<Client> { firstClient, secondClient };
            List<Client> result = Stylist.GetClientsByStylist(1);

            CollectionAssert.AreEqual(testClientList, result);
        }

        [TestMethod]
        public void GetAll_GetsAllStylistsFromDatabase_StylistList()
        {
            int result = Stylist.GetAll().Count;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Find_FindsStylistInDatabase_Stylist()
        {
            Stylist newStylist = new Stylist("Margot Tenenbaum");
            newStylist.Save();
            Stylist result = Stylist.Find(newStylist.StylistId);

            Assert.AreEqual(newStylist, result);
        }

        [TestMethod]
        public void Save_SavesToDatabase_ClientList()
        {
            Stylist newStylist = new Stylist("test name");

            newStylist.Save();
            int result = Stylist.GetAll().Count;
            List<Stylist> testStylistList = new List<Stylist> { newStylist };

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Update_UpdatesStylistInDatabase_UpdatedStylist()
        {
            Stylist newStylist = new Stylist("Margot Tenenbaum");
            newStylist.Save();
            newStylist.Update("Nikki Boyd");
            string result = Stylist.Find(newStylist.StylistId).StylistName;
            Assert.AreEqual(result, "Nikki Boyd");
        }

        [TestMethod]
        public void Delete_DeletesSingleStylistFromDatabase_FirstStylist()
        {
            Stylist firstStylist = new Stylist("Margot Tenenbaum");
            firstStylist.Save();
            Stylist secondStylist = new Stylist("Nikki Boyd");
            secondStylist.Save();
            firstStylist.Delete();

            List<Stylist> stylistList = new List<Stylist> { secondStylist };
            List<Stylist> result = new List<Stylist> { secondStylist };

            CollectionAssert.AreEqual(result, stylistList);
        }
    }
}