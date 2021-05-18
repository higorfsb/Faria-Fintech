using Faria_Fintech_API.DTOs.Response;
using Faria_Fintech_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Faria_Fintech_API.Controllers
{
    [Route("contum")]
    [ApiController]
    public class ContumController : ControllerBase
    {
        private readonly FariaFintechContext _context;

        public ContumController(FariaFintechContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CadastrarConta(AlterarContaRequest request)
        {
            var novaConta = new Contum
            {
                CodCliente = request.CodCliente,
                CodTipoConta = request.CodTipoConta,
                DataCadastro = DateTime.Now,
                IndAtivo = true,
                NumAgencia = request.NumAgencia,
                NumConta = request.NumConta,
                VlrSaldo = request.VlrSaldo
            };

            _context.Add(novaConta);
            _context.SaveChanges();

            return Ok("Conta cadastrada com sucesso");
        }

        [HttpGet("{id}")]
        public IActionResult BuscarConta(int id)
        {
            Contum conta = _context.Conta.Find(id);

            if (conta == null)
                return NotFound("Conta não encontrada");

            return Ok(conta);
        }

        [HttpGet("listar-todas-contas")]
        public IActionResult ListarTodasContas()
        {
            List<ContumResponse> conta = _context.Conta
                .Select(x => new ContumResponse
                {
                    Agencia = x.NumAgencia,
                    Conta = x.NumConta,
                    Id = x.IdConta,
                    Saldo = x.VlrSaldo
                }).ToList();

            if (!conta.Any())
                return NotFound("Nenhuma conta foi encontrada.");

            return Ok(conta);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarConta(int id)
        {
            Contum conta = _context.Conta.Find(id);

            if (conta == null)
                return NotFound("Conta não encontrada.");

            _context.Conta.Remove(conta);
            _context.SaveChanges();

            return Ok("Conta deletada com sucesso!");
        }

        [HttpPut("{id}")]
        public IActionResult AlterarConta(AlterarContaRequest request, int id)
        {
            Contum conta = _context.Conta.Find(id);

            if (conta == null)
            {
                return NotFound("Conta não encontrada");
            }

            conta.NumConta = request.NumConta;
            conta.NumAgencia = request.NumAgencia;
            conta.VlrSaldo = request.VlrSaldo;
            conta.DataCadastro = request.DataCadastro;
            conta.IndAtivo = request.IndAtivo;
            conta.CodCliente = request.CodCliente;
            conta.CodTipoConta = request.CodTipoConta;

            _context.SaveChanges();

            return Ok("Conta alterada com sucesso");
        }
    }
}
