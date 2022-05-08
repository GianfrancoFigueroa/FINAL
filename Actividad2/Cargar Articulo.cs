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
        
        private ClassArticulo Articulo = null;

        public Cargar_Articulo()
        {
            InitializeComponent();
        }

        public Cargar_Articulo(ClassArticulo articulo)
        {
            InitializeComponent();
            this.Articulo = articulo;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)  
        {
            
            ArticulosListado datos = new ArticulosListado();
            try
            {
                if(Articulo == null)
                {
                    ClassArticulo Articulo = new ClassArticulo();
                }

                Articulo.Codigo = TxbCodigo.Text;
                Articulo.Nombre = TxbNombre.Text;
                Articulo.Descripción = TxbDescrip.Text;
                Articulo.Marcas = (Marcas)CbMarcar.SelectedItem;
                Articulo.Categorias = (Categorias)CbCategoria.SelectedItem;
                Articulo.ImagenURL = txbImagen.Text;
                Articulo.Precio = decimal.Parse(TxbPrecio.Text);

                if(Articulo.ID != 0)
                {
                    datos.update(Articulo);
                    MessageBox.Show("ARTICULO MODIFICADO");
                    Close();
                }
                else
                {
                    datos.insert(Articulo);
                    MessageBox.Show("ARTICULO CARGADO");
                    Close();
                }
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

                if(Articulo != null)
                {
                    TxbCodigo.Text = Articulo.Codigo;
                    TxbNombre.Text = Articulo.Nombre;
                    TxbDescrip.Text = Articulo.Descripción;
                    txbImagen.Text = Articulo.ImagenURL;
                    CargarImagen(Articulo.ImagenURL);
                    TxbPrecio.Text = Articulo.Precio.ToString();
                    CbCategoria.SelectedValue = Articulo.Categorias.ID;
                    CbMarcar.SelectedValue = Articulo.Categorias.ID;
                }
                

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.ToString());
            }
        }

        private void txbImagen_Leave(object sender, EventArgs e)
        {
            CargarImagen(txbImagen.Text);
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
    }
}
