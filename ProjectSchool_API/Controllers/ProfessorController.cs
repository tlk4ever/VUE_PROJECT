using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        private readonly IRepository _repo;
        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            try
            {
                var result = await _repo.GetAllProfessoresAsync(true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados");
            }
        }

        [HttpGet("{ProfessorId}")]
        public async Task<IActionResult> getByProfessorId(int ProfessorId)
        {
            try
            {
                var result = await _repo.GetProfessoresAsyncById(ProfessorId,true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Professor model)
        {
            try
            {
                _repo.Add(model);
                
                if(await _repo.SaveChangesAsync()){
                    return Created($"/api/aluno/{model.Id}", model);
                }
                
                return BadRequest();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados");
            }
        }

        private IActionResult Created(string v)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{ProfessorId}")]
        public async Task<IActionResult> put(int ProfessorId, Professor model)
        {
            try
            {
                var professor = await _repo.GetProfessoresAsyncById(ProfessorId,false);
                if(professor == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync()){
                    return Created($"/api/aluno/{model.Id}", model);
                }

                return BadRequest();
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados");
            }
        }

        [HttpDelete("{ProfessorId}")]
        public async Task<IActionResult> delete(int ProfessorId)
        {
            try
            {
                var professor = await _repo.GetProfessoresAsyncById(ProfessorId,false);
                if(professor == null) return NotFound();

                _repo.Delete(professor);

                if(await _repo.SaveChangesAsync()){
                    return Ok();
                }

                return BadRequest();
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados");
            }
        }
    }
}