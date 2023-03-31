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
    /// Interaction logic for View_SignUP.xaml
    /// </summary>
    public partial class View_SignUP : Window

    {
        App app;
        public View_SignUP()
        {
            InitializeComponent();
            app = App.Current as App;

            app.modelSignUp.registado += ModelSignUp_registado;
            app.modelSignUp.nao_registado += ModelSignUp_nao_registado;
        }

        private void ModelSignUp_nao_registado(string valor)
        {
            MessageBox.Show(valor);
        }

        private void ModelSignUp_registado(string valor)
        {
            MessageBox.Show(valor);
        }

        private void BT_Registar_Click(object sender, RoutedEventArgs e)
        {
            if (TB_User != null && TB_Pass != null && TB_Pais != null && TB_Mail != null)
            {
                app.modelSignUp.RegisterUser(TB_User.Text, TB_Pass.Text, TB_Pais.Text, TB_Mail.Text);
            }
        }
    }
}
