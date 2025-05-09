using GestionEventos.Model;
using Librerria.API.Consumer;

namespace GestionEventos.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProbarTipos();
            //ProbarEventos();
            //ProbarPonentes();
            //ProbarAsignacionPonente();
            //ProbarParticipantes();
            //ProbarInscripciones();
            //ProbarPagos();
            //ProbarCertificados();
            //ProbarGestionarSesiones();
            //ProbarEliminarEvento();
            //ProbarEventoPorId();
            //ProbarEliminarTipo();
            //ProbarEliminarParticipante();
            //ProbarEliminarPonente();
            //ProbarEliminarInscripcion();
            //ProbarEliminarPago();
            //ProbarEliminarCertificado();
            //ProbarEliminarSesion();
            ProbarEliminarAsignacionPonente();
            Console.ReadLine();
        }

        private static void ProbarTipos()
        {
            Crud<Tipo>.EndPoint = "https://localhost:7233/api/Tipos";

            var tipo = Crud<Tipo>.Create(new Tipo
            {
                Codigo = 0,
                Nombre = "Seminario Utn"
            });

            tipo.Nombre = "Seminario Actualizado";
            Crud<Tipo>.Update(tipo.Codigo, tipo);

            var tipos = Crud<Tipo>.GetAll();
            foreach (var t in tipos)
            {
                Console.WriteLine($"Codigo: {t.Codigo}, Nombre: {t.Nombre}");
            }
        }

        private static void ProbarEventos()
        {
            Crud<Evento>.EndPoint = "https://localhost:7233/api/Eventos";

            var evento = Crud<Evento>.Create(new Evento
            {
                Codigo = 0,
                Nombre = "Evento de API",
                Fecha = "2026-10-01",
                Lugar = "Auditorio Fica UTN Campus El Olivo",
                TipoCodigo = 5
            });

            evento.Lugar = "Auditorio Fica Actualizado";
            Crud<Evento>.Update(evento.Codigo, evento);

            var eventos = Crud<Evento>.GetAll();
            foreach (var e in eventos)
            {
                Console.WriteLine($"Codigo: {e.Codigo}, Nombre: {e.Nombre}, Lugar: {e.Lugar}, Fecha: {e.Fecha}, EventoTipo: {e.Tipo?.Nombre}, EventoCodigo :{e.Tipo?.Codigo}");
            }
        }

        private static void ProbarPonentes()
        {
            Crud<Ponente>.EndPoint = "https://localhost:7233/api/Ponentes";

            var ponente = Crud<Ponente>.Create(new Ponente
            {
                Codigo = 0,
                Nombre = "Maria Dervez"
            });

            ponente.Nombre = "Maria Dervez Actualizada";
            Crud<Ponente>.Update(ponente.Codigo, ponente);

            var ponentes = Crud<Ponente>.GetAll();
            foreach (var p in ponentes)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Nombre: {p.Nombre}");
            }
        }

        private static void ProbarAsignacionPonente()
        {
            Crud<AsignarPonente>.EndPoint = "https://localhost:7233/api/AsignarPonentes";

            var asignacion = Crud<AsignarPonente>.Create(new AsignarPonente
            {
                Codigo = 0,
                EventoCodigo = 7,
                PonenteCodigo = 5
            });

            var asignaciones = Crud<AsignarPonente>.GetAll();
            foreach (var a in asignaciones)
            {
                Console.WriteLine($"Codigo: {a.Codigo}, Evento: {a.Evento?.Nombre}, Ponente: {a.Ponente?.Nombre}, CodigoPonente: {a.Ponente?.Codigo}");
            }
        }

        private static void ProbarParticipantes()
        {
            Crud<Participante>.EndPoint = "https://localhost:7233/api/Participantes";

            var participante = Crud<Participante>.Create(new Participante
            {
                Codigo = 0,
                Nombre = "Alex Vinueza",
                Cedula = "1002004001",
                Edad = 22
            });

            participante.Nombre = "Alex Vinueza Actualizado";
            Crud<Participante>.Update(participante.Codigo, participante);

            var participantes = Crud<Participante>.GetAll();
            foreach (var p in participantes)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Nombre: {p.Nombre}, Cedula: {p.Cedula}, Edad: {p.Edad}");
            }
        }

        private static void ProbarInscripciones()
        {
            Crud<Inscripcion>.EndPoint = "https://localhost:7233/api/Inscripciones";

            var inscripcion = Crud<Inscripcion>.Create(new Inscripcion
            {
                Codigo = 0,
                EventoCodigo = 6,
                ParticipanteCodigo = 6,
                Estado = "Inscrito",
                Fecha = DateTime.Now
            });

            inscripcion.Estado = "Pagado";
            Crud<Inscripcion>.Update(inscripcion.Codigo, inscripcion);

            var inscripciones = Crud<Inscripcion>.GetAll();
            foreach (var i in inscripciones)
            {
                Console.WriteLine($"Codigo: {i.Codigo}, Estado: {i.Estado}, FechaActual: {i.Fecha}, Participante: {i.Participante?.Nombre}, Evento: {i.Evento?.Nombre}, TipoEvento: {i.Evento?.Tipo}, FechaEvento: {i.Evento?.Fecha}, LugraEvento: {i.Evento?.Lugar}");
            }
        }

        private static void ProbarPagos()
        {
            Crud<Pago>.EndPoint = "https://localhost:7233/api/Pagos";

            var pago = Crud<Pago>.Create(new Pago
            {
                Codigo = 0,
                MetodoPago = "Efectivo",
                InscripcionCodigo = 6
            });

            var pagos = Crud<Pago>.GetAll();
            foreach (var p in pagos)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, MetodoPago: {p.MetodoPago}, Inscripcion: {p.Inscripcion?.Codigo}, FechaIncrito: {p.Inscripcion?.Fecha}");
            }
        }

        private static void ProbarCertificados()
        {
            Crud<Certificado>.EndPoint = "https://localhost:7233/api/Certificados";

            var certificado = Crud<Certificado>.Create(new Certificado
            {
                Codigo = 0,
                FechaEmision = DateTime.Now,
                InscripcionCodigo = 6
            });

            var certificados = Crud<Certificado>.GetAll();
            foreach (var c in certificados)
            {
                Console.WriteLine($"Codigo: {c.Codigo}, FechaEmision: {c.FechaEmision}, Inscripcion: {c.Inscripcion?.Codigo}");
            }
        }

        private static void ProbarGestionarSesiones()
        {
            Crud<GestionarSesiones>.EndPoint = "https://localhost:7233/api/GestionarSesiones";

            // Crear una nueva sesión
            var sesion = Crud<GestionarSesiones>.Create(new GestionarSesiones
            {
                Codigo = 0,
                Hora = "1 PM",
                Sala = "Sala 21",
                EventoCodigo = 6 
            });

            // Actualizar la sala
            sesion.Sala = "Sala Secundaria";
            Crud<GestionarSesiones>.Update(sesion.Codigo, sesion);

            // Obtener todas las sesiones
            var sesiones = Crud<GestionarSesiones>.GetAll();
            foreach (var s in sesiones)
            {
                Console.WriteLine($"Codigo: {s.Codigo}, Hora: {s.Hora}, Sala: {s.Sala}, Evento: {s.Evento?.Nombre}");
            }
        }

        private static void ProbarEliminarEvento()
        {
            Crud<Evento>.EndPoint = "https://localhost:7233/api/Eventos";

            int idAEliminar = 6; 

            var exito = Crud<Evento>.Delete(idAEliminar);


            var eventos = Crud<Evento>.GetAll();
            foreach (var e in eventos)
            {
                Console.WriteLine($"Codigo: {e.Codigo}, Nombre: {e.Nombre}, Lugar: {e.Lugar}, Fecha: {e.Fecha}, EventoTipo: {e.Tipo?.Nombre}, EventoCodigo :{e.Tipo?.Codigo}");
            }

            if (exito)
                Console.WriteLine($" Evento con ID {idAEliminar} eliminado correctamente.");
                
            else
                Console.WriteLine($" No se pudo eliminar el evento con ID {idAEliminar}.");
        }

        private static void ProbarEventoPorId()
        {
            Crud<Evento>.EndPoint = "https://localhost:7233/api/Eventos";

            int idBuscado = 5;

            var evento = Crud<Evento>.GetById(idBuscado);

            if (evento != null)
            {
                Console.WriteLine($" Evento encontrado: {evento.Nombre}, Fecha: {evento.Fecha}, Lugar: {evento.Lugar}");
            }
            else
            {
                Console.WriteLine($" No se encontró un evento con ID {idBuscado}.");
            }
        }

        private static void ProbarEliminarTipo()
        {
            Crud<Tipo>.EndPoint = "https://localhost:7233/api/Tipos";

            int idAEliminar = 2;

            var exito = Crud<Tipo>.Delete(idAEliminar);

            var tipos = Crud<Tipo>.GetAll();
            foreach (var t in tipos)
            {
                Console.WriteLine($"Codigo: {t.Codigo}, Nombre: {t.Nombre}");
            }

            if (exito)
                Console.WriteLine($" Tipo con ID {idAEliminar} eliminado correctamente.");
            else
                Console.WriteLine($" No se pudo eliminar el tipo con ID {idAEliminar}.");
        }

        private static void ProbarEliminarParticipante()
        {
            Crud<Participante>.EndPoint = "https://localhost:7233/api/Participantes";

            int idAEliminar = 3;

            var exito = Crud<Participante>.Delete(idAEliminar);

            var participantes = Crud<Participante>.GetAll();
            foreach (var p in participantes)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Nombre: {p.Nombre}, Cedula: {p.Cedula}, Edad: {p.Edad}");
            }

            if (exito)
                Console.WriteLine($" Participante con ID {idAEliminar} eliminado correctamente.");
            else
                Console.WriteLine($" No se pudo eliminar el participante con ID {idAEliminar}.");
        }

        private static void ProbarEliminarPonente()
        {
            Crud<Ponente>.EndPoint = "https://localhost:7233/api/Ponentes";

            int idAEliminar = 1;

            var exito = Crud<Ponente>.Delete(idAEliminar);

            var ponentes = Crud<Ponente>.GetAll();
            foreach (var p in ponentes)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Nombre: {p.Nombre}");
            }

            if (exito)
                Console.WriteLine($" Ponente con ID {idAEliminar} eliminado correctamente.");
            else
                Console.WriteLine($" No se pudo eliminar el ponente con ID {idAEliminar}.");
        }

        private static void ProbarEliminarInscripcion()
        {
            Crud<Inscripcion>.EndPoint = "https://localhost:7233/api/Inscripciones";

            int idAEliminar = 5;

            var exito = Crud<Inscripcion>.Delete(idAEliminar);

            var inscripciones = Crud<Inscripcion>.GetAll();
            foreach (var i in inscripciones)
            {
                Console.WriteLine($"Codigo: {i.Codigo}, Estado: {i.Estado}, Fecha: {i.Fecha}, Participante: {i.Participante?.Nombre}, Evento: {i.Evento?.Nombre}");
            }

            if (exito)
                Console.WriteLine($" Inscripcion con ID {idAEliminar} eliminada correctamente.");
            else
                Console.WriteLine($" No se pudo eliminar la inscripcion con ID {idAEliminar}.");
        }

        private static void ProbarEliminarPago()
        {
            Crud<Pago>.EndPoint = "https://localhost:7233/api/Pagos";

            int idAEliminar = 8;

            var exito = Crud<Pago>.Delete(idAEliminar);

            var pagos = Crud<Pago>.GetAll();
            foreach (var p in pagos)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, MetodoPago: {p.MetodoPago}, InscripcionCodigo: {p.Inscripcion?.Codigo}");
            }

            if (exito)
                Console.WriteLine($" Pago con ID {idAEliminar} eliminado correctamente.");
            else
                Console.WriteLine($" No se pudo eliminar el pago con ID {idAEliminar}.");
        }

        private static void ProbarEliminarCertificado()
        {
            Crud<Certificado>.EndPoint = "https://localhost:7233/api/Certificados";

            int idAEliminar = 4;

            var exito = Crud<Certificado>.Delete(idAEliminar);

            var certificados = Crud<Certificado>.GetAll();
            foreach (var c in certificados)
            {
                Console.WriteLine($"Codigo: {c.Codigo}, FechaEmision: {c.FechaEmision}, InscripcionCodigo: {c.Inscripcion?.Codigo}");
            }

            if (exito)
                Console.WriteLine($" Certificado con ID {idAEliminar} eliminado correctamente.");
            else
                Console.WriteLine($" No se pudo eliminar el certificado con ID {idAEliminar}.");
        }

        private static void ProbarEliminarSesion()
        {
            Crud<GestionarSesiones>.EndPoint = "https://localhost:7233/api/GestionarSesiones";

            int idAEliminar = 3;

            var exito = Crud<GestionarSesiones>.Delete(idAEliminar);

            var sesiones = Crud<GestionarSesiones>.GetAll();
            foreach (var s in sesiones)
            {
                Console.WriteLine($"Codigo: {s.Codigo}, Hora: {s.Hora}, Sala: {s.Sala}, Evento: {s.Evento?.Nombre}");
            }

            if (exito)
                Console.WriteLine($" Sesión con ID {idAEliminar} eliminada correctamente.");
            else
                Console.WriteLine($" No se pudo eliminar la sesión con ID {idAEliminar}.");
        }

        private static void ProbarEliminarAsignacionPonente()
        {
            Crud<AsignarPonente>.EndPoint = "https://localhost:7233/api/AsignarPonentes";

            int idAEliminar = 3;

            var exito = Crud<AsignarPonente>.Delete(idAEliminar);

            var asignaciones = Crud<AsignarPonente>.GetAll();
            foreach (var a in asignaciones)
            {
                Console.WriteLine($"Codigo: {a.Codigo}, Evento: {a.Evento?.Nombre}, Ponente: {a.Ponente?.Nombre}");
            }

            if (exito)
                Console.WriteLine($" Asignación con ID {idAEliminar} eliminada correctamente.");
            else
                Console.WriteLine($" No se pudo eliminar la asignación con ID {idAEliminar}.");
        }

    }
}