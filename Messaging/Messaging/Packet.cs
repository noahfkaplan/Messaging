using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class Packet : IPacket
    {
        public int bufferSize { get; set; }
        public int offset { get; set; }
        public byte[] buffer { get; set; }
        public IMessage message { get; set; }
        public Packet()
        {
            bufferSize = 1024;
            offset = 0;
            buffer = new byte[bufferSize];
        }
        public bool CreatePacket(string body, Guid recipientID, Guid senderID)
        {
            body = body.Replace('|', '/');
            string StringPayload = body + "|" + recipientID + "|" + senderID; 
            byte[] tempBuffer = Encoding.ASCII.GetBytes(StringPayload);
            if (tempBuffer.Length < bufferSize)
            {
                buffer = tempBuffer;
                return true;
            }
            else
            {
                return false;
                //probably should log this when I implement logging
            }
        }
        public bool CreateMessage()
        {
            if (buffer == null || buffer.All(x => x == 0))
            {
                return false;
            }
            else { 
                string stringPacket = Encoding.ASCII.GetString(buffer);
                string[] delimitedPacket = stringPacket.Split('|');
                string payload = delimitedPacket[0];
                Guid RecipientID = Guid.Parse(delimitedPacket[1]);
                Guid SenderID = Guid.Parse(delimitedPacket[2]);
                message = new Message(SenderID, RecipientID, payload);
                return true;
            }
        }
    }
}
