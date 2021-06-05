using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Parameters
{
    public class PaginationParameters
    {
        public string OrderBy { get; set; }

        // 頁碼預設值為 1
        private int _pageNumber = 1;

        // 頁碼
        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                if (value >= 1)
                {
                    _pageNumber = value;
                }
            }
        }

        // 每頁預設10筆資料
        private int _pageSize = 10;

        // 每頁預設最多50筆
        const int maxPageSize = 50;

        // 每頁幾筆資料
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if (value >= 1)
                {
                    _pageSize = (value > maxPageSize) ? maxPageSize : value;
                }
            }
        }
    }
}
