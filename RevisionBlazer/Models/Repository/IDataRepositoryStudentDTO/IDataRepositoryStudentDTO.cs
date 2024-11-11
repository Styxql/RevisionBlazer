using Microsoft.AspNetCore.Mvc;
using RevisionBlazer.Models.DTO;
using RevisionBlazer.Models.EntityFramework;

namespace RevisionBlazer.Models.Repository.IDataRepositoryStudentDTO
{
    public interface IDataRepositoryStudentDTO
    {
        Task<ActionResult<IEnumerable<StudentDTO>>> GetAllAsync();
        Task<ActionResult<StudentDTO>> GetByIdAsync(int id);
        Task<Student> MapDetailDtoToStudent(StudentDTO produitDetailDTO);
        Task<ActionResult<StudentDTO>> GetByStringAsync(string str);


    }
}
