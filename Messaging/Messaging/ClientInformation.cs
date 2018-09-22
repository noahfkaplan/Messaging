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
            UniqueID = new Guid();
      
        }
        public Guid UniqueID { get;}
    }
}
