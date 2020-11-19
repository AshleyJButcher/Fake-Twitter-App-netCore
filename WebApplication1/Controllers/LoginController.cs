using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloneAPI.Models;
using Microsoft.AspNetCore.Mvc;
using TwitterCloneAPI.Misc;

namespace TwitterCloneAPI.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]clientLoginModel value)
        {
            LoginCheck checkLogin = new LoginCheck();
            clientUser clientUserModel = checkLogin.Check(value);
            if(clientUserModel != null)
            {
                return Ok(clientUserModel);
            } else
            {
                return BadRequest(new serverErrorModel() { Message = "Invalid Username or Password" });
            }
            
        }

    }
}
