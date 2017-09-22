using AutoMapper;
using HBSIS.Domain.Entities;
using HBSIS.MvcWebAPI.ViewModels;

namespace HBSIS.MvcWebAPI.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel>();
        }
    }
}