using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Common
{
    public class PaginationList<T> : List<T>
    {
        // 當前頁面 index
        public int CurrentPage { get; set; }

        // 每頁幾筆資料
        public int PageSize { get; set; }

        // 資料總筆數
        public int TotalCount { get; private set; }

        // 有前一頁
        public bool HasPrevious => CurrentPage > 1;

        // 有下一頁
        public bool HasNext => CurrentPage < TotalPages;


        // 總頁數
        public int TotalPages { get; private set; }

        public PaginationList(int totalCount, int currentPage, int pageSize, List<T> items)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            AddRange(items);
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }

        public static async Task<PaginationList<T>> CreateAsync(
            int currentPage, int pageSize, IQueryable<T> result)
        {
            var totalCount = await result.CountAsync();
            // pagination
            // skip
            var skip = (currentPage - 1) * pageSize;
            result = result.Skip(skip);
            // 以 pagesize 為標準顯示一定數量數據
            result = result.Take(pageSize);

            // include vs join
            var items = await result.ToListAsync();

            return new PaginationList<T>(totalCount, currentPage, pageSize, items);
        }
    }
}
