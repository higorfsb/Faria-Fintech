using System;

namespace Faria_Fintech_API.DTOs.Response
{
    public class BuscarContaResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacaoConta { get; set; }
    }
}
