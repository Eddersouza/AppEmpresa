using AppEmpresa.Domain.Entities;
using AppEmpresa.UI.React.ViewModels.Companies;
using AutoMapper;

namespace AppEmpresa.UI.React.AutomapperConfig
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CompanyView, Company>();
            CreateMap<CompaniesView, CompanyList>();

        }
    }
}