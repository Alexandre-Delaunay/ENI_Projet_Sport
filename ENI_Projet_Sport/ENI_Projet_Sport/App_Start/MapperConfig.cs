using BO.Models;
using ENI_Projet_Sport.ViewModels;

namespace ENI_Projet_Sport.App_Start
{
    public class MapperConfig
    {
        public static void InitMapper()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                // Model TO ViewModel
                config.CreateMap<Race, RaceViewModel>();
                config.CreateMap<Personne, PersonneViewModel>();
                config.CreateMap<RaceType, RaceTypeViewModel>();
                config.CreateMap<DisplayConfiguration, DisplayConfigurationViewModel>();
                config.CreateMap<POI, POIViewModel>();
                config.CreateMap<CategoryPOI, CategoryPOIViewModel>();
                
                // ViewModel TO Model
                config.CreateMap<RaceViewModel, Race>();
                config.CreateMap<PersonneViewModel, Personne>();
                config.CreateMap<RaceTypeViewModel, RaceType>();
                config.CreateMap<DisplayConfigurationViewModel, DisplayConfiguration>();
                config.CreateMap<POIViewModel, POI>();
                config.CreateMap<CategoryPOIViewModel, CategoryPOI>();

                // Model TO CreateEditViewModel
                config.CreateMap<Race, CreateEditRaceViewModel>();
                config.CreateMap<POI, CreateEditPOIViewModel>();
                config.CreateMap<Personne, CreateEditPersonneViewModel>();

                // CreateEditViewModel TO Model
                config.CreateMap<CreateEditRaceViewModel, Race>();
                config.CreateMap<CreateEditPOIViewModel, POI>();
                config.CreateMap<CreateEditPersonneViewModel, Personne>();
            });
        }
    }
}