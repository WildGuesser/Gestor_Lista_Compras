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
    /// Interaction logic for Editar.xaml
    /// </summary>
    public partial class Editar : Window
    {
        App app;
        private string nomeAntigo;
        public Editar()
        {
            InitializeComponent();
            app = App.Current as App;
        }

        private void BT_sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            TB_NomeListaEditar.Text = app.modelAddList.nomeAntigo;
        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
            app.modelAddList.EditLista(TB_NomeListaEditar.Text);
            this.Close();
            app.view_listas.LV_Listas.ItemsSource = app.modelAddList.Listas;
            app.view_listas.LV_Listas.Items.Refresh();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            e.Cancel = true;
        }
    }
}
