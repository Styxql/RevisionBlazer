using Microsoft.AspNetCore.Mvc;
using RevisionBlazer.Models.DTO;
using RevisionBlazer.Models.EntityFramework;

namespace RevisionBlazer.Models.Repository.IDataRepositoryEnrollmentDTO
{
    public interface IDataRepositoryEnrollmentDTO
    {
        Task<ActionResult<IEnumerable<EnrollmentDTO>>> GetAllAsync();
        Task<ActionResult<EnrollmentDTO>> GetByIdAsync(int id);
        Task<Enrollment> MapEnrollmentDTOToEnrollment(EnrollmentDTO produitDetailDTO);
        Task<ActionResult<EnrollmentDTO>> GetByStringAsync(string str);


    }
}
