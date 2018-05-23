using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace SportsStore.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : Abstract.IAuthProvider
    {
        public bool Authenticate(string userName, string userPass)
        {
            var result = FormsAuthentication.Authenticate(userName, userPass);
            if (result)
                FormsAuthentication.SetAuthCookie(userName, false);

            return result;
        }
    }
}