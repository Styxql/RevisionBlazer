using Microsoft.EntityFrameworkCore;
using RevisionBlazer.Models.DataManager;
using RevisionBlazer.Models.DTO;
using RevisionBlazer.Models.EntityFramework;
using RevisionBlazer.Models.Repository;
using RevisionBlazer.Models.Repository.IDataRepositoryCourseDTO;
using RevisionBlazer.Models.Repository.IDataRepositoryEnrollmentDTO;
using RevisionBlazer.Models.Repository.IDataRepositoryStudentDTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IDataRepository<Course>, CourseManager>();
builder.Services.AddScoped<IDataRepository<Enrollment>, EnrollmentManager>();
builder.Services.AddScoped<IDataRepository<Student>, StudentManager>();

builder.Services.AddScoped<IDataRepositoryCourseDTO, CourseManager>();
builder.Services.AddScoped<IDataRepositoryEnrollmentDTO, EnrollmentManager>();
builder.Services.AddScoped<IDataRepositoryStudentDTO, StudentManager>();





builder.Services.AddDbContext<ClassDBContext>(options =>
             options.UseNpgsql(builder.Configuration.GetConnectionString("SeriesDbContextRemote")));
var app = builder.Build();
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
