using BO.Models;
using BO.Services;
using ENI_Projet_Sport.Extensions;
using ENI_Projet_Sport.ViewModels;
using System.Linq;

namespace ENI_Projet_Sport.App_Start
{
    public class MapperConfig
    {
        public static void InitMapper()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                // Model TO ViewModel
                config.CreateMap<Race, RaceViewModel>()
                    .AfterMap((poco, vm) =>
                    {
                        vm.POIs = poco.POIs.Select(p => p.Map<POIViewModel>()).ToList();
                        vm.Persons = poco.Persons.Select(p => p.Map<PersonViewModel>()).ToList();
                    });
                config.CreateMap<Person, PersonViewModel>()
                    .AfterMap((poco, vm) =>
                    {
                        vm.DisplayConfiguration = poco.DisplayConfiguration.Map<DisplayConfigurationViewModel>();
                    });
                config.CreateMap<RaceTypeViewModel, RaceTypeViewModel>();
                config.CreateMap<DisplayConfiguration, DisplayConfigurationViewModel>();
                config.CreateMap<POI, POIViewModel>();
                config.CreateMap<CategoryPOI, CategoryPOIViewModel>();

                // ViewModel TO Model
                config.CreateMap<RaceViewModel, Race>()
                    .AfterMap((vm, poco) =>
                    {
                        poco.POIs = vm.POIs.Select(p => p.Map<POI>()).ToList();
                        poco.Persons = vm.Persons.Select(p => p.Map<Person>()).ToList();
                    });
                config.CreateMap<PersonViewModel, Person>()
                    .AfterMap((vm, poco) =>
                    {
                        poco.DisplayConfiguration = vm.DisplayConfiguration.Map<DisplayConfiguration>();
                    });
                config.CreateMap<RaceTypeViewModel, RaceTypeViewModel>();
                config.CreateMap<DisplayConfigurationViewModel, DisplayConfiguration>();
                config.CreateMap<POIViewModel, POI>();
                config.CreateMap<CategoryPOIViewModel, CategoryPOI>();

                // Model TO CreateEditViewModel
                config.CreateMap<Race, CreateEditRaceViewModel>()
                    .ForMember(vm => vm.POIsIds, o => o.Ignore())
                    .ForMember(vm => vm.POIForSelectList, o => o.Ignore())
                    .AfterMap((poco, vm) =>
                    {
                        vm.POIsIds = poco.POIs.Select(p => p.Id).ToList();

                        vm.InitLists();
                    });
                config.CreateMap<POI, CreateEditPOIViewModel>()
                    .ForMember(vm => vm.CategoryPOIId, o => o.Ignore())
                    .AfterMap((poco, vm) =>
                    {
                        vm.CategoryPOIId = poco.CategoryPOI.Id;

                        vm.InitLists();
                    });
                config.CreateMap<Person, CreateEditPersonViewModel>()
                    .ForMember(vm => vm.DisplayConfigurationId, o => o.Ignore())
                    .AfterMap((poco, vm) =>
                    {
                        vm.DisplayConfigurationId = poco.DisplayConfiguration.Id;

                        vm.InitLists();
                    });

                // CreateEditViewModel TO Model
                config.CreateMap<CreateEditRaceViewModel, Race>()
                    .AfterMap((vm, poco) =>
                    {
                        var servicePOI = vm.ServiceLocator.GetService<IServicePOI>();
                        poco.POIs = servicePOI.GetAll().Where(p => vm.POIsIds.Contains(p.Id)).ToList();
                    });
                config.CreateMap<CreateEditPOIViewModel, POI>()
                    .AfterMap((vm, poco) =>
                    {
                        var serviceCategoryPOI = vm.ServiceLocator.GetService<IServiceCategoryPOI>();
                        poco.CategoryPOI = vm.CategoryPOIId.HasValue ? serviceCategoryPOI.GetById(vm.CategoryPOIId.Value) : null;
                    });
                config.CreateMap<CreateEditPersonViewModel, Person>()
                    .AfterMap((vm, poco) =>
                    {
                        var serviceDisplayConfiguration = vm.ServiceLocator.GetService<IServiceDisplayConfiguration>();
                        poco.DisplayConfiguration = vm.DisplayConfigurationId.HasValue ? serviceDisplayConfiguration.GetById(vm.DisplayConfigurationId.Value) : null;
                    });
            });
        }
    }
}