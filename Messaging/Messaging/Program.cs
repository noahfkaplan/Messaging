using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    class Program
    {
        public static int Main()
        {
            try
            {
                SocketsServerSessionActions server = new SocketsServerSessionActions();
                server.Bind();
                server.ListenForConnection();
                server.AcceptConnection();
            }
            catch(Exception e)
            {
                Console.WriteLine("Connection Lost with clients");
            }
            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}
