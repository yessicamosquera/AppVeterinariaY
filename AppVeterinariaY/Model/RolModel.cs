using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVeterinariaY.Model
{
    public class RolModel
    {
        public RolModel()
        {

        }
        [PrimaryKey]
        public int Idrol { get; set; }
        [MaxLength(50)]
        public string rol { get; set; }
    }
}
