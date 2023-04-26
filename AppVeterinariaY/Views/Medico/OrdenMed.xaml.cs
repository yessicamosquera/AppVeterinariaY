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
    public partial class OrdenMed : ContentPage
    {
        public OrdenMed()
        {
            InitializeComponent();
        }
        private void bntsalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Veterinario());
        }

        private async void btnGuardarOrden_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                OrdenModel Hist = new OrdenModel
                {


                    medicamento = medicamentotxt.Text,
                    dosis = decimal.Parse(dosistxt.Text),


                };
                await App.SQLiteDBO.SaveOrdenAsync(Hist);
                var HistList = await App.SQLiteDBO.GetOrdenAsync();
                await DisplayAlert("Registro", "La orden medica se guardó de manera exitosa", "ok");
                Limpiar();
            }
            else
            {
                await DisplayAlert("Alerta", "Ingresar todos los datos", "ok");
            }
        }
        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(Idordentxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(medicamentotxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(dosistxt.Text))
            {
                respuesta = false;
            }
            {
                respuesta = true;
            }
            return respuesta;
        }

        public void Limpiar()
        {
            Idordentxt.Text = "";
            medicamentotxt.Text = "";
            dosistxt.Text = "";
        }

    }
}