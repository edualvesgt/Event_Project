using Microsoft.EntityFrameworkCore;
using weapi.Event_.Domains;

namespace weapi.Event_.Contexts
{
    public class EventContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }
        public DbSet<PresencaEvento> PresencaEvento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE15-S15; Database = Event+; User Id = sa ; pwd = Senai@134; TrustServerCertificate = True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
