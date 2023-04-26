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
    public partial class VerH : ContentPage
    {
        public VerH()
        {
            InitializeComponent();
        }
        private void btnVolver_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Vend());
        }
    }
}