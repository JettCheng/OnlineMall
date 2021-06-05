using System;
using System.Collections.Generic;
using System.Linq;
using Core.Dtos;
using Core.Entities;

namespace Infrastructure.Services.PropertyMapping
{
    // 關於 Product 的屬性對照清單會寫於此
    public class PropertyMappingService : IPropertyMappingService
    {
        // Product Property
        private Dictionary<string, PropertyMappingValue> _productPropertyMapping 
            = new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase
        )
        {
            { "Id" , new PropertyMappingValue( new List<string>() { "Id" } ) },
            { "Title", new PropertyMappingValue( new List<string>() { "Title" } ) },
            { "OriginalPrice", new PropertyMappingValue( new List<string>() { "OriginalPrice" } ) }
        };

        // 
        private IList<IPropertyMapping> _propertyMappings = new List<IPropertyMapping>();

        // 建構子：初始化將Mapping完屬性的結果儲存至_propertyMappings
        public PropertyMappingService()
        {
            _propertyMappings.Add(
                new PropertyMapping<ProductDto, Product>(_productPropertyMapping)
            );
        }

        // 取出屬性對照的結果
        public Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            // 傳入型別
            var matchingMapping = _propertyMappings.OfType<PropertyMapping<TSource, TDestination>>();

            if(matchingMapping.Count() == 1)
            {
                return matchingMapping.First()._mappingDictionary;
            }

            throw new Exception(
                $"Cannot find exact property mapping instance for <{typeof(TSource)}, {typeof(TDestination)}>"
            );
        }
    }
}