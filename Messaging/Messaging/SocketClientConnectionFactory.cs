using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public static class SocketClientConnectionFactory
    {
        private static ISocketClientConnection _connection;
        public static ISocketClientConnection CreateClientConnection()
        {
            if(_connection != null)
            {
                return _connection;
            }
            ClientInformation client = new ClientInformation();
            _connection = new SocketClientConnection(client);
            return _connection;
        }
        public static void SetSocketClientConnection(ISocketClientConnection conn)
        {
            _connection = conn;
        }
    }
}
