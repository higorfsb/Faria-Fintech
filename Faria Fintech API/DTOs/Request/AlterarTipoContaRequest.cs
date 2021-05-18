using System;

namespace Faria_Fintech_API
{
    public class AlterarTipoContaRequest
    {
        public string DscTipoConta { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool IndAtivo { get; set; }
    }
}
