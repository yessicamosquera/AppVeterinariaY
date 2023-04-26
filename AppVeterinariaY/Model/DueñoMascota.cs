using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVeterinariaY.Model
{
    public class DueñoMascota
    {
        public DueñoMascota()
        {
        }
        [PrimaryKey]
        public int IdcedulaDueño { get; set; }
        [MaxLength(50)]
        public string nombreDueño { get; set; }
    }
}
