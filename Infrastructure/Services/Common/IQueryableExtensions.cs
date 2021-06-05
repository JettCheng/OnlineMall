using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services.PropertyMapping;
using System.Linq.Dynamic.Core;

namespace Infrastructure.Services.Common
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplySort<T> (
            this IQueryable<T> source, 
            string orderBy, 
            Dictionary<string, PropertyMappingValue> mappingDictionary
        )
        {
            if (source==null)
            {
              throw new ArgumentNullException("source");  
            }
            
            if (mappingDictionary==null)
            {
              throw new ArgumentNullException("mappingDictionary");  
            }
            
            if (orderBy==null)
            {
              throw new ArgumentNullException("orderBy");  
            }

            var orderByString = string.Empty;
            
            var orderByAfterSwitch = orderBy.Split(',');

            foreach (var order in orderByAfterSwitch)
            {
                var trimmedOrder = orderBy.Trim();

                // 通過 string desc 來判斷升序或降序
                var orderDescription = trimmedOrder.EndsWith("desc");

                // 刪除升序或降序字符串以取得屬性名稱
                var indexOfFirstSpace = trimmedOrder.IndexOf(' ');
                var propertyName = indexOfFirstSpace == -1
                    ? trimmedOrder
                    : trimmedOrder.Remove(indexOfFirstSpace);
                    
                if (!mappingDictionary.ContainsKey(propertyName))
                {
                    throw new ArgumentException($"Key mapping for {propertyName} is missing");
                }

                var propertyMappingValue = mappingDictionary[propertyName];
                if (propertyMappingValue==null)
                {
                    throw new ArgumentNullException("propertyMappingValue");
                }

                foreach (var destinationProperty in propertyMappingValue.DestinationProperties.Reverse())
                {
                    // 給IQueryable 添加排序字符串
                    orderByString = orderByString + (string.IsNullOrWhiteSpace(orderByString)? string.Empty : ", ")
                                    + destinationProperty + ( orderDescription? " descending" : " ascending");
                }
            }
            return source.OrderBy(orderByString); // System.Linq.Dynamic.Core
        }
    }
}