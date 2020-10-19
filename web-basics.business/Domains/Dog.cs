﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace web_basics.business.Domains
{
    public class Dog
    {
        data.Repositories.Dog repository;
        IMapper mapper;

        public Dog(IConfiguration configuration)
        {
            this.repository = new data.Repositories.Dog(configuration);
            this.mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<data.Entities.Dog, ViewModels.Dog>();
            }).CreateMapper();
        }

        public IEnumerable<ViewModels.Dog> Get()
        {
            var dogs = repository.Get();
            return dogs.Select(dog => mapper.Map<data.Entities.Dog, ViewModels.Dog>(dog));
        }

        public void Add(data.Entities.Dog dog)
        {
            this.repository.Add(dog);
        }
    }
}
