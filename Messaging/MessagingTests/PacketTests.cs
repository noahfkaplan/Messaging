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
    public class PacketTests
    {
        [TestMethod]
        public void CreatePacket_GivenValidMessageLength_ReturnsTrue()
        {
            var packet = new Packet();
            Guid senderID = new Guid();
            Guid recipientID = new Guid();
            bool result = packet.CreatePacket("MessageBodyUnder1024Characters",senderID,recipientID);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CreatePacket_GivenInvalidMessageLength_ReturnsFalse()
        {
            var packet = new Packet();
            Guid senderID = new Guid();
            Guid recipientID = new Guid();
            bool result = packet.CreatePacket("MessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024Characters", senderID, recipientID);
            Assert.IsFalse(result);
        }
    }
}
