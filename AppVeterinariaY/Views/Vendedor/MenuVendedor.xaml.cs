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
    public partial class MenuVendedor : ContentPage
    {
        public MenuVendedor()
        {
            InitializeComponent();
        }
        private async void VerHistoriaTxt_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new VerHist());

        }

        private void salir1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }

        private async void Ordenes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new VerlistaOrden());
        }
    }
}