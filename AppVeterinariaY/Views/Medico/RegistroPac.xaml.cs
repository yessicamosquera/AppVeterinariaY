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
    public partial class RegistroPac : ContentPage
    {
        public RegistroPac()
        {
            InitializeComponent();
        }
        private void bntsalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Veterinario());
        }

        private async void btnGuardarPaciente_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                MascotaModel user = new MascotaModel
                {
                    nombreMascota = nombremascotatxt.Text,
                    IdcedulaDueño = int.Parse(Idccpropietariotxt.Text),
                    edadMascota = int.Parse(edadmascotatxt.Text),
                    Idespecie = EspeciePicker.SelectedIndex + 1,
                    raza = razatxt.Text,
                    caracteristicas = caractxt.Text,
                    peso = decimal.Parse(pesotxt.Text),


                };
                await App.SQLiteDBM.SaveMascotaAsync(user);
                var UserList = await App.SQLiteDBM.GetMascotaAsync();
                await DisplayAlert("Registro", "El usuario se guardó de manera exitosa", "ok");
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
            if (string.IsNullOrEmpty(Idmascota.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(nombremascotatxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(Idccpropietariotxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(edadmascotatxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(razatxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(caractxt.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(pesotxt.Text))
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
            Idmascota.Text = "";
            nombremascotatxt.Text = "";
            Idccpropietariotxt.Text = "";
            edadmascotatxt.Text = "";
            razatxt.Text = "";
            caractxt.Text = "";
            pesotxt.Text = "";
        }
    }
}