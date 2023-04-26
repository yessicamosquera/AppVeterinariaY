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
    public partial class EditPaciente : ContentPage
    {
        MascotaModel registro = new MascotaModel();
        public EditPaciente()
        {
            InitializeComponent();
        }
        private async void btnModificarPaciente_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Idmascota.Text))
            {
                MascotaModel Usuario = new MascotaModel()
                {
                    Idmascota = (int)Convert.ToInt64(Idmascota.Text),
                    nombreMascota = nombremascotatxt.Text,
                    IdcedulaDueño = (int)Convert.ToInt64(Idccpropietariotxt.Text),
                    edadMascota = (int)Convert.ToInt64(edadmascotatxt.Text),
                    Idespecie = EspeciePicker.SelectedIndex + 1,
                    raza = razatxt.Text,
                    caracteristicas = caractxt.Text,
                    peso = (decimal)Convert.ToDecimal(pesotxt.Text),

                };
                await App.SQLiteDBM.UpdateMascotaAsync(Usuario);
                await DisplayAlert("Registro", "El usuario se actualizó de manera exitosa", "ok");
                await Navigation.PushModalAsync(new VerPaciente());
                Limpiar();
                Idmascota.IsVisible = false;
                btnModificarPaciente.IsVisible = false;



            }
        }

        private async void btnEliminarPaciente_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Confirmar", "Estas seguro de eliminar el paciente", "Aceptar", "Cancelar");
            if (result)
            {
                registro = (MascotaModel)BindingContext;
                await App.SQLiteDBM.DeleteMascotaAsync(registro);
                await Navigation.PushModalAsync(new VerPaciente());
            }
            else

                return;

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

        private void bntsalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Veterinario());
        }
    }
}