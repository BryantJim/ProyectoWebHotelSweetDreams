using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SweetDreams.Cliente.DAL;
using SweetDreams.Cliente.Models;

namespace SweetDreams.Cliente.BLL
{
    public class ReservacionesBLL
    {
        public static bool Guardar(Reservaciones reservacion)
        {
            if (!Existe(reservacion.ReservacionId))
                return Insertar(reservacion);
            else
                return Modificar(reservacion);
        }

        private static bool Insertar(Reservaciones reservacion)
        {
            if (reservacion.ReservacionId != 0)
                return false;

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Reservaciones.Add(reservacion) != null)
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

        private static bool Modificar(Reservaciones reservacion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Database.ExecuteSqlRaw($"DELETE FROM ComprasDetalle Where CompraId={reservacion.ReservacionId}");

                foreach (var item in reservacion.ReservacionDetalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(reservacion).State = EntityState.Modified;
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
                var eliminar = contexto.Reservaciones.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;
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
        public static Reservaciones Buscar(int id)
        {
            Reservaciones reservaciones = new Reservaciones();
            Contexto contexto = new Contexto();
            try
            {
                reservaciones = contexto.Reservaciones.Include(x => x.ReservacionDetalle).
                    Where(x => x.ReservacionId == id).
                    SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return reservaciones;
        }

        private static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Clientes.Any(u => u.ClienteId == id);
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

        public static List<Reservaciones> GetList(Expression<Func<Reservaciones, bool>> reservacion)
        {
            List<Reservaciones> Lista = new List<Reservaciones>();
            Contexto contexto = new Contexto();
            try
            {
                Lista = contexto.Reservaciones.Where(reservacion).ToList();
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
