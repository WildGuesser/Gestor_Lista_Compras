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
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        App app;
        public AddItem()
        {
            InitializeComponent();
            app = App.Current as App;
            //app.view_items.LV_items.ItemsSource = app.modelAddList.itemDaListas;

        }

        private void BT_AddToList_Click(object sender, RoutedEventArgs e)
        {
            if (app.modelAddList.btn_flag == false)
            app.modelAddList.AdicionaItemList(app.modelAddList.nomeLista, TB_Nome.Text, TB_Quantidade.Text, CB_Categoria.Text);

            else
            {
                try
                {
                    app.modelAddList.EditarItemList(app.modelAddList.nomeLista, TB_Nome.Text, TB_Quantidade.Text, CB_Categoria.Text);
                    
                }

                catch (TextoInvalidoExeption erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }

            this.Close();
        }

        private void BT_Categoria_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                app.modelAddList.AddCategoria(TB_Nova_Categoria.Text);

                CB_Categoria.Items.Clear();

                foreach (var categoria in app.modelAddList.Categorias)
                {
                   
                    CB_Categoria.Items.Add(categoria.Nome_Categoria);
                }

                LV_Categorias.ItemsSource = app.modelAddList.Categorias;
                LV_Categorias.Items.Refresh();
               
            }
               catch (TextoInvalidoExeption erro)
            {
                MessageBox.Show(erro.Message);
            }
        
        }

        private void BT_Retirar_Categoria_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                app.modelAddList.RemoveCategoria(((Categoria)(LV_Categorias.SelectedItem)).Nome_Categoria);
                CB_Categoria.Items.Clear();

                foreach (var categoria in app.modelAddList.Categorias)
                {
                    CB_Categoria.Items.Add(categoria.Nome_Categoria);
                }

                LV_Categorias.ItemsSource = app.modelAddList.Categorias;
                LV_Categorias.Items.Refresh();
                

            }
            catch (TextoInvalidoExeption erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            app.modelAddList.LoadCategoriasXML();
            CB_Categoria.Items.Clear();

            if (app.modelAddList.Categorias.Count > 0)
            {
                foreach(var categoria in app.modelAddList.Categorias)
                {
                    CB_Categoria.Items.Add(categoria.Nome_Categoria);
                }
                
                LV_Categorias.ItemsSource = app.modelAddList.Categorias;
                LV_Categorias.Items.Refresh();
                
            }
        }

        private void BT_Sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddItem1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            app.modelAddList.SaveCategoriasXML();
            app.view_items.LV_items.ItemsSource = app.modelAddList.Listas[app.view_listas.LV_Listas.SelectedIndex].itemDaListas;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(app.view_items.LV_items.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Categoria");
            view.GroupDescriptions.Clear();
            view.GroupDescriptions.Add(groupDescription);
            app.view_items.LV_items.Items.Refresh();

            this.Visibility = Visibility.Collapsed;
            e.Cancel = true;
        }

    }
}
