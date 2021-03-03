using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicLifeWebMvc.Models
{
    public enum CategoriaProduto
    {
        Verdura = 1,
        Legume = 2,
        Fruta = 3
    }

    public class Produto : EntidadeSoftDelete
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public CategoriaProduto Categoria { get; set; }
        public bool Organico { get; set; }
    }
}
