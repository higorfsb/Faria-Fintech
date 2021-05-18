using Faria_Fintech_API.DTOs.Response;
using Faria_Fintech_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Faria_Fintech_API.Controllers
{
    [Route("clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly FariaFintechContext _context;

        public ClienteController(FariaFintechContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CadastrarCliente(AlterarClienteRequest request)
        {
            var novoCliente = new Cliente
            {
                Cidade = request.Cidade,
                Cpf = request.Cpf,
                DataCadastro = DateTime.Now,
                Endereco = request.Endereco,
                IndAtivo = true,
                Nome = request.Nome,
                SglEstado = request.SglEstado
            };

            _context.Add(novoCliente);
            _context.SaveChanges();

            return Ok("cliente cadastrado com sucesso");
        }

        [HttpGet("{id}")]
        public IActionResult BuscarCliente(int id)
        {
            Cliente cliente = _context.Clientes.Find(id);

            if (cliente == null)
                return NotFound("cliente não encontrado");

            return Ok(cliente);
        }

        [HttpGet("listar-todos-clientes")]
        public IActionResult ListarTodosClientes()
        {
            List<ClientesResponse> cliente = _context.Clientes
                .Select(x => new ClientesResponse
                {
                    Id = x.IdCliente,
                    Nome = x.Nome,
                    CPF = x.Cpf,
                    Cidade = x.Cidade,
                    Ativo = x.IndAtivo
                }).ToList();

            if (!cliente.Any())
                return NotFound("Nenhum cliente foi encontrado.");

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCliente(int id)
        {
            Cliente cliente = _context.Clientes.Find(id);

            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return Ok("Cliente deletado com sucesso!");
        }

        [HttpPut("{id}")]
        public IActionResult AlterarCliente(AlterarClienteRequest request, int id)
        {
            Cliente cliente = _context.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            cliente.Nome = request.Nome;
            cliente.Cpf = request.Cpf != null ? "Cidadão" : "Estrangeiro";
            cliente.DataCadastro = request.DataCadastro;
            cliente.IndAtivo = request.IndAtivo;
            cliente.Endereco = request.Endereco;
            cliente.Cidade = request.Cidade;
            cliente.SglEstado = request.SglEstado;

            _context.SaveChanges();

            return Ok("Cliente alterado com sucesso");
        }
    }
}
