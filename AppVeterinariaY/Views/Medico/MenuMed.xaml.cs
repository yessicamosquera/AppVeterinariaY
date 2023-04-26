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
    public partial class MenuMed : ContentPage
    {
        public MenuMed()
        {
            InitializeComponent();
        }
        private void salir1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }

        private void Historia1Txt_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HistoriaClinica());
        }

        private void RegistrarpacTxt_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegistroPac());
        }

        private async void VerHistoriaTxt_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new VerHistoria());

        }

        private async void VerpacienteTxt_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new VerPaciente());
        }

        private void Ordenes_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new OrdenMed());
        }

        private async void VerordenTxt_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new VerOrden());
        }
    }
}