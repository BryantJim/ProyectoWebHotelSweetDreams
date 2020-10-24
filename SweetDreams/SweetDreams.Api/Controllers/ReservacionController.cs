using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetDreams.Api.DAL;
using SweetDreams.Api.Models.Administrador;

namespace SweetDreams.Api.Controllers
{
    [Route(template: "api/[Controller]")]
    [ApiController]
    public class ReservacionController : ControllerBase
    {
        private Contexto contexto;

        public ReservacionController(Contexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservaciones>>> GetList()
        {
            List<Reservaciones> Lista;
            try
            {
                Lista = await contexto.Reservaciones.Where(r => r.Accesibilidad == true).ToListAsync();
                //Lista = Lista.Where(h => h.Accesibilidad == true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }


        private async Task<ActionResult<bool>> Insertar(Reservaciones reservaciones)
        {
            bool guardar = false;
            try
            {
                contexto.Reservaciones.Add(reservaciones);
                guardar = await contexto.SaveChangesAsync() > 0;

                if(guardar)
                    await OcuparHabitacion(reservaciones);
            }
            catch (Exception)
            {
                throw;
            }
            return guardar;
        }

        private async Task OcuparHabitacion(Reservaciones reservacion)
        {
            bool guardar;
            Habitacion habitacion = new Habitacion();

            foreach(var item in reservacion.ReservacionDetalle)
            {
                habitacion = contexto.Habitacion.Where(h => h.NumeroHabitacion == item.NumeroHabitacion).FirstOrDefault();
                habitacion.Estado = false;
                contexto.Entry(habitacion).State = EntityState.Modified;
                guardar = await contexto.SaveChangesAsync() > 0;
            }
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<bool>> Eliminar(int id)
        {
            bool eliminado = false;
            try
            {
                var reservaciones = await contexto.Reservaciones.Where(r => r.ReservacionId == id).Include(r => r.ReservacionDetalle).FirstOrDefaultAsync();

                if (reservaciones != null)
                {
                    reservaciones.Accesibilidad = false;
                    contexto.Reservaciones.Update(reservaciones);
                    //contexto.Reservaciones.Remove(Reservaciones);
                    eliminado = (await contexto.SaveChangesAsync() > 0);

                    if (eliminado)
                        await DesOcuparHabitacion(reservaciones);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return eliminado;
        }

        private async Task DesOcuparHabitacion(Reservaciones reservacion)
        {
            bool guardar;
            Habitacion habitacion = new Habitacion();

            foreach (var item in reservacion.ReservacionDetalle)
            {
                habitacion = contexto.Habitacion.Where(h => h.NumeroHabitacion == item.NumeroHabitacion).FirstOrDefault();
                habitacion.Estado = true;
                contexto.Entry(habitacion).State = EntityState.Modified;
                guardar = await contexto.SaveChangesAsync() > 0;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservaciones>> Buscar(int id)
        {
            Reservaciones reservaciones = new Reservaciones();
            try
            {
                var encontrado = await contexto.Reservaciones.Where(r => r.ReservacionId == id).Include(r => r.ReservacionDetalle).FirstOrDefaultAsync();

                if (encontrado == null)
                    return new Reservaciones();
                if (encontrado.Accesibilidad == false)
                    return new Reservaciones();
                else
                    reservaciones = encontrado;
            }
            catch (Exception)
            {
                throw;
            }
            return reservaciones;
        }

        private async Task<ActionResult<bool>> Modificar([FromBody] Reservaciones reservaciones)
        {
            bool modificar = false;
            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM ReservacionesDetalle Where ReservacionId={reservaciones.ReservacionId}");
                foreach(var item in reservaciones.ReservacionDetalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                contexto.Entry(reservaciones).State = EntityState.Modified;
                modificar = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return modificar;
        }

        private bool Existe(int id)
        {
            bool existe;
            try
            {
                existe = contexto.Reservaciones.Any(a => a.ReservacionId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Guardar(Reservaciones reservaciones)
        {
            if (Existe(reservaciones.ReservacionId))
                return await Modificar(reservaciones);
            else
                return await Insertar(reservaciones);
        }
    }
}
