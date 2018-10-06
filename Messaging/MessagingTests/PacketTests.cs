using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Messaging;
using MessagingTests.Mocks;

namespace MessagingTests
{
    [TestClass]
    public class PacketTests
    {
        [TestMethod]
        public void CreateMessage_GivenEmptyBuffer_ReturnsFalse()
        {
            var packet = new Packet();
            bool result = packet.CreateMessage();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CreateMessage_GivenNullBuffer_ReturnsFalse()
        {
            var packet = new Packet();
            packet.buffer = null;
            bool result = packet.CreateMessage();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreateMessage_GivenValidPacket_ReturnsTrue()
        {
            IMessage mockMessage = new MockMessage();
            var packet = new Packet();
            string testPayload = "Test Message|A3C6B524-1BE1-4D9D-84FB-EF64993CCA28|97846D61-1CA0-49BD-8E79-AE3AF6373B26";
            packet.buffer = Encoding.ASCII.GetBytes(testPayload);

            packet.CreateMessage();

            Assert.IsTrue(mockMessage.Equals(packet.message));
        }
        

       [TestMethod]
        public void CreatePacket_GivenValidMessageLength_ReturnsTrue()
        {
            var packet = new Packet();
            Guid senderID = Guid.NewGuid();
            Guid recipientID = Guid.NewGuid();
            bool result = packet.CreatePacket("MessageBodyUnder1024Characters",senderID,recipientID);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CreatePacket_GivenInvalidMessageLength_ReturnsFalse()
        {
            var packet = new Packet();
            Guid senderID = Guid.NewGuid();
            Guid recipientID = Guid.NewGuid();
            bool result = packet.CreatePacket("MessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024CharactersMessageBodyOver1024Characters", senderID, recipientID);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CreatePacket_WithValidMessageFormat_IsSuccessful()
        {
            var packet = new Packet();
            string message = "Test Message";
            Guid senderID = Guid.NewGuid();
            Guid recipientID = Guid.NewGuid();

            packet.CreatePacket(message, recipientID, senderID);

            string stringPacket = Encoding.ASCII.GetString(packet.buffer);
            Assert.IsTrue(stringPacket.Contains(message));
        }
        [TestMethod]
        public void CreatePacket_GivenPipeCharacters_ReplacesPipeCharacters()
        {
            var packet = new Packet();
            string message = "test|Test|test";
            Guid senderID = Guid.NewGuid();
            Guid recipientID = Guid.NewGuid();

            packet.CreatePacket(message, recipientID, senderID);

            string stringPacket = Encoding.ASCII.GetString(packet.buffer);
            Assert.IsFalse(stringPacket.Contains(message));
        }
    }
}
