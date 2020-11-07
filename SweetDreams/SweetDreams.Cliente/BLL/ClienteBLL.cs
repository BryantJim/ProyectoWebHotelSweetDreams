using SweetDreams.Cliente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweetDreams.Cliente.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SweetDreams.Cliente.BLL
{
    public class ClienteBLL
    {
        public static bool Guardar(Clientes cliente)
        {
            if (!Existe(cliente.ClienteId))
                return Insertar(cliente);
            else
                return Modificar(cliente);
        }

        private static bool Insertar(Clientes cliente)
        {
            if (cliente.ClienteId != 0)
                return false;

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Clientes.Add(cliente) != null)
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

        private static bool Modificar(Clientes cliente)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(cliente).State = EntityState.Modified;
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
                var usuario = contexto.Clientes.Find(id);
                if (usuario != null)
                {
                    contexto.Clientes.Remove(usuario);
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
        public static Clientes Buscar(int id)
        {
            Clientes cliente = new Clientes();
            Contexto contexto = new Contexto();
            try
            {
                cliente = contexto.Clientes.Find(id);
                if (cliente != null)
                    cliente.Clave = cliente.Clave;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return cliente;
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

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> cliente)
        {
            List<Clientes> Lista = new List<Clientes>();
            Contexto contexto = new Contexto();
            try
            {
                Lista = contexto.Clientes.Where(cliente).ToList();
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

        public static bool ExisteCliente(string usuario, string clave)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Clientes.Where(u => u.NombreUsuario == usuario && u.Clave == clave).SingleOrDefault() != null)
                    paso = true;
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

        public static string ObtenerClienteId(string usuario, string clave)
        {
            Contexto contexto = new Contexto();
            string id;

            try
            { 
                id = contexto.Clientes.Where(u => u.NombreUsuario == usuario && u.Clave == clave).FirstOrDefault().ClienteId.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return id;
        }
    }
}
