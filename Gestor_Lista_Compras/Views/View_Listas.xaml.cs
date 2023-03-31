using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gestor_Lista_Compras
{
    /// <summary>
    /// Interaction logic for View_Listas.xaml
    /// </summary>
    public partial class View_Listas : Window
    {
        App app;


        public View_Listas()
        {
            InitializeComponent();
            //VisualizaRepositorio();
            app = App.Current as App;
            app.modelAddList.ListaAdiciona += ModelAddList_ListaAdiciona;
            

        }

        //private void VisualizaRepositorio()
        //{
        //    if(app.modelAddList.Listas != null)
        //    LV_Listas.ItemsSource = app.modelAddList.Listas;

        //}
        private void ModelAddList_ListaAdiciona()
        {
            LV_Listas.ItemsSource = app.modelAddList.Listas;
            LV_Listas.Items.Refresh();
        }

   


        private void mItem_adicionar_Click(object sender, RoutedEventArgs e)
        {
            app.addList.Show();
        }

        private void BT_Abrir_Click(object sender, RoutedEventArgs e)
        {
            if(LV_Listas.SelectedItem.ToString() != null)
            app.modelAddList.nomeLista =((Lista)(LV_Listas.SelectedItem)).NomeLista;

            app.view_items.Title = app.modelAddList.nomeLista;
            app.view_items.LV_items.ItemsSource = app.modelAddList.Listas[app.view_listas.LV_Listas.SelectedIndex].itemDaListas;
           
            //Separar por Categoria
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(app.view_items.LV_items.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Categoria");
            view.GroupDescriptions.Clear();
            view.GroupDescriptions.Add(groupDescription);

            app.view_items.Show();

            
        }

        private void BT_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            
               
            try
            {
                //Invocação do método do model
                app.modelAddList.RemoveLista(((Lista)(LV_Listas.SelectedItem)).NomeLista);
                LV_Listas.ItemsSource = app.modelAddList.Listas;
                
                LV_Listas.Items.Refresh();
            }
            catch (TextoInvalidoExeption erro)
            {
                MessageBox.Show(erro.Message);
            }


        }
        private void mItem_editarNome_Click(object sender, RoutedEventArgs e)
        {
            app.modelAddList.nomeAntigo = ((Lista)(LV_Listas.SelectedItem)).NomeLista;
            app.editarLista.Show();
            LV_Listas.ItemsSource = app.modelAddList.Listas;
            LV_Listas.Items.Refresh();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        { 
                app.modelAddList.LoadListaXML();
                LV_Listas.ItemsSource = app.modelAddList.Listas;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = Visibility.Visible;
            e.Cancel = true;
        }

        private void mItem_Guardar_Click(object sender, RoutedEventArgs e)
        {
            app.modelAddList.SaveListaXML();
        }
    }
}
