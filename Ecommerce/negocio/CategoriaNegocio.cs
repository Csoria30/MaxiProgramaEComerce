using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modelo;

namespace negocio
{
    internal class CategoriaNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public List<Categoria> listar()
        {
            List<Categoria> listaCategoria = new List<Categoria>();

            try
            {
                string consulta = @"
                    Select Id, Descripcion 
                    FROM CATEGORIAS
                ";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria auxiliar = new Categoria();
                    auxiliar.Id = (int)datos.Lector["Id"];
                    auxiliar.Descripcion = (string)datos.Lector["Descripcion"];

                    listaCategoria.Add(auxiliar);
                }

                return listaCategoria;
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

        public void agregarCategoria(Categoria categoria)
        {
            try
            {
                string consulta = @"
                    INSERT INTO CATEGORIAS (Descripcion)
                    VALUES(
                        @Descripcion
                    )
                ";

                datos.setearConsulta(consulta);
                datos.setearParametro("@Descripcion", categoria.Descripcion);
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

        public void editarCategoria(Categoria categoria)
        {
            try
            {
                string consulta = @"
                    UPDATE CATEGORIAS SET
	                    Descripcion = @Descripcion
                    WHERE Id = @Id
                ";

                datos.setearConsulta(consulta);
                datos.setearParametro("@Descripcion", categoria.Descripcion);
                datos.setearParametro("@Id", categoria.Id);
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

        public void elimiarCategoria(int id)
        {
            try
            {
                string consulta = "DELETE FROM CATEGORIAS WHERE Id = @Id";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch(Exception ex)
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
