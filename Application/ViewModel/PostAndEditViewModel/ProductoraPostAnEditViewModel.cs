﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.PostAndEditViewModel
{
    public class ProductoraPostAnEditViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="El Campo Nombre Productora es Requerido")]
        public string NombreProductora { get; set; }
    }
}
