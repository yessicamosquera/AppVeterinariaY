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
    public partial class Admin : MasterDetailPage
    {
        public Admin()
        {
            InitializeComponent();
            Master = new Menu();
            Detail = new NavigationPage(new Registro());
            App.Modificador = this;
        }
    }
}