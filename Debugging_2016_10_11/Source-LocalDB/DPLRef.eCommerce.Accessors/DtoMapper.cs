using AutoMapper;

namespace DPLRef.eCommerce.Accessors
{
    static class DTOMapper
    {
        static IMapper _mapper = null;

        static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    var config = new AutoMapper.MapperConfiguration(cfg => {
                        CreateMap<Models.Catalog, Catalog.WebStoreCatalog>(cfg);
                        CreateMap<Models.Product, Catalog.Product>(cfg);
                        CreateMap<Models.Seller, Remittance.Seller>(cfg);
                    });
                    _mapper = config.CreateMapper();
                }
                return _mapper;
            }
        }

        static void CreateMap<X,Y>(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<X,Y>();
            cfg.CreateMap<Y,X>();
        }

        public static void Map(object source, object dest)
        {
            Mapper.Map(source, dest, source.GetType(), dest.GetType());
        }
    }
}
