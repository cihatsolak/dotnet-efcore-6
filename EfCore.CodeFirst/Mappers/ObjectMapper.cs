using AutoMapper;
using EfCore.CodeFirst.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst.Mappers
{
    internal class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomMapping>();
            });

            return config.CreateMapper();
        });

        internal static IMapper Mapper => lazy.Value;
    }

    internal class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
