using System;
using System.Collections.Generic;

#nullable disable

namespace Faria_Fintech_API.Models
{
    public partial class Contum
    {
        public int IdConta { get; set; }
        public int NumConta { get; set; }
        public int NumAgencia { get; set; }
        public decimal VlrSaldo { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool IndAtivo { get; set; }
        public int CodCliente { get; set; }
        public int CodTipoConta { get; set; }

        public virtual TipoContum CodTipoContaNavigation { get; set; }
    }
}
