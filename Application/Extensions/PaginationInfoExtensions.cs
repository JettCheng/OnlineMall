using Application.Parameters;
using Core.Dtos;
using Infrastructure.Services.Common;
using Microsoft.AspNetCore.Mvc;

namespace Application.Extensions
{
    public class PaginationInfoExtensions
    {
        public static PaginationMetadata GeneratePaginationInfo<T> (
            IUrlHelper urlHelper,
            PaginationList<T> paginationList,
            PaginationParameters paginationParameters,
            string linkName
        ) 
        {
            var pageInfo = new 
            {
                pageNumber = paginationParameters.PageNumber - 1,
                pageSize = paginationParameters.PageSize
            };

            var paginationMetadata = new PaginationMetadata()
            {
                PreviousPageLink = paginationList.HasPrevious? urlHelper.Link(linkName,pageInfo) : null,
                NextPageLink = paginationList.HasNext? urlHelper.Link(linkName,pageInfo) : null,
                TotalCount = paginationList.TotalCount,
                PageSize = paginationList.PageSize,
                CurrentPage = paginationList.CurrentPage,
                TotalPages = paginationList.TotalPages
            };
            return paginationMetadata;
        }
    }
}