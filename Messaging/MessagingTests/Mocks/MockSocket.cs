using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingTests.Mocks
{
    public class MockSocket : ISocket
    {
        public void Bind()
        {
            throw new NotImplementedException();
        }

        public void Listen(int backlog)
        {
            throw new NotImplementedException();
        }

        public void BeginAccept(AsyncCallback AcceptCallback, object State)
        {
            throw new NotImplementedException();
        }

        public void EndAccept(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void BeginReceive(ISocketClientConnection connectionInfo, AsyncCallback AcceptCallback, object State)
        {
            throw new NotImplementedException();
        }

        public void EndRecieve(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void BeginSend(ISocketClientConnection connectionInfo, AsyncCallback AcceptCallback, object State)
        {
            throw new NotImplementedException();
        }

        public void EndSend(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
    }
}
