using AutoMapper;

namespace EjemploUsoSessionYAjax.Core.PerfilesAutomapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Models.Employee, ViewModels.EmployeeViewModel>();
        }
    }
}