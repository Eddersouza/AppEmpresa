using AppEmpresa.Domain.Entities;
using AppEmpresa.UI.React.ViewModels.Companies;
using AutoMapper;

namespace AppEmpresa.UI.React.AutomapperConfig
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Company, CompanyView>();
        }
    }
}