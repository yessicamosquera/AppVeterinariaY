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
    public partial class VistaEmpleados : ContentPage
    {
        public VistaEmpleados()
        {
            InitializeComponent();
        }
        // Método para enlazar los datos con el ListView
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            IList<UsuariosModel> register = await App.SQLiteDB.GetUserAsync();
            lstUser.ItemsSource = register;
        }
        // Método para invocar a la pagina de contenido de registrar nuevo usuario
        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistroEmp
            {
                BindingContext = new UsuariosModel()
            });
        }
        // Método para seleccionar y vincular los datos con la pagina, para editar y eliminar
        async void lstUser_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushModalAsync(new EditOEliminarEmp
                {
                    BindingContext = e.SelectedItem as UsuariosModel
                });
            }
        }

        private void bntsalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Admin());
        }
    }
}