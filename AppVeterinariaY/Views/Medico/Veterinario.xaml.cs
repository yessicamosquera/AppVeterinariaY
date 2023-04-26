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
    public partial class Veterinario : MasterDetailPage
    {
        public Veterinario()
        {
            InitializeComponent();
            Master = new MenuMed();
            Detail = new NavigationPage(new DetailMed());
            App.Modificador = this;
        }
    }
}