using Microsoft.EntityFrameworkCore;

namespace WinFormsAppEF;
public class SchoolContext:DbContext
{
    public DbSet<Alumno> Alumnos{ get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string conexion = @"Server=LAPTOP-1K29SKO8\MSSQLSERVER2020;Database=SchoolDBEF;User Id=sa;Password=admin2020";
        optionsBuilder.UseSqlServer(conexion);
    }
}
