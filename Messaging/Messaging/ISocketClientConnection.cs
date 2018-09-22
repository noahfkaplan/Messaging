using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public interface ISocketClientConnection : IClientConnection
    {
        int bufferSize { get; }
        int offset { get; }
        byte[] buffer { get; }
        ISocket userSocket { get; set; }
    }
}
