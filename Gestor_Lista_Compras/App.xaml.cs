using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Gestor_Lista_Compras
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //models
        public ModelLogin modelLogin;
        public ModelAddList modelAddList;
        public ModelSignUp modelSignUp;
        

        //views
        public View_Listas view_listas;
        public View_Items view_items;
        public View_SignUP view_signUP;
        public AddList addList;
        public AddItem addItem;
        public Editar editarLista;
     


        public App()
        {
            modelLogin = new ModelLogin();
            modelAddList = new ModelAddList();
            modelSignUp = new ModelSignUp();

            view_listas = new View_Listas();
            view_items = new View_Items();
            view_signUP = new View_SignUP();
            addList = new AddList();
            addItem = new AddItem();
            editarLista = new Editar(); 
        }
    }
}
