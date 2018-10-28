using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class SocketClientConnection : ISocketClientConnection 
    {
        public SocketClientConnection(IClientInformation clientInfo)
        {
            clientInformation = clientInfo;
        }
        public IClientInformation clientInformation { get; set; }
        public ISocket userSocket { get; set; }
        public IPacket packet { get; set; }
    }
}
