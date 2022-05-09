using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Actividad2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnCatalogo_Click(object sender, EventArgs e)
        {
            ListadoArticulos listadoArticulos = new ListadoArticulos();
            listadoArticulos.ShowDialog();
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            Cargar_Articulo cargar_Articulo = new Cargar_Articulo();
            cargar_Articulo.ShowDialog();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(" Version 2.8"+
                "\n Developer: Gianfranco Figueroa" +
                "\n Contacto: gianfranco.figueroa@alumnos.frgp.utn.edu.ar", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }
    }
}
