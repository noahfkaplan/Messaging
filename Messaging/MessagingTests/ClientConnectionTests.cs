using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messaging;

namespace MessagingTests
{
    [TestClass]
    public class ClientConnectionTests
    {
        [TestMethod]
        public void StoresAClientConnection()
        {
            var client = new ClientConnection(new MockClientInformation());
            Assert.AreEqual(client.clientInformation.Username, "TestUsername");
        }
        [TestMethod]
        public void StoresAClientPassword()
        {
            var client = new ClientConnection(new MockClientInformation());
            Assert.AreEqual(client.clientInformation.Password, "TestPassword");
        }
        public void SetsBufferSizeTo1024()
        {
            var client = new ClientConnection(new MockClientInformation());
            Assert.AreEqual(client.bufferSize, 1024);
        }
    }
}
