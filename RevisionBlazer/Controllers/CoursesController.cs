using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RevisionBlazer.Models.DTO;
using RevisionBlazer.Models.EntityFramework;
using RevisionBlazer.Models.Repository;
using RevisionBlazer.Models.Repository.IDataRepositoryCourseDTO;

namespace RevisionBlazer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {

        private readonly IDataRepository<Course> dataRepositoryProduit;
        private readonly IDataRepositoryCourseDTO dataRepositoryProduitDetailDTO;



        public CoursesController(IDataRepository<Course> dataRepo, IDataRepositoryCourseDTO dataRepoDetailDTO)
        {
            dataRepositoryProduit = dataRepo;
            dataRepositoryProduitDetailDTO = dataRepoDetailDTO;
        }
        // GET: api/Produits
        // GET: api/Course
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetProduits()
        {
            return await dataRepositoryProduitDetailDTO.GetAllAsync();
        }

        // GET: api/Course/ById/5
        [HttpGet]
        [Route("ById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CourseDTO>> GetProduitById(int id)
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

        // GET: api/Course/ByNom/example
        [HttpGet]
        [Route("ByNom/{str}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CourseDTO>> GetProduitByString(string str)
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

        // PUT: api/Course/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutProduit(int id, Course produit)
        {
            if (id != produit.IdCourse)
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

                var mappedProdToUpdate = await dataRepositoryProduitDetailDTO.MapDetailDtoToCourse(prodToUpdate.Value);
                await dataRepositoryProduit.UpdateAsync(mappedProdToUpdate, produit);
                return NoContent();
            }
        }

        // POST: api/Course
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Course>> PostProduit(Course p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepositoryProduit.AddAsync(p);

            return CreatedAtAction("GetProduitById", new { id = p.IdCourse }, p);
        }

        // DELETE: api/Course/5
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

            var p = await dataRepositoryProduitDetailDTO.MapDetailDtoToCourse(produit.Value);

            await dataRepositoryProduit.DeleteAsync(p);
            return NoContent();
        }
    }
}
