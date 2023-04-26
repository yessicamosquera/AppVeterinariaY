using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVeterinariaY.Model
{
    public class MascotaModel
    {
        public MascotaModel() { }

        [PrimaryKey, AutoIncrement]
        public int Idmascota { get; set; }
        [MaxLength(50)]
        public string nombreMascota { get; set; }
        public int IdcedulaDueño { get; set; }
        [MaxLength(100)]
        public int edadMascota { get; set; }
        public int Idespecie { get; set; }
        [MaxLength(50)]
        public string raza { get; set; }
        [MaxLength(50)]
        public string caracteristicas { get; set; }
        public decimal peso { get; set; }
    }
}
