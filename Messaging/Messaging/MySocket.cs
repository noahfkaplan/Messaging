using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class MySocket : ISocket
    {
        Socket _socket;
        public MySocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void BeginAccept(AsyncCallback AcceptCallback, object State)
        {
            _socket.BeginAccept(AcceptCallback, State);
        }

        public void BeginReceive(ISocketClientConnection connectionInfo, AsyncCallback AcceptCallback, object State)
        {
            _socket.BeginReceive(connectionInfo.buffer,connectionInfo.offset, connectionInfo.bufferSize, SocketFlags.None, AcceptCallback,State);
        }

        public void BeginSend(ISocketClientConnection connectionInfo, AsyncCallback AcceptCallback, object State)
        {
            _socket.BeginSend(connectionInfo.buffer, connectionInfo.offset, connectionInfo.bufferSize, SocketFlags.None, AcceptCallback, State);
        }

        public void Bind()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Parse(ConfigurationManager.AppSettings["IPAddress"]);
            int portNumber = int.Parse(ConfigurationManager.AppSettings["PortNumber"]);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, portNumber);
            _socket.Bind(localEndPoint);
        }

        public void EndAccept(IAsyncResult result)
        {
            _socket.EndAccept(result);
        }

        public void EndRecieve(IAsyncResult result)
        {
            _socket.EndReceive(result);
        }

        public void EndSend(IAsyncResult result)
        {
            _socket.EndSend(result);
        }

        public void Listen(int backlog)
        {
            _socket.Listen(backlog);
        }
    }
}
