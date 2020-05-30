using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Prestamo.DAL;
using Prestamo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Media.Animation;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Prestamo.BLL
{
    public class ClienteBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.rCliente.Any(e => e.Prestamoid == id);
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

        private static bool Insertar(rCliente cliente)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.rCliente.Add(cliente);
                key = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return key;
        }

        private static bool Modificar(rCliente cliente)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(cliente).State = EntityState.Modified;
                key = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return key;
        }

        public static bool Guardar(rCliente cliente)
        {
            if (!Existe(cliente.Prestamoid))
            {
                return Insertar(cliente);
            }
            else
            {
                return Modificar(cliente);
            }
        }

        public static bool Eliminar(int id)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {

                var cliente = contexto.rCliente.Find(id);

                if (cliente != null)
                {
                    contexto.rCliente.Remove(cliente);
                    key = contexto.SaveChanges() > 0;
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
            return key;
        }

        public static rCliente Buscar(int id)
        {
            Contexto contexto = new Contexto();
            rCliente cliente;

            try
            {
                cliente = contexto.rCliente.Find(id);

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

        public static List<rCliente> GetList(Expression<Func<rCliente, bool>> criterio)
        {
            List<rCliente> lista = new List<rCliente>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.rCliente.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}