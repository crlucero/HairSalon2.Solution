using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTest : IDisposable
    {
        public ClientTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=cristian_lucero_test;";
        }
        public void Dispose()
        {
            Stylist.ClearAll();
            Client.ClearAll();
        }

        [TestMethod]
        public void ClientConstructor_CreatesInstanceOfClient_Client()
        {
            Client newClient = new Client("testClient", 1);
            Assert.AreEqual(typeof(Client), newClient.GetType());
        }

        [TestMethod]
        public void GetName_ReturnsName_String()
        {
            //Arrange
            string name = "ClientOne";
            Client newClient = new Client(name, 1);

            //Act
            string result = newClient.GetName();

            //Assert
            Assert.AreEqual(name, result);
        }

        [TestMethod]
        public void SetName_SetName_String()
        {
            //Arrange
            string name = "ClientOne";
            Client newClient = new Client(name, 1);

            //Act
            string updatedName = "Test client";
            newClient.SetName(updatedName);
            string result = newClient.GetName();

            //Assert
            Assert.AreEqual(updatedName, result);
        }

        [TestMethod]
        public void GetAll_ReturnsClients_ClientList()
        {
            //Arrange
            string name01 = "client1";
            string name02 = "client2";
            Client newClient1 = new Client(name01, 1);
            newClient1.Save();
            Client newClient2 = new Client(name02, 1);
            newClient2.Save();
            List<Client> newList = new List<Client> { newClient1, newClient2 };

            //Act
            List<Client> result = Client.GetAll();

            //Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Find_ReturnsCorrectClientFromDatabase_Client()
        {
            //Arrange
            Client testClient = new Client("client1", 1);
            testClient.Save();

            //Act
            Client foundClient = Client.Find(testClient.GetId());

            //Assert
            Assert.AreEqual(testClient, foundClient);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
        {
            // Arrange, Act
            Client firstClient = new Client("client3", 1);
            Client secondClient = new Client("client3", 1);

            // Assert
            Assert.AreEqual(firstClient, secondClient);
        }

        [TestMethod]
        public void Save_SavesToDatabase_ClientList()
        {
            //Arrange
            Client testClient = new Client("savannah", 1);

            //Act
            testClient.Save();
            List<Client> result = Client.GetAll();
            List<Client> testList = new List<Client> { testClient };

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_AssignsIdToObject_Id()
        {
            //Arrange
            Client testClient = new Client("savannah", 1);

            //Act
            testClient.Save();
            Client savedClient = Client.GetAll()[0];

            int result = savedClient.GetId();
            int testId = testClient.GetId();

            //Assert
            Assert.AreEqual(testId, result);
        }

    }
}