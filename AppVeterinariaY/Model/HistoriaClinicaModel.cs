using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVeterinariaY.Model
{
    public class HistoriaClinicaModel
    {
        public HistoriaClinicaModel() { }

        [PrimaryKey, AutoIncrement]
        public int Idhistoria { get; set; }
        public int Idmascota { get; set; }
        public DateTime? fechaIngreso { get; set; }
        [MaxLength(50)]
        public string medico { get; set; }
        [MaxLength(50)]
        public string motivoConsulta { get; set; }
        [MaxLength(100)]
        public string sintomatologia { get; set; }
        [MaxLength(100)]
        public string diagnostico { get; set; }
        [MaxLength(100)]
        public int procedimiento { get; set; }
        [MaxLength(100)]
        public string medicamento { get; set; }
        public decimal? dosis { get; set; }
        public int Idorden { get; set; }
        [MaxLength(50)]
        public string historialVacunacion { get; set; }
        [MaxLength(100)]
        public string alergias { get; set; }
        [MaxLength(100)]
        public string detalles { get; set; }
        [MaxLength(100)]
        public string anulacionOrden { get; set; }

    }
}
