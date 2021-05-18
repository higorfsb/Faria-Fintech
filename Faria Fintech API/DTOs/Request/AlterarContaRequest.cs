using System;


namespace Faria_Fintech_API
{
    public class AlterarContaRequest
    {
        public int NumConta { get; set; }
        public int NumAgencia { get; set; }
        public decimal VlrSaldo { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool IndAtivo { get; set; }
        public int CodCliente { get; set; }
        public int CodTipoConta { get; set; }
    }
}
