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
    /// Interaction logic for View_Items.xaml
    /// </summary>
    public partial class View_Items : Window
    {
        App app;
        public View_Items()
        {
            InitializeComponent();
            app = App.Current as App;
        }

        private void Adicionar_Item_Click(object sender, RoutedEventArgs e)
        {
            app.addItem.Title = app.modelAddList.nomeLista;
            LV_items.ItemsSource = app.modelAddList.Listas[app.view_listas.LV_Listas.SelectedIndex].itemDaListas;

            app.modelAddList.btn_flag = false;
            app.addItem.ShowDialog();


            LV_items.ItemsSource = app.modelAddList.Listas[app.view_listas.LV_Listas.SelectedIndex].itemDaListas;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LV_items.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Categoria");
            view.GroupDescriptions.Clear();
            view.GroupDescriptions.Add(groupDescription);
            LV_items.Items.Refresh();
        }

        private void Remover_Item_Click(object sender, RoutedEventArgs e)
        {
            app.modelAddList.RemoveItemList(this.Title, ((ItemDaLista)LV_items.SelectedItem).NomeItem);
           
            LV_items.ItemsSource = app.modelAddList.Listas[app.view_listas.LV_Listas.SelectedIndex].itemDaListas;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LV_items.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Categoria");
            view.GroupDescriptions.Clear();
            view.GroupDescriptions.Add(groupDescription);
            LV_items.Items.Refresh();
        }
        private void CM_EditarNome_Click(object sender, RoutedEventArgs e)
        {

            app.modelAddList.nomeAntigo = app.addItem.Title = ((ItemDaLista)LV_items.SelectedItem).NomeItem;
            app.addItem.TB_Nome.Text = ((ItemDaLista)LV_items.SelectedItem).NomeItem;
            app.addItem.CB_Categoria.SelectedItem = ((ItemDaLista)LV_items.SelectedItem).Categoria;
            app.addItem.TB_Quantidade.Text = ((ItemDaLista)LV_items.SelectedItem).Quantidade;
                
            app.modelAddList.btn_flag = true;
            app.addItem.Show();

            LV_items.ItemsSource = app.modelAddList.Listas[app.view_listas.LV_Listas.SelectedIndex].itemDaListas;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LV_items.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Categoria");
            view.GroupDescriptions.Clear();
            view.GroupDescriptions.Add(groupDescription);
            LV_items.Items.Refresh();
           
            

        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = app.modelAddList.nomeLista;
            LV_items.ItemsSource = app.modelAddList.Listas[app.view_listas.LV_Listas.SelectedIndex].itemDaListas;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LV_items.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Categoria");
            view.GroupDescriptions.Clear();
            view.GroupDescriptions.Add(groupDescription);
            LV_items.Items.Refresh();
        }


        private void View_Items1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            this.Visibility = Visibility.Collapsed;
            e.Cancel = true;
           
        }

      
    }

}