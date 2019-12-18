using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taihang.TodoWebApi.Basic.Models
{
    public class Todo
    {
        public Todo()
        {
            CreateTime = DateTime.Now;
        }

        public int ID { get; set; } // 任务ID

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // 任务名称

        public bool Completed { get; set; } // 是否完成

        public DateTime CreateTime { get; set; } // 创建时间
    }
}