using AppVeterinariaY.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVeterinariaY
{
    public partial class App : Application
    {
        public static MasterDetailPage Modificador { get; set; }
        static UsuariosControlador db;
        static HistoriaControlador dbH;
        static MascotaControlador dbM;
        static OrdenControlador dbO;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
        public static UsuariosControlador SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new UsuariosControlador(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usuario.db3"));
                }
                return db;
            }
        }
        public static HistoriaControlador SQLiteDBH
        {
            get
            {
                if (dbH == null)
                {
                    dbH = new HistoriaControlador(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Historia.db3"));
                }
                return dbH;
            }
        }
        public static MascotaControlador SQLiteDBM
        {
            get
            {
                if (dbM == null)
                {
                    dbM = new MascotaControlador(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Mascota.db3"));
                }
                return dbM;
            }
        }
        public static OrdenControlador SQLiteDBO
        {
            get
            {
                if (dbO == null)
                {
                    dbO = new OrdenControlador(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Orden.db3"));
                }
                return dbO;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
