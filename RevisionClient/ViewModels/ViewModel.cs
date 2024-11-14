using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RevisionClient.Models;
using RevisionClient.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
namespace RevisionClient.ViewModels
{
    internal sealed partial class ViewModel: ObservableObject
    {
        private readonly WSService _produitService;

        [ObservableProperty]
        private Student student;

        [ObservableProperty]
        private StudentDTO studentDTO;

        [ObservableProperty]
        private List<StudentDTO> studentsDTO;

        [ObservableProperty]
        private List<EnrollmentDTO> enrollments;

        [ObservableProperty]
        private bool enrollmentIsFound=false;


        public ViewModel(WSService produitService)
        {
            _produitService = produitService;
         
        }

        public async Task LoadInitialData()
        {
            studentsDTO = await _produitService.GetAllStudentAsync("Students");
            enrollments = await _produitService.GetAllProduitsAsync("Enrollments");
        }
    }
}
