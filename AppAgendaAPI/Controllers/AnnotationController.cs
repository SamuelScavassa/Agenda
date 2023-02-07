using Microsoft.AspNetCore.Mvc;
using AppAgendaAPI.Models;
using Microsoft.AspNetCore.Authorization;
namespace AppAgendaAPI.Controllers;
[ApiController]
[Route("Annotation")]
public class AnnotationController : ControllerBase
{
    private DBAgenda db;
    public AnnotationController(DBAgenda db)
    {
        this.db = db;
    }

    [HttpPost]
    [Route("add")]
    [Authorize(Roles = "adm")]
    public ActionResult Create(Annotation Anot)
    {
        db.Annotations.Add(Anot);
        db.SaveChanges();
        return Created("Salvo!", Anot);
    }

    [HttpGet]
    [Route("lista")]
    [Authorize(Roles = "adm")]
    public ActionResult Lista(int IdUser)
    {
        List<Annotation> lista = new List<Annotation>();
        foreach (var item in db.Annotations)
        {
            if (item.UserId == IdUser)
                lista.Add(item);
        }
        return Ok(lista);
    }

    [HttpGet]
    [Route("ultimaAnot")]
    [Authorize(Roles = "adm")]
    public ActionResult Last(int IdUser)
    {
        List<Annotation> lista = new List<Annotation>();
        foreach (var item in db.Annotations)
        {
            if (item.UserId == IdUser)
                lista.Add(item);
        }
        return Ok(lista.Last());
    }
}