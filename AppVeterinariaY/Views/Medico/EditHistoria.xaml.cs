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
    public partial class EditHistoria : ContentPage
    {
        HistoriaClinicaModel registro = new HistoriaClinicaModel();
        public EditHistoria()
        {
            InitializeComponent();
        }
        private async void btnModificarHistoria_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(IdHistoriatxt.Text))
            {
                HistoriaClinicaModel Usuario = new HistoriaClinicaModel()
                {
                    Idhistoria = (int)Convert.ToInt64(IdHistoriatxt.Text),
                    Idmascota = (int)Convert.ToInt64(IdMascotatxt.Text),
                    fechaIngreso = fechatxt.Date,
                    motivoConsulta = motivotxt.Text,
                    sintomatologia = sintomatologiatxt.Text,
                    diagnostico = diagnosticotxt.Text,
                    procedimiento = ProcedimientoPicker.SelectedIndex,
                    medicamento = medicamentotxt.Text,
                    dosis = (decimal)Convert.ToDecimal(dosistxt.Text),
                    Idorden = (int)Convert.ToInt64(IdOrdentxt.Text),
                    historialVacunacion = historialtxt.Text,
                    alergias = alergiastxt.Text,
                    detalles = detallestxt.Text,


                };
                await App.SQLiteDBH.UpdateHistoriaAsync(Usuario);
                await DisplayAlert("Actualizar", "La historia se actualizó de manera exitosa", "ok");
                await Navigation.PushModalAsync(new VerHistoria());
                Limpiar();
                IdHistoriatxt.IsVisible = false;
                btnModificarHistoria.IsVisible = false;



            }

        }

        private async void btnEliminarHistoria_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Confirmar", "Estas seguro de eliminar la historia clinica", "Aceptar", "Cancelar");
            if (result)
            {
                registro = (HistoriaClinicaModel)BindingContext;
                await App.SQLiteDBH.DeleteHistoriaAsync(registro);
                await Navigation.PushModalAsync(new VerHistoria());
            }
            else

                return;

        }
        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(IdHistoriatxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(IdMascotatxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(motivotxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(sintomatologiatxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(diagnosticotxt.Text))
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
            else if (string.IsNullOrEmpty(IdOrdentxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(historialtxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(alergiastxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(detallestxt.Text))
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
            IdHistoriatxt.Text = "";
            IdMascotatxt.Text = "";
            motivotxt.Text = "";
            sintomatologiatxt.Text = "";
            diagnosticotxt.Text = "";
            medicamentotxt.Text = "";
            dosistxt.Text = "";
            IdOrdentxt.Text = "";
            historialtxt.Text = "";
            alergiastxt.Text = "";
            detallestxt.Text = "";

        }

        private void bntsalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Veterinario());
        }
    }
}