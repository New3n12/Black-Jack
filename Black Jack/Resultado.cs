using Black_Jack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Black_Jack
{
    public partial class Resultado : Form
    {
        ConexionDB db;
        int suma = 0;
        int contador = 1;
        Usuario usu;
        int idenemigo;
        public Resultado(Usuario usu,int idenemigo)
        {
            InitializeComponent();
            db = new ConexionDB();
            this.usu = usu;
            this.idenemigo = idenemigo;
            
        }

        private void Resultado_Load(object sender, EventArgs e)
        {
            if (db.coneectar())
            {
                LinkedList<int> lista = db.cartasGanador(usu.Id);
                foreach (int x in lista)
                {
                    if (x > 10)
                    {
                        suma += 10;
                    }
                    else
                    {
                        suma += x;
                    }
                }
                if (suma <= 21)
                {
                    foreach (int x in lista)
                    {
                        if (contador == 1)
                        {
                            carta1.Image = Image.FromFile(x + ".png");
                        }
                        if (contador == 2)
                        {
                            carta2.Image = Image.FromFile(x + ".png");
                        }
                        if (contador == 2)
                        {
                            carta2.Image = Image.FromFile(x + ".png");
                        }
                        if (contador == 3)
                        {
                            carta3.Image = Image.FromFile(x + ".png");
                        }
                        if (contador == 4)
                        {
                            carta4.Image = Image.FromFile(x + ".png");
                        }
                        if (contador == 5)
                        {
                            carta5.Image = Image.FromFile(x + ".png");
                        }
                        contador++;
                    }
                    label1.Text += usu.Id;
                   // MessageBox.Show("Ganador Jugador " + usu.Id);
                }
                else
                {
                    suma = 0;
                    LinkedList<int> lista2 = db.cartasGanador(idenemigo);
                    foreach (int x in lista2)
                    {
                        if (x > 10)
                        {
                            suma += 10;
                        }
                        else
                        {
                            suma += x;
                        }
                    }
                    if (suma <= 21)
                    {
                        foreach (int x in lista2)
                        {
                            if (contador == 1)
                            {
                                carta1.Image = Image.FromFile(x + ".png");
                            }
                            if (contador == 2)
                            {
                                carta2.Image = Image.FromFile(x + ".png");
                            }
                            if (contador == 2)
                            {
                                carta2.Image = Image.FromFile(x + ".png");
                            }
                            if (contador == 3)
                            {
                                carta3.Image = Image.FromFile(x + ".png");
                            }
                            if (contador == 4)
                            {
                                carta4.Image = Image.FromFile(x + ".png");
                            }
                            if (contador == 5)
                            {
                                carta5.Image = Image.FromFile(x + ".png");
                            }
                            contador++;
                        }
                        //  MessageBox.Show("Ganador Jugador " + idenemigo);
                        label1.Text += idenemigo;

                    }
                    else
                    {                      
                        db.Reiniciar();
                        label1.Text += "Ningun jugador gano";
                        //  MessageBox.Show("Ningun jugador gano");
                        // this.Close();
                    }
                }
            }
        }

    }
}

