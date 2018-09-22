using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class SocketsServerSessionActions : IServerSessionActions
    {
        private List<ISocketClientConnection> _SessionMembers;
        private ISocket _MainServerSocket;

        public SocketsServerSessionActions()
        {
            _MainServerSocket = SocketFactory.CreateSocket();
        }

        public int Bind()
        {
            _MainServerSocket.Bind();
            return 1; //success, if logic to check for failed listen, return zero. future
        }

        public int ListenForConnection()
        {
            _MainServerSocket.Listen(50);//stop hard code in future
            return 1; //success, if logic to check for failed listen, return zero. future
        }

        public int AcceptConnection()
        {
            throw new NotImplementedException();
        }

        public int ReceiveMessage()
        {
            throw new NotImplementedException();
        }

        public int SendMessage()
        {
            throw new NotImplementedException();
        }
    }
}
