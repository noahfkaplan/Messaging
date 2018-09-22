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
        private ISocket _ServerSocket;

        public SocketsServerSessionActions()
        {
            _ServerSocket = SocketFactory.CreateSocket();
        }

        public int Bind()
        {
            _ServerSocket.Bind();
            return 1; //success, if logic to check for failed listen, return zero. future
        }

        public int ListenForConnection()
        {
            _ServerSocket.Listen(50);//stop hard code in future
            return 1; //success, if logic to check for failed listen, return zero. future
        }

        public int AcceptConnection()
        {
            ISocketClientConnection newUser = SocketClientConnectionFactory.CreateClientConnection();
            _SessionMembers.Add(newUser);
            _ServerSocket.BeginAccept(AcceptCallback, newUser.clientInformation);//create a better state object for information transfer. Future
            return 1; //success, if logic to check for failed listen, return zero. future
        }

        public void AcceptCallback(IAsyncResult result)
        {
            IClientInformation userInformation = result as IClientInformation;
            ISocketClientConnection user = _SessionMembers.Find(x => x.clientInformation.UniqueID == userInformation.UniqueID);
            user.userSocket = _ServerSocket.EndAccept(result);
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
