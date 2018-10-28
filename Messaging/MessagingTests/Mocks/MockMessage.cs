using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingTests.Mocks
{
    public class MockMessage : IMessage
    {
        public Guid RecipientID { get; set; }

        public Guid SenderID { get; set; }

        public string Payload { get; set; }

        public MockMessage()
        {
            Payload = "Test Message";
            RecipientID = Guid.Parse("A3C6B524-1BE1-4D9D-84FB-EF64993CCA28");
            SenderID = Guid.Parse("97846D61-1CA0-49BD-8E79-AE3AF6373B26");
        }
        public bool Equals(IMessage message)
        {
            bool one = RecipientID.Equals(message.RecipientID);
            bool two = SenderID.Equals(message.SenderID);
            bool three = Payload.Equals(message.Payload);

            if (RecipientID.Equals(message.RecipientID) && SenderID.Equals(message.SenderID) && Payload.Equals(message.Payload))
            {
                return true;
            }
            return false;
        }
    }
}
