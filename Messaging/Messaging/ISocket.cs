using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public interface ISocket
    {
        void Bind();
        void Listen(int backlog);
        void BeginAccept(AsyncCallback AcceptCallback, object State);
        ISocket EndAccept(IAsyncResult result);
        void BeginReceive(ISocketClientConnection connectionInfo, AsyncCallback AcceptCallback, object State);
        void EndRecieve(IAsyncResult result);
        void BeginSend(ISocketClientConnection connectionInfo, AsyncCallback AcceptCallback, object State);
        void EndSend(IAsyncResult result);
        
    }
}
