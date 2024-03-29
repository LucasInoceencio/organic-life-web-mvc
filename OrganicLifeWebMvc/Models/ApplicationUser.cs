﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicLifeWebMvc.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
        public string TipoUsuario { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
