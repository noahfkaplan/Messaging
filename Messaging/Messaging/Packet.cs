using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class Packet : IPacket
    {
        public string Message { get; set; }
        private int bufferSize = 1024;
        public bool CreatePacket(string body, Guid recipientID, Guid senderID)
        {
            if(body.ToCharArray().Length > bufferSize)
            {
                return false;
            }
            else
            {
                Message = recipientID + "$" + body + "$" + senderID;
                return true;
            }
        }
    }
}
