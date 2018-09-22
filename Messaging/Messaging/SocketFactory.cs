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
        private static ISocket _socket = null;
        public static ISocket CreateSocket()
        {
            if(_socket != null)
            {
                return _socket;
            }
            _socket = new MySocket();
            return _socket;
        }
        public void setSocket(ISocket soc)
        {
            _socket = soc;
        }
    }
}
