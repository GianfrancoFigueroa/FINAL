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
            ArticulosListado articulos = new ArticulosListado();
            ArticulosAux = articulos.Listado();  
            dataGridView1.DataSource = articulos.Listado();
            CargarImagen(ArticulosAux[0].ImagenURL);
        }

        private void buttonAg_Click(object sender, EventArgs e)
        {
            Cargar_Articulo cargar_Articulo = new Cargar_Articulo();
            cargar_Articulo.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           ClassArticulo Seleccionado = (ClassArticulo)dataGridView1.CurrentRow.DataBoundItem;
           CargarImagen(Seleccionado.ImagenURL);
        }

        private void CargarImagen(string imagen)
        {
            try
            {
                pictureBox1.Load(imagen);
            }
            catch (Exception)
            {
                pictureBox1.Load("https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg");
                
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
