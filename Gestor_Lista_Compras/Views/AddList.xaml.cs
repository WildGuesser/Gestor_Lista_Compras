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
    /// Interaction logic for AddList.xaml
    /// </summary>
    public partial class AddList : Window
    {
        App app;
        public AddList()
        {
            InitializeComponent();
            app = App.Current as App;
           
        }


        private void BT_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Invocação do método do model
                app.modelAddList.AddLista(TB_NomeLista.Text);
                this.Close();
            }
   
            catch (TextoInvalidoExeption erro)
            {
                MessageBox.Show(erro.Message);
            }
           
         
        }

        private void BT_sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TB_NomeLista.Clear();
        }
    }
}
