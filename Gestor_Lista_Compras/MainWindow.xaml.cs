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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gestor_Lista_Compras
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        App app;
        public MainWindow()
        {
            InitializeComponent();
            app = App.Current as App;
            app.modelLogin.LoginFeito += ModelLogin_LoginFeito;
        }

        private void ModelLogin_LoginFeito()
        {
            app.view_listas.Show();
        }

        private void BT_Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                app.modelLogin.CheckLogin(TB_User.Text, TB_Pass.Text);
            }
            catch (LoginInvalidoExemption erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void BT_Sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BT_Registar_Click(object sender, RoutedEventArgs e)
        {
            app.view_signUP.Show();
        }
    }
}

