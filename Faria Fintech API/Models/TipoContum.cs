using System;
using System.Collections.Generic;

#nullable disable

namespace Faria_Fintech_API.Models
{
    public partial class TipoContum
    {
        public TipoContum()
        {
            Conta = new HashSet<Contum>();
        }

        public int IdTipoConta { get; set; }
        public string DscTipoConta { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool IndAtivo { get; set; }

        public virtual ICollection<Contum> Conta { get; set; }
    }
}
