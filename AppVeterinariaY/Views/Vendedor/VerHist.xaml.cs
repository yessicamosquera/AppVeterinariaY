using AppVeterinariaY.Model;
using AppVeterinariaY.Views.Medico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVeterinariaY.Views.Vendedor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerHist : ContentPage
    {
        public VerHist()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            IList<HistoriaClinicaModel> register = await App.SQLiteDBH.GetHistoriaAsync();
            lstHistoria.ItemsSource = register;
        }
        // Método para invocar a la pagina de contenido de registrar nuevo usuario
        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HistoriaClinica
            {
                BindingContext = new HistoriaClinicaModel()
            });
        }
        // Método para seleccionar y vincular los datos con la pagina, para editar y eliminar
        private async void lstHistoria_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushModalAsync(new VerH
                {
                    BindingContext = e.SelectedItem as HistoriaClinicaModel
                });
            }
        }
    }
}