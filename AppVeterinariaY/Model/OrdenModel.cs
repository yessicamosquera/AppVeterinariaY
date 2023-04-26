using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVeterinariaY.Model
{
    public class OrdenModel
    {
        public OrdenModel() { }

        [PrimaryKey, AutoIncrement]
        public int Idorden { get; set; }
        public int? Idmascota { get; set; }
        public int? IdcedulaDueño { get; set; }
        public int? Idcedula { get; set; }
        [MaxLength(50)]
        public string medicamento { get; set; }
        [MaxLength(50)]
        public decimal dosis { get; set; }

    }
}
