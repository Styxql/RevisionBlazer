using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RevisionBlazer.Models.DTO;
using RevisionBlazer.Models.EntityFramework;
using RevisionBlazer.Models.Repository;
using RevisionBlazer.Models.Repository.IDataRepositoryEnrollmentDTO;

namespace RevisionBlazer.Models.DataManager
{
    public class EnrollmentManager:IDataRepository<Enrollment>, IDataRepositoryEnrollmentDTO
    {
        readonly ClassDBContext ClassDBContext;

        public EnrollmentManager()
        { }

        public EnrollmentManager(ClassDBContext context)
        {
            ClassDBContext = context;
        }

        public async Task<ActionResult<IEnumerable<EnrollmentDTO>>> GetAllAsync()
        {
            var EnrollmentsDTO = await ClassDBContext.Enrollments
      .Select(Enrollment => new EnrollmentDTO
      {
          Id = Enrollment.IdEnrollment,
          Status = Enrollment.Status,
          StudentName= Enrollment.IdStudentNavigation.FullName
              
      })
      .ToListAsync();

            return EnrollmentsDTO;
        }

        public async Task<ActionResult<EnrollmentDTO>> GetByIdAsync(int id)
        {
            var EnrollmentsDTO = await ClassDBContext.Enrollments
      .Select(Enrollment => new EnrollmentDTO
      {
          Id = Enrollment.IdEnrollment,
          Status = Enrollment.Status,
          StudentName = Enrollment.IdStudentNavigation.FullName

      }).FirstOrDefaultAsync(p => p.Id == id);


            return EnrollmentsDTO;

        }

        public async Task<ActionResult<EnrollmentDTO>> GetByStringAsync(string str)
        {
            var produitDTO = await ClassDBContext.Enrollments.Select(productToDTO => new EnrollmentDTO()
            {
                Id = productToDTO.IdEnrollment,
                Status = productToDTO.Status,
                StudentName = productToDTO.IdStudentNavigation.FullName

            }).FirstOrDefaultAsync(p => p.StudentName == str);

            return produitDTO;
        }

        public async Task AddAsync(Enrollment entity)
        {
            await ClassDBContext.Enrollments.AddAsync(entity);
            await ClassDBContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Enrollment prodToUpdate, Enrollment newProd)
        {
            ClassDBContext.Entry(prodToUpdate).State = EntityState.Modified;
            prodToUpdate.IdEnrollment = newProd.IdEnrollment;
            prodToUpdate.IdCourse = newProd.IdCourse;
            prodToUpdate.IdStudent = newProd.IdStudent;
            prodToUpdate.Status = newProd.Status;
            prodToUpdate.FinalGrade = newProd.FinalGrade;
            prodToUpdate.Progress = newProd.Progress;


            await ClassDBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Enrollment entity)
        {
            ClassDBContext.Enrollments.Remove(entity);
            await ClassDBContext.SaveChangesAsync();
        }


        public async Task<Enrollment> MapEnrollmentDTOToEnrollment(EnrollmentDTO produitDetailDTO)
        {
            var instructor = await ClassDBContext.Students.Select(c => new Student()
            {
                IdStudent = c.IdStudent,
                FullName = c.FullName
            }).FirstOrDefaultAsync(m => m.FullName == produitDetailDTO.StudentName);
            Enrollment m = new Enrollment()
            {
                IdStudent = instructor.IdStudent,
                IdEnrollment=produitDetailDTO.Id,
                Status= produitDetailDTO.Status
                


            };

            return m;
        }
    }
}
