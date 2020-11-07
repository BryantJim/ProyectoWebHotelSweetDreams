using Microsoft.EntityFrameworkCore;
using SweetDreams.Cliente.DAL;
using SweetDreams.Cliente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SweetDreams.Cliente.BLL
{
    public class HabitacionesBLL
    {
        public static bool Guardar(Habitacion habitacion)
        {
            if (!Existe(habitacion.HabitacionId))
                return Insertar(habitacion);
            else
                return Modificar(habitacion);
        }

        private static bool Insertar(Habitacion habitacion)
        {
            if (habitacion.HabitacionId != 0)
                return false;

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Habitacion.Add(habitacion) != null)
                    paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Habitacion habitacion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(habitacion).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var habitacion = contexto.Habitacion.Find(id);
                if (habitacion != null)
                {
                    contexto.Habitacion.Remove(habitacion);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Habitacion Buscar(int id)
        {
            Habitacion habitacion = new Habitacion();
            Contexto contexto = new Contexto();
            try
            {
                habitacion = contexto.Habitacion.Find(id);
             
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return habitacion;
        }

        private static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Habitacion.Any(u => u.HabitacionId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Habitacion> GetList(Expression<Func<Habitacion, bool>> habitacion)
        {
            List<Habitacion> Lista = new List<Habitacion>();
            Contexto contexto = new Contexto();
            try
            {
                Lista = contexto.Habitacion.Where(habitacion).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
    }
}
