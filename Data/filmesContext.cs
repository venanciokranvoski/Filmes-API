using Filmes_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmes_API.Data
{
    public class FilmesContext : DbContext
    {
        public FilmesContext(DbContextOptions<FilmesContext> opt) : base(opt)
        {

        }

        public DbSet<Filme> Filmes { get; set; }
    }
}
