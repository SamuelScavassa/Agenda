using Microsoft.EntityFrameworkCore;

namespace AppAgendaAPI.Models;
public class DBAgenda: DbContext
{
    public DBAgenda(DbContextOptions<DBAgenda> options) : base(options)
    {
    }
    
    public DbSet<User>? Users { get; set; }
    public DbSet<Annotation>? Annotations { get; set; }
    
}