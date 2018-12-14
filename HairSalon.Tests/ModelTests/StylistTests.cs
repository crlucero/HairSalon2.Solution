using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;
 
namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTest : IDisposable
    {
        public StylistTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=cristian_lucero_test;";
        }
        public void Dispose()
        {
            Stylist.ClearAll();
            Client.ClearAll();
        }

        [TestMethod]
        public void StylistConstructor_CreatesInstanceofStylist_Stylist()
        {
            Stylist newStylist = new Stylist("test stylist");
            Assert.AreEqual(typeof(Stylist), newStylist.GetType());
        }

        [TestMethod]
        public void GetName_ReturnsName_String()
        {
            //Arrange
            string name = "Stylist 1";
            Stylist newStylist = new Stylist(name);

            //Act
            string result = newStylist.GetName();

            //Assert
            Assert.AreEqual(name, result);
        }

        [TestMethod]
        public void Save_DatabaseAssignsIdToStylist_Id()
        {
            //Arrange
            Stylist testStylist = new Stylist("Stylist 1");
            testStylist.Save();

            //Act
            Stylist savedStylist = Stylist.GetAll()[0];

            int result = savedStylist.GetId();
            int testId = testStylist.GetId();

            //Assert
            Assert.AreEqual(testId, result);

        }

        [TestMethod]
        public void Save_SavesStylistToDatabase_StylistList()
        {
            //Arrange
            Stylist testStylist = new Stylist("Stylist 1");
            testStylist.Save();

            //Act
            List<Stylist> result = Stylist.GetAll();
            List<Stylist> testList = new List<Stylist> { testStylist };

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void GetAll_ReturnsAllStylistObjects_StylistList()
        {
            //Arrange
            string name01 = "stylist1";
            string name02 = "stylist2";
            Stylist newStylist1 = new Stylist(name01);
            newStylist1.Save();
            Stylist newStylist2 = new Stylist(name02);
            newStylist2.Save();
            List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };

            //Act
            List<Stylist> result = Stylist.GetAll();

            //Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Find_ReturnsStylistInDatabase_Stylist()
        {
            //Arrange
            Stylist testStylist = new Stylist("stylist 1");
            testStylist.Save();

            //Act
            Stylist foundStylist = Stylist.Find(testStylist.GetId());

            //Assert
            Assert.AreEqual(testStylist, foundStylist);
        }

        [TestMethod]
        public void GetClients_ReturnsEmptyClientList_ClientList()
        {
            //Arrange
            string name = "client";
            Stylist newStylist = new Stylist(name);
            List<Client> newList = new List<Client> { };

            //Act
            List<Client> result = newStylist.GetClients();

            //Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfNamesAreTheSame_Stylist()
        {
            //Arrange, Act
            Stylist firstStylist = new Stylist("stylist1");
            Stylist secondStylist = new Stylist("stylist1");

            //Assert
            Assert.AreEqual(firstStylist, secondStylist);
        }

        [TestMethod]
        public void GetClients_RetrievesAllClientsWithStylist_ItemList()
        {
            //Arrange, Act
            Stylist testStylist = new Stylist("stylist1", 1);
            testStylist.Save();
            Client firstClient = new Client("client1", testStylist.GetId());
            firstClient.Save();
            Client secondClient = new Client("client2", testStylist.GetId());
            secondClient.Save();
            List<Client> testClientList = new List<Client> { firstClient, secondClient };
            List<Client> resultClientList = testStylist.GetClients();

            //Assert
            CollectionAssert.AreEqual(testClientList, resultClientList);
        }

        [TestMethod]
        public void GetAll_StylistsEmptyAtFirst_List()
        {
            //Arrange, Act
            int result = Stylist.GetAll().Count;

            //Assert
            Assert.AreEqual(0, result);
        }
    }
 
}
