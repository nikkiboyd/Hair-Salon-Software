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
    }
}
