using Microsoft.AspNetCore.Mvc;
using RevisionBlazer.Models.DTO;
using RevisionBlazer.Models.EntityFramework;

namespace RevisionBlazer.Models.Repository.IDataRepositoryCourseDTO
{
    public interface IDataRepositoryCourseDTO
    {
        Task<ActionResult<IEnumerable<CourseDTO>>> GetAllAsync();
        Task<ActionResult<CourseDTO>> GetByIdAsync(int id);
        Task<ActionResult<CourseDTO>> GetByStringAsync(string str);
        Task<Course> MapDetailDtoToCourse(CourseDTO produitDetailDTO);


    }
}
