using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RegistroPrestamoDetalle.DAL;
using RegistroPrestamoDetalle.Models;
using System.Linq.Expressions;

namespace RegistroPrestamoDetalle.BLL
{
    public class MorasBLL
    {
        public static bool Existe(int id)//determina si existe una Mora
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Moras.Any(m => m.MoraId == id);
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

        public static bool Insertar(Moras mora)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Moras.Add(mora);
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

        public static bool Modificar(Moras mora)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM MorasDetalle Where MoraId = {mora.MoraId}");

                foreach (var item in mora.MoraDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(mora).State = EntityState.Modified;
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

        public static bool Guardar(Moras mora)
        {
            if (!Existe(mora.MoraId))
                return Insertar(mora);
            else
                return Modificar(mora);
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var persona = db.Personas.Find(id);

                if (persona != null)
                {
                    db.Personas.Remove(persona);//remueve la entidad
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

        public static Moras Buscar(int id)
        {
            Contexto db = new Contexto();
            Moras moras;

            try
            {
                moras = db.Moras
                    .Where(m => m.MoraId == id)
                    .Include(m => m.MoraDetalle)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return moras;
        }

        public static List<Moras> GetMoras()
        {
            List<Moras> lista = new List<Moras>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Moras.ToList();
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

        public static List<Moras> GetList(Expression<Func<Moras, bool>> criterio)
        {
            List<Moras> lista = new List<Moras>();
            Contexto db = new Contexto();
            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                lista = db.Moras.Where(criterio).ToList();
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
