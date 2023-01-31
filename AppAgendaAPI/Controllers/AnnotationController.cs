using Microsoft.AspNetCore.Mvc;
using AppAgendaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
    public ActionResult Create(Annotation Anot)
    {
        db.Annotations.Add(Anot);
        db.SaveChanges();
        return Created("Salvo!", Anot);
    }

    [HttpGet]
    [Route("lista")]
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

    [HttpPost]
    [Route("getAnnotation")]
    public ActionResult Anotacao(Annotation AnnotationDTO)
    {
        var anot = db.Annotations.FirstOrDefault(x=>x.AnnotationId == AnnotationDTO.AnnotationId && x.UserId == AnnotationDTO.UserId);
        if (anot == default)
        {
            return NotFound();
        }
        return Ok(anot);
    }



    

}