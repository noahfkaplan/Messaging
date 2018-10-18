using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public interface ISocketClientConnection : IClientConnection
    {
        IPacket packet { get; set; }
        ISocket userSocket { get; set; }
    }
}
