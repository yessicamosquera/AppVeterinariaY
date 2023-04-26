using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVeterinariaY.Model
{
    public class FacturaModel
    {
        public FacturaModel() { }

        [PrimaryKey, AutoIncrement]
        public int? Idfactura { get; set; }
        public int? Idmascota { get; set; }
        public int? IdcedulaDueño { get; set; }
        public int? Idorden { get; set; }
        [MaxLength(50)]
        public string producto { get; set; }
        [MaxLength(50)]
        public int valor { get; set; }
        [MaxLength(50)]
        public int cantidad { get; set; }
        public DateTime? fecha { get; set; }

    }
}
