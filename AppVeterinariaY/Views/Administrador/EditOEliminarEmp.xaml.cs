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
    public partial class EditOEliminarEmp : ContentPage
    {
        UsuariosModel registro = new UsuariosModel();
        public EditOEliminarEmp()
        {
            InitializeComponent();
        }
        // Métodos para actualizar los datos de un usuario ya registrado
        private async void btnModificarEmpleado_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Idcedulatxt.Text))
            {
                UsuariosModel Usuario = new UsuariosModel()
                {
                    Idcedula = (int)Convert.ToInt64(Idcedulatxt.Text),
                    nombre = Nombretxt.Text,
                    Usuario = usuariotxt.Text,
                    Contraseña = Conttxt.Text,
                    Idrol = rolePicker.SelectedIndex + 1,
                };
                await App.SQLiteDB.UpdateUserAsync(Usuario);
                await DisplayAlert("Registro", "El usuario se actualizó de manera exitosa", "ok");
                await Navigation.PushModalAsync(new VistaEmpleados());
                Limpiar();
                Idcedulatxt.IsVisible = false;
                btnModificarEmpleado.IsVisible = false;



            }
        }


        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Confirmar", "Estas seguro de eliminar el registro", "Aceptar", "Cancelar");
            if (result)
            {
                registro = (UsuariosModel)BindingContext;
                await App.SQLiteDB.DeleteUserAsync(registro);
                await Navigation.PushModalAsync(new VistaEmpleados());
            }
            else

                return;
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

            else
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

        }


    }
}
