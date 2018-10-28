using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class ClientInformation : IClientInformation
    {
        public ClientInformation()
        {
            UniqueID = Guid.NewGuid();
            packet = new Packet();
        }
        public IPacket packet;
        public Guid UniqueID { get;}
    }
}
