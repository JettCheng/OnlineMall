using System.Collections.Generic;

namespace Infrastructure.Services.PropertyMapping
{
    public class PropertyMappingValue
    {   
        // 目標屬性清單的字串列表
        public IEnumerable<string> DestinationProperties { get; private set; }

        public PropertyMappingValue(IEnumerable<string> destinationProperties)
        {
            DestinationProperties = destinationProperties;
        }
    }
}