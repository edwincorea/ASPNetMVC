using AutoMapper;

namespace EjemploUsoSessionYAjax.Core
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Models.Employee, ViewModels.EmployeeViewModel>();
            CreateMap<Models.Item, ViewModels.ItemViewModel>();
        }
    }
}