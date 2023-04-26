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
    public partial class VerOrden : ContentPage
    {
        public VerOrden()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            IList<OrdenModel> register = await App.SQLiteDBO.GetOrdenAsync();
            lstHistoria.ItemsSource = register;
        }
        // Método para invocar a la pagina de contenido de registrar nuevo usuario
        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new OrdenMed
            {
                BindingContext = new OrdenModel()
            });
        }
        // Método para seleccionar y vincular los datos con la pagina, para editar y eliminar
        private async void lstHistoria_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushModalAsync(new EditOrden
                {
                    BindingContext = e.SelectedItem as OrdenModel
                });
            }
        }

        private void bntsalir_Clicked(object sender, EventArgs e)
        {

        }
    } 
}