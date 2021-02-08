using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_ap1_2018_0553.Entidades
{
    class Ciudad
    {
        [Key]
        public int CiudadID { get; set; }

        public string Nombre_Ciudad { get; set; }
    }
}
