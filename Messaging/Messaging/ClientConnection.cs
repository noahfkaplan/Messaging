using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class SocketClientConnection : IClientConnection, ISocketClientConnection 
    {
        public SocketClientConnection(IClientInformation clientInfo)
        {

            bufferSize = 1024;
            clientInformation = clientInfo;
            userSocket = SocketFactory.CreateSocket();
        }
        public int bufferSize { get; }
        public IClientInformation clientInformation { get; set; }
        public ISocket userSocket { get; }
        public int offset { get; set; }
        public byte[] buffer { get; set; }
    }
}
