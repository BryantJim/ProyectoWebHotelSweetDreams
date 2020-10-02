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
                habitacion = await contexto.Habitacion.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return habitacion;
        }

        private async Task<ActionResult<bool>> Insertar(Habitacion habitacion)
        {
            bool guardar = false;
            try
            {
                if (contexto.Habitacion.Add(habitacion) != null)
                {
                    guardar = await contexto.SaveChangesAsync() > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return guardar;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Action>> Eliminar(int id)
        {
            try
            {
                var habitacion = await contexto.Habitacion.Where(d => d.HabitacionId == id).SingleOrDefaultAsync();

                if (habitacion == null)
                    return NotFound("Estudiantes no encontrado");
                else
                {
                    contexto.Habitacion.Remove(habitacion);
                    await contexto.SaveChangesAsync();
                    return Ok("Estudiante eliminado");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Habitacion>> Buscar(int id)
        {
            try
            {
                var habitacion = await contexto.Habitacion.Where(d => d.HabitacionId == id).SingleOrDefaultAsync();

                if (habitacion == null)
                    return NotFound("Estudiantes no encontrado");
                else
                    return Ok(habitacion);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task<ActionResult<bool>> Modificar([FromBody] Habitacion habitacion)
        {
            bool modificar = false;
            try
            {
                contexto.Habitacion.Update(habitacion);
                modificar = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return modificar;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Guardar(Habitacion habitacion)
        {
            bool existe;
            try
            {
                existe = await contexto.Habitacion.AnyAsync(a => a.HabitacionId == habitacion.HabitacionId);

                if (existe)
                    return await Modificar(habitacion);
                else
                    return await Insertar(habitacion);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
