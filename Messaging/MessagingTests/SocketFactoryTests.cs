using Messaging;
using MessagingTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingTests
{
    [TestClass]
    public class SocketFactoryTests
    {
        [TestMethod]
        public void SocketFactory_WithNoSetting_ReturnsMySocket()
        {
            //arrange
            ISocket socket;
            //act
            socket = SocketFactory.CreateSocket();
            //assert
            Assert.IsInstanceOfType(socket, typeof(MySocket));
        }
        [TestMethod]
        public void SocketFactory_WithValidSetting_ReturnsSetSocket()
        {
            //arrange
            ISocket mockSocket = new MockSocket();
            SocketFactory.setSocket(mockSocket);
            //act
            ISocket resultSocket = SocketFactory.CreateSocket();
            //assert
            Assert.IsTrue(resultSocket == mockSocket);
            //cleanup
            SocketFactory.setSocket(null);
        }
    }
}
