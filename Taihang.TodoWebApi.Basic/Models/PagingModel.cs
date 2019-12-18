using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taihang.TodoWebApi.Basic.Models
{
    // 通用分页模型
    public class PagingModel<T> where T : new()
    {
        public int PageCount { get; set; } // 总页码
        public int PageSize { get; set; } // 每页显示记录条数
        public int PageNumber { get; set; } // 当前页

        public IEnumerable<T> PageData { get; set; } // 页数据
    }
}