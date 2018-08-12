using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class ClientConnection : IClientConnection
    {
        public ClientConnection(IClientInformation clientInfo)
        {
            bufferSize = 1024;
            clientInformation = clientInfo;
        }
        public int bufferSize { get; }
        public IClientInformation clientInformation { get; set; }
    }
}
