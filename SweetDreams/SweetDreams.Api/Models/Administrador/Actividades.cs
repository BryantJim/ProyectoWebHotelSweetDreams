﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Api.Models.Administrador
{
    public class Actividades
    {
        [Key]
        public int ActividadId { get; set; }
        public string NombreActividad { get; set; }
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFinal { get; set; }
        public bool Accesibilidad { get; set; }
    }
}
