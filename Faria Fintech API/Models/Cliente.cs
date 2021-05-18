using System;
using System.Collections.Generic;

#nullable disable

namespace Faria_Fintech_API.Models
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool IndAtivo { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string SglEstado { get; set; }
    }
}
