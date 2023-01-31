using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAgendaAPI.Models;
    public class Annotation
    {
        [Key]
        public int AnnotationId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [MaxLength(500)]
        public string Text { get; set; }
        public bool Conclusion { get; set; }
        
    }
