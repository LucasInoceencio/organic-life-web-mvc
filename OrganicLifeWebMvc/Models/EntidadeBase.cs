using System;

namespace OrganicLifeWebMvc.Models
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public string ResponsavelCadastro { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }
        public string ResponsavelAlteracao { get; set; }
    }

    public abstract class EntidadeSoftDelete : EntidadeBase
    {
        public bool Deletado { get; set; }
        public DateTime? DataHoraExclusao { get; set; }
        public string ResponsavelExclusao { get; set; }
    }
}
