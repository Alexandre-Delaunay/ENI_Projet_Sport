﻿using BO.Models;
using BO.Services;
using ENI_Projet_Sport.Extensions;
using ENI_Projet_Sport.ViewModels;
using System;
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
                        vm.RaceType = poco.RaceType.Map<RaceTypeViewModel>();
                        vm.isSubscribe = false;
                    });
                config.CreateMap<Person, PersonViewModel>();
                config.CreateMap<RaceType, RaceTypeViewModel>();
                config.CreateMap<DisplayConfiguration, DisplayConfigurationViewModel>();
                config.CreateMap<POI, POIViewModel>();
                config.CreateMap<CategoryPOI, CategoryPOIViewModel>();

                // ViewModel TO Model
                config.CreateMap<RaceViewModel, Race>()
                    .AfterMap((vm, poco) =>
                    {
                        poco.POIs = vm.POIs.Select(p => p.Map<POI>()).ToList();
                        poco.Persons = vm.Persons.Select(p => p.Map<Person>()).ToList();
                        poco.RaceType = vm.RaceType.Map<RaceType>();
                    });
                config.CreateMap<PersonViewModel, Person>();
                config.CreateMap<RaceTypeViewModel, RaceType>();
                config.CreateMap<DisplayConfigurationViewModel, DisplayConfiguration>();
                config.CreateMap<POIViewModel, POI>();
                config.CreateMap<CategoryPOIViewModel, CategoryPOI>();

                // Model TO CreateEditViewModel
                config.CreateMap<Race, CreateEditRaceViewModel>()
                    .ForMember(vm => vm.POIs, o => o.Ignore())
                    .AfterMap((poco, vm) =>
                    {
                        vm.POIs = poco.POIs.Select(p => p.Map<POIViewModel>()).ToList();
                        vm.RaceTypeId = poco.RaceType.Id.ToString();

                        vm.InitLists();
                    });
                config.CreateMap<Person, CreateEditPersonViewModel>()
                    .ForMember(vm => vm.DisplayConfigurationId, o => o.Ignore())
                    .AfterMap((poco, vm) =>
                    {
                        vm.InitLists();
                    });

                // CreateEditViewModel TO Model
                config.CreateMap<CreateEditRaceViewModel, Race>()
                    .AfterMap((vm, poco) =>
                    {
                        var servicePOI = vm.ServiceLocator.GetService<IServicePOI>();
                        var serviceRaceType = vm.ServiceLocator.GetService<IServiceRaceType>();
                        poco.POIs = vm.POIs.Select(p => p.Map<POI>()).ToList();
                        poco.RaceType = serviceRaceType.GetById(int.Parse(vm.RaceTypeId));
                    });
                config.CreateMap<CreateEditPersonViewModel, Person>();
            });
        }
    }
}