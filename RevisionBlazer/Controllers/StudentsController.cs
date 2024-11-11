using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RevisionBlazer.Models.DTO;
using RevisionBlazer.Models.EntityFramework;
using RevisionBlazer.Models.Repository.IDataRepositoryStudentDTO;
using RevisionBlazer.Models.Repository;

namespace RevisionBlazer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly IDataRepository<Student> dataRepositoryProduit;
        private readonly IDataRepositoryStudentDTO dataRepositoryProduitDetailDTO;



        public StudentsController(IDataRepository<Student> dataRepo, IDataRepositoryStudentDTO dataRepoDetailDTO)
        {
            dataRepositoryProduit = dataRepo;
            dataRepositoryProduitDetailDTO = dataRepoDetailDTO;
        }
        // GET: api/Produits
        // GET: api/Student
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetProduits()
        {
            return await dataRepositoryProduitDetailDTO.GetAllAsync();
        }

        // GET: api/Student/ById/5
        [HttpGet]
        [Route("ById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StudentDTO>> GetProduitById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var produit = await dataRepositoryProduitDetailDTO.GetByIdAsync(id);

            if (produit.Value == null)
            {
                return NotFound();
            }

            return produit;
        }

        // GET: api/Student/ByNom/example
        [HttpGet]
        [Route("ByNom/{str}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StudentDTO>> GetProduitByString(string str)
        {
            if (str == "" || str == null)
            {
                return BadRequest();
            }

            var produit = await dataRepositoryProduitDetailDTO.GetByStringAsync(str);

            if (produit.Value == null)
            {
                return NotFound();
            }

            return produit;
        }

        // PUT: api/Student/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutProduit(int id, Student produit)
        {
            if (id != produit.IdStudent)
            {
                return BadRequest();
            }

            var prodToUpdate = await dataRepositoryProduitDetailDTO.GetByIdAsync(id);

            if (prodToUpdate.Value == null)
            {
                return NotFound();
            }
            else
            {

                var mappedProdToUpdate = await dataRepositoryProduitDetailDTO.MapDetailDtoToStudent(prodToUpdate.Value);
                await dataRepositoryProduit.UpdateAsync(mappedProdToUpdate, produit);
                return NoContent();
            }
        }

        // POST: api/Student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Student>> PostProduit(Student p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepositoryProduit.AddAsync(p);

            return CreatedAtAction("GetProduitById", new { id = p.IdStudent }, p);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduit(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var produit = await dataRepositoryProduitDetailDTO.GetByIdAsync(id);

            if (produit.Value == null)
            {
                return NotFound();
            }

            var p = await dataRepositoryProduitDetailDTO.MapDetailDtoToStudent(produit.Value);

            await dataRepositoryProduit.DeleteAsync(p);
            return NoContent();
        }
    }
}
