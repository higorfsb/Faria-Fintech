namespace Faria_Fintech_API.DTOs.Response
{
    public class ClientesResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }
    }
}
