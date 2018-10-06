using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public interface IPacket
    {
        bool CreatePacket(string body, Guid recipientID, Guid senderID);
        bool CreateMessage();
        int bufferSize { get; set; }
        int offset { get; set; }
        byte[] buffer { get; set; }
        IMessage message { get; }
    }
}
