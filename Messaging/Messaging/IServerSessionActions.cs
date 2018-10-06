using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    interface IServerSessionActions
    {
        int Bind();
        int ListenForConnection();
        int AcceptConnection();
        int ReceiveMessage(ISocketClientConnection user);
        int SendMessage(ISocketClientConnection toUser, ISocketClientConnection fromUser);

    }
}
