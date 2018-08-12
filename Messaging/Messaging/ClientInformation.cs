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
            Username = "Unassigned";
            Password = "Password";
            UniqueID = new Guid();
      
        }
        public ClientInformation(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid UniqueID { get;}
    }
}
