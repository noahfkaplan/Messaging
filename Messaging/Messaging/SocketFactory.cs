using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class SocketFactory
    {
        private ISocket _socket;
        public SocketFactory()
        {
            _socket = null;
        }
        public ISocket CreateSocket()
        {
            if(_socket != null)
            {
                return _socket;
            }
            var CSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket = new MySocket(CSocket);
            return _socket;
        }
        public void setSocket(ISocket soc)
        {
            _socket = soc;
        }
    }
}
