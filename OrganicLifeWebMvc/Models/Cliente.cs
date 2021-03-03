using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicLifeWebMvc.Models
{
    public class Cliente : EntidadeBase
    {
        public Pessoa Pessoa{ get; set; }
        // Dados de acesso
    }
}
