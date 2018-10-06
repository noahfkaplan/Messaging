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
        private Socket _socket { get; set; }
        public MySocket(Socket soc)
        {
            _socket = soc;
        }
        public void BeginAccept(AsyncCallback AcceptCallback, object State)
        {
            _socket.BeginAccept(AcceptCallback, State);
        }

        public void BeginReceive(ISocketClientConnection connectionInfo, AsyncCallback AcceptCallback, object State)
        {
            _socket.BeginReceive(connectionInfo.packet.buffer,connectionInfo.packet.offset, connectionInfo.packet.bufferSize, SocketFlags.None, AcceptCallback,State);
        }

        public void BeginSend(ISocketClientConnection connectionInfo, AsyncCallback AcceptCallback, object State)
        {
            _socket.BeginSend(connectionInfo.packet.buffer, connectionInfo.packet.offset, connectionInfo.packet.bufferSize, SocketFlags.None, AcceptCallback, State);
        }

        public void Bind()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Parse(ConfigurationManager.AppSettings["IPAddress"]);
            int portNumber = int.Parse(ConfigurationManager.AppSettings["PortNumber"]);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, portNumber);
            _socket.Bind(localEndPoint);
        }

        public ISocket EndAccept(IAsyncResult result)
        {
            ISocket client;
            Socket temp = _socket.EndAccept(result);
            client = new MySocket(temp);
            return client;

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
