using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Black_Jack
{
    public partial class Game : Form
    {

        ConexionDB bd;
        Thread a, juego, resultado;
        int contadorcartasthis = 0;
        int contadorcartaslast = 0;
        Usuario usuario;
        int idenemigo;
        int cartasumada = 0;
        [Obsolete]
        public Game(Usuario usuario)
        {
            InitializeComponent();
            bd = new ConexionDB();
            this.usuario = usuario;
            CheckForIllegalCrossThreadCalls = false;
            a = new Thread(analisis);
            juego = new Thread(jugabilidad);
            resultado = new Thread(resultados);
            if (bd.coneectar())
            {
                a.Start();
            }
            if (usuario != null)
            {
                if (usuario.Id == 1)
                {
                    MessageBox.Show("player 1\nWelcome Player 1");
                    bd.actualiazarPedir(usuario.Id, 1);
                    idenemigo = 2;
                    
                }
                else
                {
                    MessageBox.Show("player 2\nWelcome Player 2");
                    idenemigo = 1;                 
                }
                bd.actualizarActivo(usuario.Id, 1);
            }
        }
        [Obsolete]
        public void resultados()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (bd.JugadoresPlantados())
                {                   
                  
                    Resultado res = new Resultado(usuario,idenemigo);
                    res.Show();
                    this.Visible = false;
                    break;
                }

            }
        }
     
        public void analisis()
        {
            while (true)
            {
                Thread.Sleep(4000);
                if (bd.verficacionPlayers())
                {
                    MessageBox.Show("Falta Jugador");
                }
                else
                {
                    if (bd.empieza(usuario.Id))
                    {
                        btpedir.Visible = true;
                        btplantar.Visible = true;
                        btpedir.Enabled = true;
                        btplantar.Enabled = true;
                        bd.actualiazarPedir(usuario.Id, 0);
                    }
                    else
                    {
                        btpedir.Visible = false;
                        btplantar.Visible = false;
                    }
                    juego.Start();
                    break;
                }
            }
        }
        public void jugabilidad()
        {
            while (true)
            {
                Thread.Sleep(300);
                Console.WriteLine("" + bd.empieza(idenemigo));
                if (bd.empieza(idenemigo))
                {
                    animacion2.Visible = true;
                    animacion2.Location = new Point(810, 30);
                    int x = animacion2.Location.X;
                    int y = animacion2.Location.Y;
                    while (animacion2.Location.Y != 115)
                    {
                        x -= 40;
                        y += 5;
                        animacion2.Location = new Point(x, y);                      
                        this.Refresh();
                    }
                    animacion2.Visible = false;
                    if (contadorcartaslast == 0)
                    {
                        imgDefecto.Image = Image.FromFile("atras.jpg");
                    }
                    else if (contadorcartaslast == 1)
                    {
                        imgLast1.Visible = true;
                    }
                    else if (contadorcartaslast == 2)
                    {
                        imgLast2.Visible = true;
                    }
                    else if (contadorcartaslast == 3)
                    {
                        imgLast3.Visible = true;
                    }
                    else if (contadorcartaslast == 4)
                    {
                        imgLast4.Visible = true;
                    }
                    else if (contadorcartaslast == 5)
                    {
                        imgLast5.Visible = true;
                    }
                    contadorcartaslast++;
                    this.Refresh();
                    Application.DoEvents();
                }
                else if (bd.isPlanted(idenemigo))
                {
                    if (bd.isPlanted(usuario.Id))
                    {
                        btpedir.Visible = false;
                        btplantar.Visible = false;
                        btpedir.Enabled = false;
                        btplantar.Enabled = false;
                        break;
                    }
                    btpedir.Visible = true;
                    btplantar.Visible = true;
                    btpedir.Enabled = true;
                    btplantar.Enabled = true;
                    break;
                }
                Application.DoEvents();
            }

        }

        private void btpedir_Click(object sender, EventArgs e)
        {
            animacion.Visible = true;
            bd.actualiazarPedir(usuario.Id, 1);
            animacion.Location = new Point(810, 30);
            int x = animacion.Location.X;
            int y = animacion.Location.Y;
            while (animacion.Location.Y != 540)
            {
                x -= 40;
                y += 30;
                animacion.Location = new Point(x, y);
                this.Refresh();
            }
            bd.actualiazarPedir(usuario.Id, 0);
            animacion.Location = new Point(810, 30);
            animacion.Visible = false;
            Random random;
            int carta=0;
            try
            {
                random = new Random();
                carta = random.Next(1, 14);
            }
            catch (Exception)
            {
                Console.WriteLine("aqui esta el erroro");
            }
            
            bd.PedirCartas(usuario.Id, carta);
            if (carta > 10)
            {
                cartasumada += 10;
            }
            else
            {
                cartasumada += carta;
            }
            suma.Text = "Cartas Sumadas : " + cartasumada;
            if (contadorcartasthis == 0)
            {
                imgDefecto2.Image = Image.FromFile(carta + ".png");
            }
            else if (contadorcartasthis == 1)
            {
                imgThis1.Image = Image.FromFile(carta + ".png"); imgThis1.Visible = true;
            }
            else if (contadorcartasthis == 2)
            {
                imgThis2.Image = Image.FromFile(carta + ".png"); imgThis2.Visible = true;
            }
            else if (contadorcartasthis == 3)
            {
                imgThis3.Image = Image.FromFile(carta + ".png"); imgThis3.Visible = true;
            }
            else if (contadorcartasthis == 4)
            {
                imgThis4.Image = Image.FromFile(carta + ".png"); imgThis4.Visible = true;
            }
            else if (contadorcartasthis == 5)
            {
                imgThis5.Image = Image.FromFile(carta + ".png"); imgThis5.Visible = true;
            }
            contadorcartasthis++;

            if (cartasumada > 21)
            {
                suma.Text = "Se paso :" + cartasumada;
                btpedir.Visible = false;
                btplantar.Visible = false;
                bd.plantar(usuario.Id);
                bd.actualiazarPedir(usuario.Id, 0);
                resultado.Start();
            }
            this.Refresh();
            Application.DoEvents();
        }

        private void Game_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (bd.coneectar())
            {
                bd.Reiniciar();
            }
        }

        private void btplantar_Click(object sender, EventArgs e)
        {
            btpedir.Visible = false;
            btplantar.Visible = false;
            bd.plantar(usuario.Id);
            bd.actualiazarPedir(usuario.Id, 0);
            resultado.Start();
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bd.coneectar())
            {
                bd.Reiniciar();
                bd.cerrarconexion();
            }
        }

    }
}

