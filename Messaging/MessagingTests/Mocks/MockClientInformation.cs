using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messaging;

namespace MessagingTests
{
    public class MockClientInformation : IClientInformation
    {
        public MockClientInformation()
        {
            Username = "TestUsername";
            Password = "TestPassword";
            UniqueID = Guid.NewGuid();
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid UniqueID { get; }
    }
}
