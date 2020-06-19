using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistroPrestamoDetalle.DAL;
using RegistroPrestamoDetalle.Models;

namespace RegistroPrestamoDetalle.BLL
{
    public class PrestamosBLL
    {
        public static bool Existe(int id)//determina si existe un Prestamo
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Prestamos.Any(p => p.PrestamoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }

        private static bool AfectarBalanceAlInsertarModificar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                prestamo.Balance = prestamo.Monto;

                db.Personas.Find(prestamo.PersonaId).Balance = prestamo.Balance;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Insertar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Prestamos.Add(prestamo);

                AfectarBalanceAlInsertarModificar(prestamo);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(prestamo).State = EntityState.Modified;

                AfectarBalanceAlInsertarModificar(prestamo);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Guardar(Prestamos prestamo)
        {
            if (!Existe(prestamo.PrestamoId))
                return Insertar(prestamo);
            else
                return Modificar(prestamo);
        }

        public static bool Eliminar(int id, int personaId)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var prestamo = db.Prestamos.Find(id);

                if (prestamo != null)
                {
                    db.Prestamos.Remove(prestamo);//remueve la entidad
                    var Eliminar = db.Personas.Find(personaId).Balance = 0;
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Prestamos Buscar(int id)
        {
            Contexto db = new Contexto();
            Prestamos prestamo;

            try
            {
                prestamo = db.Prestamos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return prestamo;
        }

        public static List<Prestamos> GetPrestamos()
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Prestamos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto db = new Contexto();
            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                lista = db.Prestamos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}