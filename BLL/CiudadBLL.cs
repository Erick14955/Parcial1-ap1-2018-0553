using Parcial1_ap1_2018_0553.DAL;
using Parcial1_ap1_2018_0553.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_ap1_2018_0553.BLL
{
    class CiudadBLL
    {
        public static bool Guardar(Ciudad ciudad)
        {
            if (!Existe(ciudad.CiudadID))
            {
                return Insertar(ciudad);
            }
            else
            {
                return Modificar(ciudad);
            }
        }

        public static bool Insertar(Ciudad ciudad)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Ciudad.Add(ciudad);
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

        public static bool Modificar(Ciudad ciudad)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(ciudad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Ciudad.Any(e => e.CiudadID == id);
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var ciudad = contexto.Ciudad.Find(id);
                if(ciudad != null)
                {
                    contexto.Ciudad.Remove(ciudad);
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

        public static Ciudad Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ciudad ciudad;
            try
            {
                ciudad = contexto.Ciudad.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ciudad;
        }
    }
}
