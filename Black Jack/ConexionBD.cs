using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;

namespace Black_Jack
{
    public class ConexionDB
    {
        public SqlConnection conn;
        SqlDataReader reader;
        public ConexionDB()
        {

            //conn = new SqlConnection("Data Source=192.168.1.65; Initial Catalog=master;User Id=Juann;Password=1234");
            conn = new SqlConnection("server=NEW3N\\SQLEXPRESS ; database=master ; integrated security = true");
            conn.Open();
            string query2 = "SELECT * FROM Jugadores";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            reader = cmd2.ExecuteReader();
            reader.Close();
            conn.Close();
        }

        public bool coneectar()
        {
            try
            {
               // conn = new SqlConnection("Data Source=192.168.1.70; Initial Catalog=master;User Id=Cliente;Password=1234");
                conn = new SqlConnection("server=NEW3N\\SQLEXPRESS ; database=master ; integrated security = true");
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

        }
        public Usuario players()
        {
            Usuario usuario = new Usuario();
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                string query2 = "SELECT * FROM Jugadores";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    int activo = int.Parse(reader[2].ToString());
                    int id = int.Parse(reader[0].ToString());
                    if (activo == 0)
                    {
                        usuario.Id = id;
                        usuario.Activo = 1;
                        usuario.Planto = 0;
                        reader.Close();
                        break;
                    }
                }
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public string contarCartasPrimerJugador(int idjugador)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                string query2 = "SELECT sum(carta) FROM Historial Where idf='" + idjugador + "'";
                SqlCommand cmd2 = new SqlCommand(query2, conn);

                reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    return reader.GetInt32(0).ToString();
                }

                reader.Close();
                return "0";
            }
            catch (Exception)
            {
                return "èrror";
            }
            finally
            {
                conn.Close();
            }

        }
        public LinkedList<int> cartasGanador(int idjugador)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                LinkedList<int> list = new LinkedList<int>();
                string query2 = "SELECT carta FROM Historial Where idf='" + idjugador + "'";
                SqlCommand cmd2 = new SqlCommand(query2, conn);

                reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    list.AddFirst(int.Parse(reader["carta"].ToString()));
                }
                reader.Close();
                return list;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public void cerrarconexion()
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void PedirCartas(int idJugador, int carta)
        {
            string query = "insert into Historial values (" + idJugador + "," + carta + ")";

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public bool empieza(int id)
        {
            string query2 = "SELECT count(*) FROM Jugadores Where id='" + id + "' and pedir=1";
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                 reader = cmd2.ExecuteReader();
                bool a = false;
                int cont = 0;
                if (reader.Read())
                {
                    cont = reader.GetInt32(0);
                    reader.Close();
                }
                if (cont == 1)
                {
                    a = true;
                }
                else
                {
                    a = false;
                }
                return a;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

        }
        public bool JugadoresPlantados()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                string query2 = "SELECT count(*) FROM Jugadores Where Plantado = 1";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                reader = cmd2.ExecuteReader();                
                bool a = false;
                int cont = 0;
                if (reader.Read())
                {
                    cont = reader.GetInt32(0);
                    reader.Close();
                }
                if (cont == 2)
                {
                    a = true;
                }
                else
                {
                    a = false;
                }
                return a;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

        }
        public bool verficacionPlayers()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                string query2 = "SELECT Count(*) FROM Jugadores Where Activo=1";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                 reader = cmd2.ExecuteReader();
                int i = 0;
                if (reader.Read())
                {
                    i = reader.GetInt32(0);
                    reader.Close();
                }
                if (i == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                conn.Close();
            }

        }

        public void BorrarHistorial()
        {
            string query = "Delete from Historial";

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudo eliminar");

            }
            finally
            {
                conn.Close();
            }

        }
        public void plantar(int id)
        {

            string query = "update jugadores set plantado = 1 where id = " + id;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool isPlanted(int id)
        {

            string query2 = "SELECT count(*) FROM Jugadores Where id='" + id + "' and Plantado=1";
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                 reader = cmd2.ExecuteReader();
                bool a = false;
                int cont = 0;
                if (reader.Read())
                {
                    cont = reader.GetInt32(0);
                    reader.Close();
                }            
                if (cont == 1)
                {
                    a = true;
                }
                else
                {
                    a = false;
                }
                return a;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }


        }

        public void actualizarActivo(int idJugador, int activo)
        {
            string query = "update Jugadores set Activo='" + activo + "' where id=" + idJugador;

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudo actualizar");
            }
            finally
            {
                conn.Close();
            }

        }
        public void actualiazarPedir(int idJugador, int activo)
        {
            string query = "update Jugadores set Pedir='" + activo + "' where id=" + idJugador;

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudo actualizar");
            }
            finally
            {
                conn.Close();
            }
        }



        public void Reiniciar()
        {
            string query = "update Jugadores set Activo=0, Plantado = 0, Pedir = 0";
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudo actualizar");
            }
            finally
            {
                conn.Close();
            }

        }

    }
}
