using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVeterinariaY.Model
{
    public class Especie
    {
        public Especie()
        {

        }
        [PrimaryKey]
        public int Idespecie { get; set; }
        [MaxLength(50)]
        public string especie { get; set; }
    }
}
