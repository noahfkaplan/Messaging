using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Messaging;

namespace MessagingTests
{
    [TestClass]
    public class ClientInformationTests
    {
        
        [TestMethod]
        public void CanUpdateUserName()
        {
            var client = new ClientInformation();
            client.Username = "TestUsername";
            Assert.AreEqual(client.Username, "TestUsername");
        }
        [TestMethod]
        public void CanUpdatePassword()
        {
            var client = new ClientInformation();
            client.Password = "TestPassword";
            Assert.AreEqual(client.Password, "TestPassword");
        }
        [TestMethod]
        public void DefaultsUsernameToUndefined()
        {
            var client = new ClientInformation();
            Assert.AreEqual(client.Username, "Unassigned");
        }
        [TestMethod]
        public void DefaultsPasswordToPassword()
        {
            var client = new ClientInformation();
            Assert.AreEqual(client.Password, "Password");
        }
        
    }
}
