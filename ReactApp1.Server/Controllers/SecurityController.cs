using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        [HttpGet("protected")]
        public ActionResult<string> ProtectedEndpoint()
        {
            dynamic user = HttpContext.Items["User"];
            if (user == null) return Unauthorized("Invalid Token");
            var name = user.Name;
            var fullname = user.Fullname;
            return Ok($"Hello {name}, {fullname} you are authenticated!");
        }
    }
}

