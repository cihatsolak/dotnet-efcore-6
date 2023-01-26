namespace EfCore.CodeFirst.V2.Mappers
{
    public class ObjectMapper
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
            CreateMap<Shirt, ShirtDto>();
        }
    }
}
