using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetDreams.Api.DAL;
using SweetDreams.Api.Models.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SweetDreams.Api.Controllers
{
    [Route(template: "api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private Contexto contexto;

        public ActividadController(Contexto contexto)
        {
            this.contexto = contexto;
        }

        // GET: api/<ActividadController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actividades>>> GetList()
        {
            List<Actividades> Lista;
            try
            {
                Lista = await contexto.Actividades.Where(a => a.Accesibilidad == true).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Guardar(Actividades actividad)
        {
            if (Existe(actividad.ActividadId))
                return await Modificar(actividad);
            else
                return await Insertar(actividad);
        }

        private bool Existe(int id)
        {
            bool existe;
            try
            {
                existe = contexto.Actividades.Any(a => a.ActividadId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }

        private async Task<ActionResult<bool>> Modificar([FromBody] Actividades actividad)
        {
            bool modificar = false;
            try
            {
                contexto.Actividades.Update(actividad);
                modificar = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return modificar;
        }

        private async Task<ActionResult<bool>> Insertar(Actividades actividad)
        {
            bool guardar = false;
            try
            {
                contexto.Actividades.Add(actividad);
                guardar = await contexto.SaveChangesAsync() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return guardar;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Actividades>> Buscar(int id)
        {
            Actividades actividad = new Actividades();
            try
            {
                var encontrado = await contexto.Actividades.FindAsync(id);

                if (encontrado == null)
                    return new Actividades();
                if (encontrado.Accesibilidad == false)
                    return new Actividades();
                else
                    actividad = encontrado;
            }
            catch (Exception)
            {
                throw;
            }
            return actividad;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<bool>> Eliminar(int id)
        {
            bool eliminado = false;
            try
            {
                var actividad = await contexto.Actividades.Where(a => a.ActividadId == id).SingleOrDefaultAsync();

                if (actividad != null)
                {
                    actividad.Accesibilidad = false;
                    contexto.Actividades.Update(actividad);
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
    }
}
