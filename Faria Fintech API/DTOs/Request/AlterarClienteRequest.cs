using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faria_Fintech_API
{
    public class AlterarClienteRequest
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool IndAtivo { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string SglEstado { get; set; }
    }
}

