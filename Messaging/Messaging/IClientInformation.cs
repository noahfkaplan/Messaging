using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public interface IClientInformation
    {
        string Username { get; set; }
        string Password { get; set; }
        Guid UniqueID { get; }
    }
}
