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
                Lista = await contexto.Reservaciones.Where(h => h.ReservacionId > 0).ToListAsync();
                //Lista = Lista.Where(h => h.Accesibilidad == true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }


        private async Task<ActionResult<bool>> Insertar(Reservaciones Reservaciones)
        {
            bool guardar = false;
            try
            {
                contexto.Reservaciones.Add(Reservaciones);
                guardar = await contexto.SaveChangesAsync() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return guardar;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<bool>> Eliminar(int id)
        {
            bool eliminado = false;
            try
            {
                var Reservaciones = await contexto.Reservaciones.Where(d => d.ReservacionId == id).SingleOrDefaultAsync();

                if (Reservaciones != null)
                {
                    Reservaciones.Accesibilidad = false;
                    contexto.Reservaciones.Update(Reservaciones);
                    //contexto.Reservaciones.Remove(Reservaciones);
                    eliminado = (await contexto.SaveChangesAsync() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return eliminado;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservaciones>> Buscar(int id)
        {
            Reservaciones Reservaciones = new Reservaciones();
            try
            {
                var encontrado = await contexto.Reservaciones.FindAsync(id);

                if (encontrado == null)
                    return new Reservaciones();
                if (encontrado.Accesibilidad == false)
                    return new Reservaciones();
                else
                    Reservaciones = encontrado;
            }
            catch (Exception)
            {
                throw;
            }
            return Reservaciones;
        }

        private async Task<ActionResult<bool>> Modificar([FromBody] Reservaciones Reservaciones)
        {
            bool modificar = false;
            try
            {
                contexto.Reservaciones.Update(Reservaciones);
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
                existe = contexto.Reservaciones.Any(a => a.ReservacionesId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Guardar(Reservaciones Reservaciones)
        {
            if (Existe(Reservaciones.ReservacionesId))
                return await Modificar(Reservaciones);
            else
                return await Insertar(Reservaciones);
        }
    }
}
