using Faria_Fintech_API.DTOs.Response;
using Faria_Fintech_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Faria_Fintech_API.Controllers
{
    [Route("tipo-contum")]
    [ApiController]
    public class TipoContumController : ControllerBase
    {
        private readonly FariaFintechContext _context;

        public TipoContumController(FariaFintechContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CadastrarTipoConta(AlterarTipoContaRequest request)
        {
            var novoTipoconta = new TipoContum
            {
                DscTipoConta = request.DscTipoConta,
                DataCadastro = request.DataCadastro,
                IndAtivo = true
            };

            _context.Add(novoTipoconta);
            _context.SaveChanges();

            return Ok("Tipo de conta cadastrado com sucesso");
        }

        [HttpGet("{id}")]
        public IActionResult BuscarTipoConta(int id)
        {
            TipoContum tconta = _context.TipoConta.Find(id);

            if (tconta == null)
                return NotFound("Tipo de conta não encontrada");

            return Ok(new BuscarContaResponse
            {
                Id = tconta.IdTipoConta,
                DataCriacaoConta = tconta.DataCadastro,
                Descricao = tconta.DscTipoConta
            });
        }

        [HttpGet("buscar-todos-tipo-conta")]
        public IActionResult BuscarTodosTipoConta()
        {
            List<TiposContaResponse> tconta = _context.TipoConta
                .Select(x => new TiposContaResponse
                {
                    Id = x.IdTipoConta,
                    Descricao = x.DscTipoConta
                }).ToList();

            if (!tconta.Any())
                return NotFound("Nenhum tipo de conta foi encontrado.");

            return Ok(tconta);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarTipoConta(int id)
        {
            TipoContum tconta = _context.TipoConta.Find(id);

            if (tconta == null)
                return NotFound("Tipo de conta não encontrado.");

            _context.TipoConta.Remove(tconta);
            _context.SaveChanges();

            return Ok("Tipo de conta deletada com sucesso!");
        }

        [HttpPut("{id}")]
        public IActionResult AlterarTipoConta(AlterarTipoContaRequest request, int id)
        {
            TipoContum tconta = _context.TipoConta.Find(id);

            if (tconta == null)
            {
                return NotFound("Tipo de conta não encontrada");
            }

            tconta.DscTipoConta = request.DscTipoConta;
            tconta.DataCadastro = request.DataCadastro;
            tconta.IndAtivo = request.IndAtivo;

            _context.SaveChanges();

            return Ok("Tipo de conta alterada com sucesso");
        }

        [HttpDelete("deletar-tipos-conta")]
        public IActionResult DeletarTiposConta(List<int> listaTiposConta)
        {
            foreach (var tipoConta in listaTiposConta)
            {
                TipoContum tconta = _context.TipoConta.Find(tipoConta);

                _context.TipoConta.Remove(tconta);
            }

            _context.SaveChanges();

            return Ok("Tipos de contas deletados com sucesso!");
        }
    }
}
