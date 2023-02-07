
namespace Agenda_Interface.Models;

public class Annotation
{
    public int AnnotationId { get; set; }
    public int UserId { get; set; }
    public string Text { get; set; }
    public bool Conclusion { get; set; }
}