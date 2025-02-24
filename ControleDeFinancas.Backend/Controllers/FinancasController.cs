using System.Drawing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeFinancas.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancasController(FinancasDbContext context) : ControllerBase
    {
        private readonly FinancasDbContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetALL()
        {
            var financas = await _context.Financas.ToListAsync();
            if (financas.Any())
            {
                return Ok(new Response<IEnumerable<Financas>>
                {
                    IsSuccess = true,
                    Result = financas,
                    Message = "lista de finanças"
                });
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarAtualizar model)
        {

            if (!ModelState.IsValid) {
                return BadRequest(new Response<CriarAtualizar>
                {
                    IsSuccess = false,
                    Result = model,
                    Message = "Os campos não estão corretos"
                });
            }

            var novaFinanca = new Financas
            {
                Descricao = model.Descricao,

                Valor = model.Valor,

                Tipo = model.Tipo,

                Data = model.Data,
            };
            await _context.Financas.AddAsync(novaFinanca);
            await _context.SaveChangesAsync();

            return Ok(new Response<Financas>
            {
                IsSuccess = true,
                Result = novaFinanca,
                Message = "Finança adicionada",
            });
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) {
            if (id == Guid.Empty)
            {
                return BadRequest(new Response<Financas>
                {
                    IsSuccess = false,
                    Result = null,
                    Message = "O id é necessário"
                });
            }

            var financa = await GetFinanca(id);
            if (financa != null)
            {
                return Ok(new Response<Financas>
                {
                    IsSuccess = true,
                    Result = financa,
                    Message = "Finança encontrada"
                });
            }
            return NotFound(new Response<Financas> { 
            IsSuccess = false,
            Result = null,
            Message = "Não existe finança com esse id"
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTodas()
        {
            var todasFinancas = _context.Financas.ToList(); // Busca todas as finanças
            if (todasFinancas.Any())
            {
                _context.Financas.RemoveRange(todasFinancas); // Remove todas
                await _context.SaveChangesAsync();

                return Ok(new Response<string>
                {
                    IsSuccess = true,
                    Result = "Todas as finanças foram removidas.",
                    Message = "Todas as finanças foram deletadas com sucesso."
                });
            }

            return NotFound(new Response<string>
            {
                IsSuccess = false,
                Result = null,
                Message = "Não há finanças para remover."
            });
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new Response<Financas>
                {
                    IsSuccess = false,
                    Result = null,
                    Message = "O id é necessário"
                });
            }

            var financa = await GetFinanca(id);
            if (financa != null)
            {
                 _context.Financas.Remove(financa);
                await _context.SaveChangesAsync();

                return Ok(new Response<Financas> {
                IsSuccess = true,
                Result = financa,
                Message = "Finança removida."
                });
            }
            return NotFound(new Response<Financas> { 
            IsSuccess = false,
            Result = financa,
            Message = "Finança não encontrada"
            });
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(Guid id, [FromBody] CriarAtualizar model)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new Response<CriarAtualizar>
                {
                    IsSuccess = false,
                    Result = model,
                    Message = "O id é necessário"
                });
            }
            if (ModelState.IsValid) {
                var financa = await GetFinanca(id);
                if(financa != null)
                {
                    financa.Descricao = model.Descricao;

                    financa.Valor = model.Valor;

                    financa.Tipo = model.Tipo;

                    financa.Data = model.Data;
                    
                    
                    _context.Financas.Update(financa);
                    await _context.SaveChangesAsync();
                };
                return Ok(new Response<CriarAtualizar>
                {
                    IsSuccess = true,
                    Result = model,
                    Message = "Finança atualizada"
                });
            }
            return BadRequest(new Response<CriarAtualizar>
            {
                IsSuccess = false,
                Result = model,
                Message = "não foi possível atualizar a finança"
            });
        }
        private async Task<Financas> GetFinanca(Guid id) 
        {
            var financa = await _context.Financas.FirstOrDefaultAsync(f => f.Id == id);
            return financa;
        }
    }
}