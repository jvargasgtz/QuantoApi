using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Auth
{
    interface IAuthenticate
    {
        bool isAuthenticated(string userName, string password);
    }
}
