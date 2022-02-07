﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Entities.Entities
{
    public class ResponsablesDemarcacion
    {
        public Guid Id { get; set; }

        public string JefeDemarcacion { get; set; }

        public string IngenerioCircumbalacion { get; set; }

        public string PeritoDemarcacion { get; set; }

        public string RepresentanteDemarcacion { get; set; }

        public string IngenieroJefeArea { get; set; }

        public string IngenieroJefe { get; set; }

        public string Pagador { get; set; }
    }
}
