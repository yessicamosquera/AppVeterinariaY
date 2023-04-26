using AppVeterinariaY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVeterinariaY.Views.Medico
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerPaciente : ContentPage
    {
        public VerPaciente()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            IList<MascotaModel> register = await App.SQLiteDBM.GetMascotaAsync();
            lstHistoria.ItemsSource = register;
        }
        // Método para invocar a la pagina de contenido de registrar nueva mascota
        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistroPac
            {
                BindingContext = new MascotaModel()
            });
        }
        // Método para seleccionar y vincular los datos con la pagina, para editar y eliminar
        private async void lstHistoria_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushModalAsync(new EditPaciente
                {
                    BindingContext = e.SelectedItem as MascotaModel
                });
            }
        }

        private void bntsalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Veterinario());
        }
    }
}