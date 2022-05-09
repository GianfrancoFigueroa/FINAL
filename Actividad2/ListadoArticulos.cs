using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;
using Conexiones;

namespace Actividad2
{
    public partial class ListadoArticulos : Form
    {
        public ListadoArticulos()
        {
            InitializeComponent();
        }

        private List<ClassArticulo> ArticulosAux;

        private void ListadoArticulos_Load(object sender, EventArgs e)
        {
            DatosGrid();
            CategoriaListado categoria = new CategoriaListado();
            MarcasListado marcas = new MarcasListado();

            CbCategoria.DataSource = categoria.Listado();
            CbCategoria.ValueMember = "Id";
            CbCategoria.DisplayMember = "Categoria";
            CbMarca.DataSource = marcas.Listado();
            CbMarca.ValueMember = "Id";
            CbMarca.DisplayMember = "Marca";
            CbOrdenar.Items.Add("Código A-Z");
            CbOrdenar.Items.Add("Código Z-A");
            CbOrdenar.Items.Add("Menor precio");
            CbOrdenar.Items.Add("Mayor precio");
            BorrarCB();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                ClassArticulo Seleccionado = (ClassArticulo)dataGridView1.CurrentRow.DataBoundItem;
                CargarImagen(Seleccionado.ImagenURL);
            }
        }
        
        //CARGAR IMAGEN ACA ABAJO
        private void CargarImagen(string imagen)
        {
            try
            {
                pictureBox1.Load(imagen);
            }
            catch (Exception)
            {
                pictureBox1.Load("https://www.agora-gallery.com/advice/wp-content/uploads/2015/10/image-placeholder.png");
                
            }
            
        }

        //ACA SE CARGA LA LISTA DECLARADA ARRIBA
        private void DatosGrid()
        {
            ArticulosListado articulos = new ArticulosListado();
            try
            {
                ArticulosAux = articulos.Listado();
                dataGridView1.DataSource = ArticulosAux;
                OcultarColumns();
                CargarImagen(ArticulosAux[0].ImagenURL);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void OcultarColumns()
        {
            dataGridView1.Columns["ImagenURL"].Visible = false;
            dataGridView1.Columns["ID"].Visible = false;
        }

        private void buttonAg_Click_1(object sender, EventArgs e)
        {
            Cargar_Articulo cargar_Articulo = new Cargar_Articulo();
            cargar_Articulo.ShowDialog();
            DatosGrid();
        }

        private void buttonModi_Click(object sender, EventArgs e)
        {
            ClassArticulo Seleccionado = new ClassArticulo();
            Seleccionado = (ClassArticulo)dataGridView1.CurrentRow.DataBoundItem;
            Cargar_Articulo modificar = new Cargar_Articulo(Seleccionado);
            modificar.ShowDialog();
            DatosGrid();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ArticulosListado articulos = new ArticulosListado();
            ClassArticulo Seleccionado;

            try
            {
                DialogResult result = MessageBox.Show("¿DESEA ELIMINAR EL ARTICULO SELECCIONADO?", "Eliminado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if(result == DialogResult.Yes)
                {
                    Seleccionado = (ClassArticulo)dataGridView1.CurrentRow.DataBoundItem;
                    articulos.delete(Seleccionado);
                    DatosGrid();
                }
            }
            catch (Exception Ex)
            {

                 MessageBox.Show(Ex.ToString());
            }
            
        }

        private void TxbBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<ClassArticulo> Lista;
            string buscar = TxbBusqueda.Text;

            if(buscar != "")
            {
               Lista = ArticulosAux.FindAll(x => x.Nombre.ToUpper().Contains(buscar.ToUpper()) || x.Codigo.ToUpper().Contains(buscar.ToUpper()));
            }
            else
            {
                Lista = ArticulosAux;
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Lista;
            OcultarColumns();
        }

        private void CbMarca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClassArticulo Aux = new ClassArticulo();
            List<ClassArticulo> Lista;
            Aux.Marcas = (Marcas)CbMarca.SelectedItem;
            Aux.Categorias = (Categorias)CbCategoria.SelectedItem;

            if (CbCategoria.SelectedIndex == -1)
            {
                Lista = ArticulosAux.FindAll(x => x.Marcas.ID == Aux.Marcas.ID);
            }
            else
            {
                Lista = ArticulosAux.FindAll(x => x.Categorias.ID == Aux.Categorias.ID && x.Marcas.ID == Aux.Marcas.ID);
            }

            ListaFiltrada(Lista);

        }

        private void ListaFiltrada(List<ClassArticulo> articulos)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = articulos;
            OcultarColumns();
        }

        private void CbCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClassArticulo Aux = new ClassArticulo();
            List<ClassArticulo> Lista;
            Aux.Categorias = (Categorias)CbCategoria.SelectedItem;
            Aux.Marcas = (Marcas)CbMarca.SelectedItem;

            if(CbMarca.SelectedIndex == -1)
            {
                Lista = ArticulosAux.FindAll(x => x.Categorias.ID == Aux.Categorias.ID);
            }
            else
            {
                Lista = ArticulosAux.FindAll(x => x.Categorias.ID == Aux.Categorias.ID && x.Marcas.ID == Aux.Marcas.ID);
            }

            ListaFiltrada(Lista);
            OcultarColumns();
        }

        private void BorrarCB()
        {
            CbCategoria.SelectedIndex = -1;
            CbMarca.SelectedIndex = -1;
            CbOrdenar.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BorrarCB();
            DatosGrid();
        }

        private void CbOrdenar_SelectionChangeCommitted(object sender, EventArgs e)
        {

                ArticulosListado Ordenar = new ArticulosListado();
                string Criterio = CbOrdenar.Text;
                ListaFiltrada(Ordenar.Ordenar(Criterio));
            
        }
    }
}
