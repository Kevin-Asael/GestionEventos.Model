using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionEventos.Model;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<GestionEventos.Model.Tipo> Tipos { get; set; } = default!;

        public DbSet<GestionEventos.Model.Ponente> Ponentes { get; set; } = default!;

        public DbSet<GestionEventos.Model.Participante> Participantes { get; set; } = default!;

        public DbSet<GestionEventos.Model.Pago> Pagos { get; set; } = default!;

        public DbSet<GestionEventos.Model.Inscripcion> Inscripciones { get; set; } = default!;

        public DbSet<GestionEventos.Model.GestionarSesiones> GestionarSesiones { get; set; } = default!;

        public DbSet<GestionEventos.Model.Evento> Eventos { get; set; } = default!;

        public DbSet<GestionEventos.Model.Certificado> Certificados { get; set; } = default!;

        public DbSet<GestionEventos.Model.AsignarPonente> AsignarPonentes { get; set; } = default!;
    }
