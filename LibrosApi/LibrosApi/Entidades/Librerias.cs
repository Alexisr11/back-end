﻿using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrosApi.Entidades
{
    public class Librerias
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:75)]
        public string Nombre { get; set; }
        public Point Ubicacion { get; set; }
        public List<LibrosLibrerias> LibrosLibrerias { get; set; }
    }
}
