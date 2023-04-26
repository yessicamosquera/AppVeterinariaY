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
    public partial class VerOrden : ContentPage
    {
        public VerOrden()
        {
            InitializeComponent();
        }
        private void btnVolverOrden_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Vend());
        }

        private void bntsalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Vend());
        }
    }
}