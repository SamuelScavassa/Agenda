using API.Services;
using AppAgendaAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppAgendaAPI.Controllers
{
    [ApiController]
    public class TokenController : ControllerBase
    {
        private DBAgenda db;
        public TokenController(DBAgenda db)
        {
            this.db = db;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task <IActionResult> Autenticar ([FromBody] User model)
        {
            var result = db.Users.FirstOrDefault(x=> x.UserEmail == model.UserEmail && x.UserPassword == model.UserPassword);
            
            if(result == default)
                return NotFound();
            
            var token = TokenService.GenereteToken(result, "adm");
            result.UserPassword = "";

            return Ok(new {
                User = result,
                token = token
            });
        }
    }
}