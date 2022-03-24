using System;
using System.Collections.Generic;
using System.Text;

namespace System.Application.Main.Dtos.Main.MaestroModule
{
    public class OutCustomerDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime fec_nacimiento { get; set; }
        public string estado { get; set; }
        public int Edad { get; set; }
    }
}
