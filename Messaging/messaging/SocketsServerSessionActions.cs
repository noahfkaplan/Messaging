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
            SocketFactory factory = new SocketFactory();//might need to be refactored to inject this. Future
            _ServerSocket = factory.CreateSocket();
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

        private void AcceptCallback(IAsyncResult result)
        {
            IClientInformation userInformation = result as IClientInformation;
            ISocketClientConnection user = _SessionMembers.Find(x => x.clientInformation.UniqueID == userInformation.UniqueID);
            user.userSocket = _ServerSocket.EndAccept(result);
            ReceiveMessage(user);
        }

        public int ReceiveMessage(ISocketClientConnection user)
        {
            user.userSocket.BeginReceive(user, ReceiveCallback,user.clientInformation);
            return 1;
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            IClientInformation userInformation = result as IClientInformation;
            ISocketClientConnection fromUser = _SessionMembers.Find(x => x.clientInformation.UniqueID == userInformation.UniqueID);
            fromUser.userSocket.EndRecieve(result);
            bool successfulMessage = fromUser.packet.CreateMessage();
            if (successfulMessage)
            {
                try
                {
                    ISocketClientConnection toUser = _SessionMembers.Find(x => x.clientInformation.UniqueID == fromUser.packet.message.RecipientID);
                    SendMessage(toUser, fromUser);
                }
                catch (ArgumentNullException)
                {
                    //log when I get logging implemented
                }
            }
            fromUser.userSocket.BeginReceive(fromUser, ReceiveCallback, fromUser.clientInformation);
        }

        public int SendMessage(ISocketClientConnection toUser, ISocketClientConnection fromUser)
        {
            toUser.userSocket.BeginSend(fromUser, SendCallback, toUser.clientInformation);
            return 1;
        }
        private void SendCallback(IAsyncResult result)
        {
            IClientInformation toUserInformation = result as IClientInformation;
            ISocketClientConnection toUser = _SessionMembers.Find(x => x.clientInformation.UniqueID == toUserInformation.UniqueID);
            toUser.userSocket.EndSend(result);
        }
    }
}
