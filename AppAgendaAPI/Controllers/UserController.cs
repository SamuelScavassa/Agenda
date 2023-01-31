using Microsoft.AspNetCore.Mvc;
using AppAgendaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace AppAgendaAPI.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private DBAgenda db;

    public UserController(DBAgenda db)
    {
        this.db = db;

    }


    [HttpPost]
    [Route("New")]
    public ActionResult Create(User NewUser)
    {
        var usr = db.Users.FirstOrDefault(x => x.UserEmail == NewUser.UserEmail);
        if (usr == default)
        {
            db.Users.Add(NewUser);
            db.SaveChanges();
            return Ok(NewUser);
        }
        return NotFound("Email já cadastrado");
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO request)
    {
        var usr = db.Users.FirstOrDefault(x => x.UserEmail == request.Email && x.UserPassword == request.Senha);
        // Validate the user credentials
        if (usr != default)
        { 
            return Ok(usr);
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPut]
    [Route("update")]
    public ActionResult Update(User Alter)
    {
        User? usr = db.Users.FirstOrDefault(x => x.UserId == Alter.UserId);
        if (usr == default)
        {
            return BadRequest();
        }
        usr.UserName = Alter.UserName;
        usr.UserEmail = Alter.UserEmail;
        usr.UserPassword = Alter.UserPassword;
        usr.UserAbout = Alter.UserAbout;
        db.SaveChanges();


        return Ok(usr);
    }

}

public class LoginDTO
{
    public string Email { get; set; }
    public string Senha { get; set; }
}
