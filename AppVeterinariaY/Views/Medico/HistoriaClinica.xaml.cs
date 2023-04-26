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
    public partial class HistoriaClinica : ContentPage
    {
        public HistoriaClinica()
        {
            InitializeComponent();
        }
        private async void btnGuardarHistoria_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                HistoriaClinicaModel Hist = new HistoriaClinicaModel
                {
                    Idmascota = int.Parse(IdMascotatxt.Text),
                    fechaIngreso = fechatxt.Date,
                    motivoConsulta = motivotxt.Text,
                    sintomatologia = sintomatologiatxt.Text,
                    diagnostico = diagnosticotxt.Text,
                    procedimiento = ProcedimientoPicker.SelectedIndex + 1,
                    medicamento = medicamentotxt.Text,
                    dosis = decimal.Parse(dosistxt.Text),
                    historialVacunacion = historialtxt.Text,
                    alergias = alergiastxt.Text,
                    detalles = detallestxt.Text,


                };
                await App.SQLiteDBH.SaveHistoriaAsync(Hist);
                var HistList = await App.SQLiteDBH.GetHistoriaAsync();
                await DisplayAlert("Registro", "La historia clinica se guardó de manera exitosa", "ok");
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
            fechatxt.Date = DateTime.Now;
            motivotxt.Text = "";
            sintomatologiatxt.Text = "";
            diagnosticotxt.Text = "";
            medicamentotxt.Text = "";
            dosistxt.Text = "";
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