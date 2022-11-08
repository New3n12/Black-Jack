using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Black_Jack
{
    public partial class Form1 : Form
    {
        ConexionDB conexionDB;
        public Form1()
        {
            InitializeComponent();
            conexionDB = new ConexionDB();
        }

        [Obsolete]
        private void button1_Click(object sender, EventArgs e)
        {
            if (conexionDB.coneectar())
            {
                Game juego = new Game(conexionDB.players());
                juego.Show();
                this.Visible = false;

            }
            else
            {
                MessageBox.Show("Hubo un problema con la conexion\nVerifique su conexion..!!");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conexionDB.coneectar())
            {
                conexionDB.Reiniciar();

            }
        }
    }
}
