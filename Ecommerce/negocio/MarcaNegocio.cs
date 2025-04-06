using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modelo;

namespace negocio
{
    internal class MarcaNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public List<Marca> listar()
        {
            List<Marca> listaMarca = new List<Marca>();

            try
            {
                string consulta = @"
                    Select Id, Descripcion 
                    FROM MARCAS
                ";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca auxiliar = new Marca();
                    auxiliar.Id = (int)datos.Lector["Id"];
                    auxiliar.Descripcion = (string)datos.Lector["Descripcion"];

                    listaMarca.Add(auxiliar);
                }

                return listaMarca;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregarMarca(Marca marca)
        {
            try
            {
                string consulta = @"
                    INSERT INTO MARCAS (Descripcion)
                    VALUES(
                        @Descripcion
                    )
                ";

                datos.setearConsulta(consulta);
                datos.setearParametro("@Descripcion", marca.Descripcion);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void editarMarca(Marca marca)
        {
            try
            {
                string consulta = @"
                    UPDATE MARCAS SET
	                    Descripcion = @Descripcion
                    WHERE Id = @Id
                ";

                datos.setearConsulta(consulta);
                datos.setearParametro("@Descripcion", marca.Descripcion);
                datos.setearParametro("@Id", marca.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminarMarca(int id)
        {
            try
            {
                string consulta = "DELETE FROM MARCAS WHERE Id = @Id";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
