using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RevisionBlazer.Models.DTO;
using RevisionBlazer.Models.EntityFramework;
using RevisionBlazer.Models.Repository;
using RevisionBlazer.Models.Repository.IDataRepositoryCourseDTO;

namespace RevisionBlazer.Models.DataManager
{
    public class CourseManager : IDataRepository<Course>, IDataRepositoryCourseDTO
    {
        readonly ClassDBContext ClassDBContext;

        public CourseManager()
        { }

        public CourseManager(ClassDBContext context)
        {
            ClassDBContext = context;
        }

        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAllAsync()
        {
            var coursesDTO = await ClassDBContext.Courses
      .Select(course => new CourseDTO
      {
          Id = course.IdCourse,
          Title = course.Title,
          Instructor = course.CourseInstructor
              .Select(ci => ci.IdInstructorNavigation.FullName)
              .FirstOrDefault() ?? "No Instructor"
      })
      .ToListAsync();

            return coursesDTO;
        }

        public async Task<ActionResult<CourseDTO>> GetByIdAsync(int id)
        {
            var coursesDTO = await ClassDBContext.Courses
      .Select(course => new CourseDTO
      {
          Id = course.IdCourse,
          Title = course.Title,
          Instructor = course.CourseInstructor
              .Select(ci => ci.IdInstructorNavigation.FullName)
              .FirstOrDefault() ?? "No Instructor"
      }).FirstOrDefaultAsync(p=>p.Id == id); 
      

            return coursesDTO;

        }

        public async Task<ActionResult<CourseDTO>> GetByStringAsync(string str)
        {
            var produitDTO = await ClassDBContext.Courses.Select(productToDTO => new CourseDTO()
            {

                Id = productToDTO.IdCourse,
                Title = productToDTO.Title,
                Instructor = productToDTO.CourseInstructor
              .Select(ci => ci.IdInstructorNavigation.FullName)
              .FirstOrDefault() ?? "No Instructor"
            }).FirstOrDefaultAsync(p => p.Title == str);

            return produitDTO;
        }

        public async Task AddAsync(Course entity)
        {
            await ClassDBContext.Courses.AddAsync(entity);
            await ClassDBContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Course prodToUpdate, Course newProd)
        {
            ClassDBContext.Entry(prodToUpdate).State = EntityState.Modified;
            prodToUpdate.IdCourse = newProd.IdCourse;
            prodToUpdate.Title = newProd.Title;
            prodToUpdate.Duration=newProd.Duration;
            prodToUpdate.EndDate=newProd.EndDate;
            prodToUpdate.StartDate=newProd.StartDate;   
            prodToUpdate.Description=newProd.Description;

            await ClassDBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Course entity)
        {
            ClassDBContext.Courses.Remove(entity);
            await ClassDBContext.SaveChangesAsync();
        }


        public async Task<Course> MapDetailDtoToCourse(CourseDTO produitDetailDTO)
        {
            var instructor= await ClassDBContext.Instructors.Select(c=>new Instructor()
            {
                IdInstructor=c.IdInstructor,
                FullName=c.FullName
            }).FirstOrDefaultAsync(m=>m.FullName==produitDetailDTO.Instructor);
            Course m = new Course()
            {
                IdCourse = produitDetailDTO.Id,
                Title = produitDetailDTO.Title,
                
               
            };

            return m;
        }
    
}
}
