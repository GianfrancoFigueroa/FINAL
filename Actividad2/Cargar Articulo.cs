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
    public partial class Cargar_Articulo : Form
    {
        public Cargar_Articulo()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)  
        {
            ClassArticulo Articulo = new ClassArticulo();
            ArticulosListado Agregar = new ArticulosListado();
            try
            {
                Articulo.Codigo = TxbCodigo.Text;
                Articulo.Nombre = TxbNombre.Text;
                Articulo.Descripción = TxbDescrip.Text;
                Articulo.Marcas = (Marcas)CbMarcar.SelectedItem;
                Articulo.Categorias = (Categorias)CbCategoria.SelectedItem;
                Articulo.Precio = decimal.Parse(TxbPrecio.Text);

                Agregar.insert(Articulo);
                MessageBox.Show("ARTICULO CARGADO");
                Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cargar_Articulo_Load(object sender, EventArgs e)
        {
            CategoriaListado CbCat = new CategoriaListado();
            MarcasListado CbMar = new MarcasListado();
            try
            {
                CbCategoria.DataSource = CbCat.Listado();
                CbCategoria.ValueMember = "Id";
                CbCategoria.DisplayMember = "Categoria";
                CbMarcar.DataSource = CbMar.Listado();
                CbMarcar.ValueMember = "Id";
                CbMarcar.DisplayMember = "Marca";

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.ToString());
            }
        }
    }
}
