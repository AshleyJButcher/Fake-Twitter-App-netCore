using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloneAPI.DataSource;
using TwitterCloneAPI.Interfaces;
using TwitterCloneAPI.Models;

namespace TwitterCloneAPI.Misc
{

    public  class LoginCheck
    {


        public clientUser Check(clientLoginModel user)
        {
            var userModel = Startup.thesource.GetUser(user.Username, user.Password);
            return userModel;
        }

    }
}
