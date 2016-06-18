using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.SqlClient;


namespace Peliculas
{
    public partial class Peliculas : Form
    {
        int numero = 0;
        int Enumero = 0;
        public Peliculas()
        {
            InitializeComponent();
        }
       

        private PeliculaDBEntities dbPelicula = new PeliculaDBEntities();

        private void agregar()
        {
            Peliculas peli = new Peliculas()
            {

                idCategoria = int.Parse(textIdCategoria.Text),
                titulo = texAgregarTitulo.Text,
                signosis = textAgragarSignosis.Text,
                calificacion = textAgregarCalificacion.Text,
                ano = int.Parse(texAgregarAnos.Text),
                idioma = textAgregarIdioma.Text,
                genero = textAgregarGenero.Text
        };
            dbPelicula.Peliculas.Add(peli);
            dbPelicula.SaveChanges();
        
            
           
    }
  private void actualizar(int numero)
        {
            Peliculas peli = (from p in dbPelicula.Peliculas
                              where p.idPeliculas == numero
                              select p).FirstOrDefault();

            peli.idCategoria = int.Parse(textUpdateIDcategoria.Text);
            peli.titulo = textUpdateTitulo.Text;
            peli.signosis = textUpdateSignosis.Text;
            peli.calificacion = textUpdateCalificacion.Text;
            peli.ano = int.Parse(textUpdateAno.Text);
            peli.idioma = textUpdateIdioma.Text;
            peli.genero = textUpdateGenero.Text;

            dbPelicula.SaveChanges();
           
        }
          private void eliminar(int numero)
           {
            Peliculas peli = (from a in dbPelicula.Peliculas
                              where a.idPeliculas == numero
                              select a).FirstOrDefault();

            dbPelicula.Peliculas.Remove(peli);
            dbPelicula.SaveChanges();
           }

       private void listar()
        {
           
            listViewPeliculas.Items.Clear();//para limpriar y que no se dupliquen los datos
                                            // var query = from p in dbPelicula.Peliculas  //permite hacer consultas como si se estuviera en sql service
                                          

           
            int numero = int.Parse(boxBuscar.Text);

            var query = from a in dbPelicula.Peliculas
                        where a.idPeliculas == numero
                        select a;    
            foreach(var item in query)
                {
                ListViewItem list = listViewPeliculas.Items.Add(item.idPeliculas.ToString());
                list.SubItems.Add(item.idCategoria.ToString());
                list.SubItems.Add(item.titulo);
                list.SubItems.Add(item.signosis);
                list.SubItems.Add(item.calificacion);
                list.SubItems.Add(item.ano.ToString());
                list.SubItems.Add(item.idioma);
                list.SubItems.Add(item.genero);

                }

        }
        
        private void botonNuevo_Click(object sender, EventArgs e)
        {

            panelEliminar.Visible = false;
            panelGuardar.Visible = false;
            panelAgregar.Show();
        }

      

        private void panelAgregar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listViewPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void botonAtrasAgregar_Click_1(object sender, EventArgs e)
        {
            panelAgregar.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string n = "";
            agregar();
            MessageBox.Show("Guardado Exitoso");
            texAgregarTitulo.Text = n;
            textAgragarSignosis.Text = n;
            textAgregarCalificacion.Text = n;
            textAgregarGenero.Text = n;
            texAgregarAnos.Text = n;
            textAgregarIdioma.Text = n;
            textIdCategoria.Text = n;
        }

      

       

        private void BotonbuscarCategoria_Click(object sender, EventArgs e)
        {
            listViewPeliculas.Items.Clear();
            int numero = int.Parse(textBuscarCategoria.Text);


            var query = from a in dbPelicula.Peliculas
                        where a.idCategoria == numero
                        select a;

            foreach(var item in query)
            {
                ListViewItem list = listViewPeliculas.Items.Add(item.idPeliculas.ToString());
                list.SubItems.Add(item.idCategoria.ToString());
                list.SubItems.Add(item.titulo);
                list.SubItems.Add(item.signosis);
                list.SubItems.Add(item.calificacion);
                list.SubItems.Add(item.ano.ToString());
                list.SubItems.Add(item.idioma);
                list.SubItems.Add(item.genero);



            }
        }
        private void listarEliminar()
        {
            Enumero = int.Parse(textBuscarIDeliminar.Text);

            using (PeliculaDBEntities dbPeli = new PeliculaDBEntities())
            {
                string tituloBuscar = dbPeli.Peliculas.FirstOrDefault(x => x.idPeliculas == Enumero).titulo.ToString();
                textEliminarTitulo.Text = tituloBuscar;
            }
            
        }
        private void listarUpdate()
        {
           
            numero = int.Parse(textBbuscarIdUpdate.Text);
            //Agregan datos a un texbox.. :D
            using (PeliculaDBEntities dbPeli = new PeliculaDBEntities())
            {
                string  idCategoria = dbPeli.Peliculas.FirstOrDefault(x => x.idPeliculas == numero).idCategoria.ToString();
                string titulo = dbPeli.Peliculas.FirstOrDefault(x=>x.idPeliculas==numero).titulo.ToString();
                string signo = dbPeli.Peliculas.FirstOrDefault(x => x.idPeliculas == numero).signosis.ToString();
                string calificacion = dbPeli.Peliculas.FirstOrDefault(x => x.idPeliculas == numero).calificacion.ToString();
                string an = dbPeli.Peliculas.FirstOrDefault(x => x.idPeliculas == numero).ano.ToString();
                string idiom = dbPeli.Peliculas.FirstOrDefault(x => x.idPeliculas == numero).idioma.ToString();
                string gene = dbPeli.Peliculas.FirstOrDefault(x => x.idPeliculas == numero).genero.ToString();
                textUpdateIDcategoria.Text = idCategoria;
                textUpdateTitulo.Text = titulo;
                textUpdateSignosis.Text = signo;
                textUpdateCalificacion.Text = calificacion;
                textUpdateAno.Text = an;
                textUpdateIdioma.Text = idiom;
                textUpdateGenero.Text = gene;
            }
             

        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            // PanelBuscar.Visible = false;
            panelAgregar.Visible = false;
            panelEliminar.Visible = false;
           panelGuardar.Show();
        }

        private void BotonAtrasUpdate_Click(object sender, EventArgs e)
        {
            panelGuardar.Visible = false;
        }

        
        private void ButtonCambiar_Click(object sender, EventArgs e)
        {
            actualizar(numero);
            MessageBox.Show("Cambios Realizados");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listarUpdate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listarEliminar();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            eliminar(Enumero);
            MessageBox.Show("Eliminado");

        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
          //  PanelBuscar.Visible = false;
            panelAgregar.Visible = false;
            panelGuardar.Visible = false;
            panelEliminar.Show();
        }

        private void BottonEliminarAtras_Click(object sender, EventArgs e)
        {
            panelEliminar.Visible=false;
        }
    }
  }  
   
  

