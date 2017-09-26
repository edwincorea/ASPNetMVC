using AutoMapper;

namespace EjemploUsoSessionYAjax.Core.PerfilesAutomapper
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Models.Item, ViewModels.ItemViewModel>();
        }
    }
}