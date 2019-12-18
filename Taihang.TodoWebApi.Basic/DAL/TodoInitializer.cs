using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Taihang.TodoWebApi.Basic.Models;

namespace Taihang.TodoWebApi.Basic.DAL
{
    public class TodoInitializer: DropCreateDatabaseIfModelChanges<TodoDbContext>
    {
        // 添加数据库初始数据
        protected override void Seed(TodoDbContext context)
        {
            List<Todo> todoList = new List<Todo>();

            // 任务总数，任务间隔天数(避免任务创建时间雷同)
            int todoSums = 150, daySpan = 15;

            for (int i = 0; i < todoSums; i++)
            {
                int days = (todoSums - i) / daySpan; // 前面的任务创建时间较早

                todoList.Add(new Todo { Name = $"随机任务 {i + 1}", CreateTime = DateTime.Now.AddDays(-days) });
            }

            todoList.ForEach(todo => context.Todo.Add(todo));
            context.SaveChanges();
        }
    }
}