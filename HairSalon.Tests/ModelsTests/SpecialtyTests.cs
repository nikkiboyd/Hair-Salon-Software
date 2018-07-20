using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtyTests : IDisposable
    {
        public void Dispose()
        {
            Specialty.DeleteAll();
        }

        public SpecialtyTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=nikki_boyd_test;";
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfSpecialtiesAreTheSame_True()
        {
            Specialty firstSpecialty = new Specialty("test specialty");
            Specialty secondSpecialty = new Specialty("test specialty");
            Assert.AreEqual(firstSpecialty, secondSpecialty);
        }

        [TestMethod]
        public void GetAll_GetsAllSpecialtiesFromDatabase_List()
        {
            int result = Specialty.GetAll().Count;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Find_FindsSpecialtyInDatabase_Specialty()
        {
            Specialty newSpecialty = new Specialty("Balayage");
            newSpecialty.Save();
            Specialty result = Specialty.Find(newSpecialty.SpecialtyId);
            Assert.AreEqual(newSpecialty, result);
        }

        [TestMethod]
        public void Save_SavesToDatabase_List()
        {
            Specialty newSpecialty = new Specialty("Balayage");
            newSpecialty.Save();
            int result = Specialty.GetAll().Count;
            List<Specialty> specialtyList = new List<Specialty> { newSpecialty };
            Assert.AreEqual(1, result);
        }
    }
}
