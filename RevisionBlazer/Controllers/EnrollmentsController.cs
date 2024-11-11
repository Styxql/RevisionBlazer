using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RevisionBlazer.Models.DTO;
using RevisionBlazer.Models.EntityFramework;
using RevisionBlazer.Models.Repository.IDataRepositoryEnrollmentDTO;
using RevisionBlazer.Models.Repository;

namespace RevisionBlazer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IDataRepository<Enrollment> dataRepositoryProduit;
        private readonly IDataRepositoryEnrollmentDTO dataRepositoryProduitDetailDTO;



        public EnrollmentsController(IDataRepository<Enrollment> dataRepo, IDataRepositoryEnrollmentDTO dataRepoDetailDTO)
        {
            dataRepositoryProduit = dataRepo;
            dataRepositoryProduitDetailDTO = dataRepoDetailDTO;
        }
        // GET: api/Produits
        // GET: api/Enrollment
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<EnrollmentDTO>>> GetProduits()
        {
            return await dataRepositoryProduitDetailDTO.GetAllAsync();
        }

        // GET: api/Enrollment/ById/5
        [HttpGet]
        [Route("ById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EnrollmentDTO>> GetProduitById(int id)
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

        // GET: api/Enrollment/ByNom/example
        [HttpGet]
        [Route("ByNom/{str}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EnrollmentDTO>> GetProduitByString(string str)
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

        // PUT: api/Enrollment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutProduit(int id, Enrollment produit)
        {
            if (id != produit.IdEnrollment)
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

                var mappedProdToUpdate = await dataRepositoryProduitDetailDTO.MapEnrollmentDTOToEnrollment(prodToUpdate.Value);
                await dataRepositoryProduit.UpdateAsync(mappedProdToUpdate, produit);
                return NoContent();
            }
        }

        // POST: api/Enrollment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Enrollment>> PostProduit(Enrollment p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepositoryProduit.AddAsync(p);

            return CreatedAtAction("GetProduitById", new { id = p.IdEnrollment }, p);
        }

        // DELETE: api/Enrollment/5
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

            var p = await dataRepositoryProduitDetailDTO.MapEnrollmentDTOToEnrollment(produit.Value);

            await dataRepositoryProduit.DeleteAsync(p);
            return NoContent();
        }
    }
}
