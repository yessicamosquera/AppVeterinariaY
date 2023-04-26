using AppVeterinariaY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVeterinariaY.Views.Administrador
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroEmp : MasterDetailPage
    {
        public RegistroEmp()
        {
            InitializeComponent();
            Master = new Menu();
            App.Modificador = this;
            usuariotxt.ReturnCommand = new Command(() => Conttxt.Focus());
        }
        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                UsuariosModel user = new UsuariosModel
                {

                    nombre = Nombretxt.Text,
                    Usuario = usuariotxt.Text,
                    Contraseña = Conttxt.Text,
                    Idrol = rolePicker.SelectedIndex + 1


                };
                await App.SQLiteDB.SaveUserAsync(user);
                var UserList = await App.SQLiteDB.GetUserAsync();
                await DisplayAlert("Registro", "El usuario se guardó de manera exitosa", "ok");
                Limpiar();
            }
            else
            {
                await DisplayAlert("Alerta", "Ingresar todos los datos", "ok");
            }
        }
        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(Idcedulatxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(Nombretxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(usuariotxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(Conttxt.Text))
            {
                respuesta = false;
            }
            {
                respuesta = true;
            }
            return respuesta;
        }

        public void Limpiar()
        {
            Idcedulatxt.Text = "";
            Nombretxt.Text = "";
            usuariotxt.Text = "";
            Conttxt.Text = "";
            rolePicker = null;


        }

        private void bntsalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Admin());
        }
    }
}