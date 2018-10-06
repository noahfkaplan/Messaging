using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class Message : IMessage
    {
        public Guid SenderID { get; }
        public Guid RecipientID { get; }
        public string Payload { get; }
        public Message(Guid sender, Guid recipient, string payload)
        {
            SenderID = sender;
            RecipientID = recipient;
            Payload = payload;
        }
    }
}
