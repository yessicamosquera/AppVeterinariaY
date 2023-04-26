using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVeterinariaY.Model
{
    public class UsuariosModel
    {
        [PrimaryKey, AutoIncrement]
        public int Idcedula { get; set; }
        [MaxLength(50)]
        public string nombre { get; set; }
        [MaxLength(50)]
        public string Usuario { get; set; }
        [MaxLength(50)]
        public string Contraseña { get; set; }

        public int Idrol { get; set; }

    }
}
