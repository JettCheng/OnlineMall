using System.Collections.Generic;

namespace Infrastructure.Services.PropertyMapping
{
    public interface IPropertyMappingService
    {
        Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>();
    }
}