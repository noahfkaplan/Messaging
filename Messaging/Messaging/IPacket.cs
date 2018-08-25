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
        string Message { get; }
    }
}
