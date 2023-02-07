using Microsoft.AspNetCore.Mvc;
using AppAgendaAPI.Models;
using Microsoft.AspNetCore.Authorization;

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
    [AllowAnonymous]
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

    [HttpPut]
    [Route("update")]
    [Authorize(Roles = "adm")]
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

