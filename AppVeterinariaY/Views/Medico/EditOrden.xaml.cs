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
    public partial class EditOrden : ContentPage
    {
        OrdenModel registro = new OrdenModel();
        public EditOrden()
        {
            InitializeComponent();
        }
        private async void btnModificarOrden_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Idordentxt.Text))
            {
                OrdenModel Usuario = new OrdenModel()
                {
                    Idorden = (int)Convert.ToInt64(Idordentxt.Text),
                    medicamento = medicamentotxt.Text,
                    dosis = (decimal)Convert.ToDecimal(dosistxt.Text),
                };
                await App.SQLiteDBO.UpdateOrdenAsync(Usuario);
                await DisplayAlert("Actualizar", "La orden medica se actualizó de manera exitosa", "ok");
                await Navigation.PushModalAsync(new VerOrden());
                Limpiar();
                Idordentxt.IsVisible = false;
                btnModificarOrden.IsVisible = false;



            }

        }

        private async void btnEliminarOrden_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Confirmar", "Estas seguro de eliminar la orden medica", "Aceptar", "Cancelar");
            if (result)
            {
                registro = (OrdenModel)BindingContext;
                await App.SQLiteDBO.DeleteOrdenAsync(registro);
                await Navigation.PushModalAsync(new VerOrden());
            }
            else

                return;
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

        private void bntsalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Veterinario());
        }
    }
}