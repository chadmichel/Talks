using AutoMapper;
using CatAcc = DPLRef.eCommerce.Accessors.Catalog;
using WSCatContract = DPLRef.eCommerce.Contracts.WebStore.Catalog;
using AdminCatContract = DPLRef.eCommerce.Contracts.Admin.Catalog;

namespace DPLRef.eCommerce.Managers
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
                        CreateMap<WSCatContract.WebStoreCatalog, CatAcc.WebStoreCatalog>(cfg);
                        CreateMap<WSCatContract.ProductSummary, CatAcc.Product>(cfg);
                        CreateMap<WSCatContract.ProductDetail, CatAcc.Product>(cfg);
                        CreateMap<AdminCatContract.WebStoreCatalog, CatAcc.WebStoreCatalog>(cfg);
                    });
                    _mapper = config.CreateMapper();
                }
                return _mapper;
            }
        }

        static void CreateMap<X, Y>(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<X, Y>();
            cfg.CreateMap<Y, X>();
        }

        public static void Map(object source, object dest)
        {
            Mapper.Map(source, dest, source.GetType(), dest.GetType());
        }
    }
}
