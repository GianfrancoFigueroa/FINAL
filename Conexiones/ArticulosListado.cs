using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace Conexiones
{

    public class ArticulosListado
    {
        private Accesos accesos = new Accesos();
        //LECTURA
        public List<ClassArticulo> Listado()
        {
            List<ClassArticulo> Lista = new List<ClassArticulo>();
            try
            {
                accesos.SetConsulta("Select A.Id as 'Id P', A.Codigo, A.Nombre, A.Descripcion, M.id as 'Id Marca', M.Descripcion as 'Marca', C.id as 'Id Categoria', C.Descripcion as 'Categoria', A.ImagenUrl, A.Precio from ARTICULOS A, CATEGORIAS C, MARCAS M where M.Id = A.IdMarca and C.Id = A.IdCategoria");
                accesos.exeLectura();

                while (accesos.Reader.Read())
                {
                    ClassArticulo Aux = new ClassArticulo();
                    Aux.ID = (int)accesos.Reader["Id P"];
                    Aux.Nombre = (string)accesos.Reader["Nombre"];
                    Aux.Codigo = (string)accesos.Reader["Codigo"];
                    Aux.Descripción = (string)accesos.Reader["Descripcion"];
                    Aux.Marcas = new Marcas();
                    Aux.Marcas.ID = (int)accesos.Reader["Id Marca"];
                    Aux.Marcas.Marca = (string)accesos.Reader["Marca"];
                    Aux.Categorias = new Categorias();
                    Aux.Categorias.ID = (int)accesos.Reader["Id Categoria"];
                    Aux.Categorias.Categoria = (string)accesos.Reader["Categoria"];
                    if (!(accesos.Reader["ImagenURL"] is DBNull))
                    {
                        Aux.ImagenURL = (string)accesos.Reader["ImagenURL"];
                    }
                    Aux.Precio = (decimal)accesos.Reader["Precio"];
                    
                    Lista.Add(Aux);
                }

                return Lista;
            }
            catch (Exception Ex)
            {
                
                throw Ex;
            }
            finally
            {
                accesos.CloseConecction();
            }

        }
        //ESCRITURA
        public void insert(ClassArticulo Agregar)
        {


            try
            {
                accesos.SetConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) Values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @PP)");
                accesos.SetearPARAMETROS("@Codigo", Agregar.Codigo);
                accesos.SetearPARAMETROS("@Nombre", Agregar.Nombre);
                accesos.SetearPARAMETROS("@Descripcion", Agregar.Descripción);
                accesos.SetearPARAMETROS("@IdMarca", Agregar.Marcas.ID);
                accesos.SetearPARAMETROS("IdCategoria", Agregar.Categorias.ID);
                accesos.SetearPARAMETROS("@ImagenUrl", Agregar.ImagenURL);
                accesos.SetearPARAMETROS("@PP", Agregar.Precio);

                accesos.exeEscribir();

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            finally
            {
                accesos.CloseConecction();
            }
        }

        public void update(ClassArticulo Objeto)
        {
            try
            {
                accesos.SetConsulta("update ARTICULOS set Codigo = @Codigo, Descripcion = @DD, IdMarca = @IDM, IdCategoria = @IDC, ImagenUrl = @URL, Precio = @Price where Id = @ID ");
                accesos.SetearPARAMETROS("@Codigo", Objeto.Codigo);
                accesos.SetearPARAMETROS("@DD", Objeto.Descripción);
                accesos.SetearPARAMETROS("@IDM", Objeto.Marcas.ID);
                accesos.SetearPARAMETROS("@IDC", Objeto.Categorias.ID);
                accesos.SetearPARAMETROS("@URL", Objeto.ImagenURL);
                accesos.SetearPARAMETROS("@Price", Objeto.Precio);
                accesos.SetearPARAMETROS("@ID", Objeto.ID);

                accesos.exeEscribir();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                accesos.CloseConecction();
            }
        }

        public void delete(ClassArticulo articulo)
        {
            try
            {
                accesos.SetConsulta("delete from ARTICULOS where Id = @ID");
                accesos.SetearPARAMETROS("@ID", articulo.ID);
                accesos.exeEscribir();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                accesos.CloseConecction();
            }


        }

        public List<ClassArticulo> Ordenar(string criterio)
        {
            List<ClassArticulo> ListaOrdenada = new List<ClassArticulo>();
            try
            {
                string consulta = "Select A.Id as 'Id P', A.Codigo, A.Nombre, A.Descripcion, M.id as 'Id Marca', M.Descripcion as 'Marca', C.id as 'Id Categoria', C.Descripcion as 'Categoria', A.ImagenUrl, A.Precio from ARTICULOS A, CATEGORIAS C, MARCAS M where M.Id = A.IdMarca and C.Id = A.IdCategoria order by ";
                switch (criterio)
                {
                    case "Código A-Z": consulta += "A.Codigo asc";
                        break;

                    case "Código Z-A": consulta += "A.Codigo desc";
                        break;

                    case "Mayor precio": consulta += "A.Precio desc";
                        break;

                    case "Menor precio": consulta += "A.Precio asc";
                        break;

                    default:
                        break;
                }

                accesos.SetConsulta(consulta);
                accesos.exeLectura();

                while (accesos.Reader.Read())
                {
                    ClassArticulo Aux = new ClassArticulo();
                    Aux.ID = (int)accesos.Reader["Id P"];
                    Aux.Nombre = (string)accesos.Reader["Nombre"];
                    Aux.Codigo = (string)accesos.Reader["Codigo"];
                    Aux.Descripción = (string)accesos.Reader["Descripcion"];
                    Aux.Marcas = new Marcas();
                    Aux.Marcas.ID = (int)accesos.Reader["Id Marca"];
                    Aux.Marcas.Marca = (string)accesos.Reader["Marca"];
                    Aux.Categorias = new Categorias();
                    Aux.Categorias.ID = (int)accesos.Reader["Id Categoria"];
                    Aux.Categorias.Categoria = (string)accesos.Reader["Categoria"];
                    if (!(accesos.Reader["ImagenURL"] is DBNull))
                    {
                        Aux.ImagenURL = (string)accesos.Reader["ImagenURL"];
                    }
                    Aux.Precio = (decimal)accesos.Reader["Precio"];

                    ListaOrdenada.Add(Aux);
                }

                return ListaOrdenada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesos.CloseConecction();
            }
        }
    }
}
