using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Auth
{
    public class PlainAuthentication : IAuthenticate
    {
        public bool isAuthenticated(string userName, string password)
        {
            if (userName == "CREDIMON" && password == "Credimon206*")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
