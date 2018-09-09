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
        private List<IClientConnection> _SessionMembers;
        private Socket _socket;

        public SocketsServerSessionActions()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public int AcceptConnection()
        {
            throw new NotImplementedException();
        }

        public int Bind()
        {
            throw new NotImplementedException();
        }

        public int Listen()
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
