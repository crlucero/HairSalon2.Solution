using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtyTest : IDisposable
    {

        public void Dispose()
        {
            Client.ClearAll();
            Stylist.ClearAll();
            Specialty.ClearAll();
            
        }

        public SpecialtyTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=cristian_lucero_test;";
        }

        [TestMethod]
        public void GetAll_GetsAllSpecialties_List()
        {
            string name01 = "specialty1";
            string name02 = "specialty2";
            Specialty newSpecialty1 = new Specialty(name01);
            newSpecialty1.Save();
            Specialty newSpecialty2 = new Specialty(name02);
            newSpecialty2.Save();
            List<Specialty> newList = new List<Specialty> { newSpecialty1, newSpecialty2 };

            //Act
            List<Specialty> result = Specialty.GetAll();

            //Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void AddStylist_AddsAStylistToASpecialty()
        {
            Stylist newStylist = new Stylist("Stylist 1");
            newStylist.Save();
            Specialty newSpecialty = new Specialty("Men's cuts");
            newSpecialty.Save();
            newStylist.AddSpecialty(newSpecialty);
            Assert.AreEqual(newSpecialty, newStylist.GetSpecialties()[0]);
        }

    }
}