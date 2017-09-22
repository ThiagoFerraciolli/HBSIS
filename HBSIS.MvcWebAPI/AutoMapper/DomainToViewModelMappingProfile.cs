using AutoMapper;
using HBSIS.Domain.Entities;
using HBSIS.MvcWebAPI.ViewModels;

namespace HBSIS.MvcWebAPI.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel, Cliente>();
        }
    }
}