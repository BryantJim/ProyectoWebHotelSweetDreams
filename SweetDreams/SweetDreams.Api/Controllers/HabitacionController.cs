using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetDreams.Api.DAL;
using SweetDreams.Api.Models.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Api.Controllers
{
    [Route(template: "api/[Controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private Contexto contexto;

        public HabitacionController(Contexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habitacion>>> GetList()
        {
            List<Habitacion> habitacion;
            try
            {
                habitacion = await contexto.Habitacion.Where(h => h.Accesibilidad == true).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return habitacion;
        }

        private async Task<ActionResult<bool>> Insertar(Habitacion habitacion)
        {
            bool guardar = false;
            try
            {
                contexto.Habitacion.Add(habitacion);
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
                var habitacion = await contexto.Habitacion.Where(d => d.HabitacionId == id).SingleOrDefaultAsync();

                if(habitacion != null)
                {
                    habitacion.Accesibilidad = false;
                    contexto.Habitacion.Update(habitacion);
                    //contexto.Habitacion.Remove(habitacion);
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
        public async Task<ActionResult<Habitacion>> Buscar(int id)
        {
            Habitacion habitacion = new Habitacion();
            try  
            {
                var encontrado = await contexto.Habitacion.FindAsync(id);

                if (encontrado == null)
                    return new Habitacion();
                if (encontrado.Accesibilidad == false)
                    return new Habitacion();
                else
                    habitacion = encontrado;
            }
            catch (Exception)
            {
                throw;
            }
            return habitacion;
        }

        private async Task<ActionResult<bool>> Modificar([FromBody] Habitacion habitacion)
        {
            bool modificar = false;
            try
            {
                contexto.Habitacion.Update(habitacion);
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
                existe = contexto.Habitacion.Any(a => a.HabitacionId == id);
            }                
            catch (Exception)
            {
                throw;
            }
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Guardar(Habitacion habitacion)
        {
                if (!Existe(habitacion.HabitacionId))
                    return await Modificar(habitacion);
                else
                    return await Insertar(habitacion);
        }
    }
}
