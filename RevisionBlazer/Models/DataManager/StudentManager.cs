using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RevisionBlazer.Models.DTO;
using RevisionBlazer.Models.EntityFramework;
using RevisionBlazer.Models.Repository;
using RevisionBlazer.Models.Repository.IDataRepositoryStudentDTO;

namespace RevisionBlazer.Models.DataManager
{
    public class StudentManager:IDataRepository<Student>,IDataRepositoryStudentDTO
    {
        readonly ClassDBContext ClassDBContext;

        public StudentManager()
        { }

        public StudentManager(ClassDBContext context)
        {
            ClassDBContext = context;
        }

        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllAsync()
        {
            var StudentsDTO = await ClassDBContext.Students
      .Select(Student => new StudentDTO
      {
          Id = Student.IdStudent,
          Name = Student.FullName,
          NbEnrollment = Student.Enrollments.Count()

      })
      .ToListAsync();

            return StudentsDTO;
        }

        public async Task<ActionResult<StudentDTO>> GetByIdAsync(int id)
        {
            var StudentsDTO = await ClassDBContext.Students
      .Select(Student => new StudentDTO
      {
          Id = Student.IdStudent,
          Name = Student.FullName,
          NbEnrollment = Student.Enrollments.Count()

      }).FirstOrDefaultAsync(p => p.Id == id);


            return StudentsDTO;

        }

        public async Task<ActionResult<StudentDTO>> GetByStringAsync(string str)
        {
            var StudentsDTO = await ClassDBContext.Students.Select(productToDTO => new StudentDTO()
            {
                Id = productToDTO.IdStudent,
                Name = productToDTO.FullName,
                NbEnrollment = productToDTO.Enrollments.Count()

            }).FirstOrDefaultAsync(p => p.Name == str);

            return StudentsDTO;
        }

        public async Task AddAsync(Student entity)
        {
            await ClassDBContext.Students.AddAsync(entity);
            await ClassDBContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student prodToUpdate, Student newProd)
        {
            ClassDBContext.Entry(prodToUpdate).State = EntityState.Modified;
            prodToUpdate.IdStudent = newProd.IdStudent;
            prodToUpdate.Email = newProd.Email;
            prodToUpdate.FullName = newProd.FullName;
            prodToUpdate.Status = newProd.Status;
            prodToUpdate.PhoneNumber = newProd.PhoneNumber;
            prodToUpdate.DateOfBirth = newProd.DateOfBirth;
            prodToUpdate.Address = newProd.Address;
            prodToUpdate.EnrollmentDate = newProd.EnrollmentDate;




            await ClassDBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Student entity)
        {
            ClassDBContext.Students.Remove(entity);
            await ClassDBContext.SaveChangesAsync();
        }


        public async Task<Student> MapDetailDtoToStudent(StudentDTO produitDetailDTO)
        {
          
            Student m = new Student()
            {
                IdStudent = produitDetailDTO.Id,
                FullName = produitDetailDTO.Name,




            };

            return m;
        }
    }
}
