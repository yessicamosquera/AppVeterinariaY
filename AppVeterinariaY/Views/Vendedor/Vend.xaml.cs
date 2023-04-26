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
    public partial class Vend : MasterDetailPage
    {
        public Vend()
        {
            InitializeComponent();
            Master = new MenuVendedor();
            Detail = new NavigationPage(new DetailVendedor());
            App.Modificador = this;

        }
    }
}