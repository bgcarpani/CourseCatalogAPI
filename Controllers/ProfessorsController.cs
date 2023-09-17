using Microsoft.AspNetCore.Mvc;
using CourseCatalogAPI.Repositories;
using CourseCatalogAPI.Models.Professors;

namespace CourseCatalogAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly ProfessorRepository _repository;

        public ProfessorsController(ProfessorRepository professorRepository)
        {
            _repository = professorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessors()
        {
            var professors = await _repository.GetAllProfessors();
            return Ok(professors);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateProfessor(ProfessorCreateCommand professor)
        {
            try
            {
                var createdProfessor = await _repository.CreateProfessor(professor);
                return Ok("Professor created succesfully, Id: "+ createdProfessor);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

    }
}