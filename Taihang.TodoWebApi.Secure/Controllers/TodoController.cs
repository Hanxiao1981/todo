using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Taihang.TodoWebApi.Secure.Models;

namespace Taihang.TodoWebApi.Secure.Controllers
{
    [Authorize]
    public class TodoController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Todo
        public PagingModel<Todo> GetTodoList(string searchKey, int pageSize = 10, int pageNumber = 1)
        {
            PagingModel<Todo> pagingTodo = new PagingModel<Todo> { PageCount = pageNumber, PageSize = pageSize, PageNumber = pageNumber, PageData = new List<Todo>() };

            IQueryable<Todo> query = db.Todo;

            if (!string.IsNullOrEmpty(searchKey))
            {
                query = query.Where(todo => todo.Name.IndexOf(searchKey) > -1);
            }

            int todoSum = query.Count();

            if (todoSum > 0)
            {
                pagingTodo.PageData = query.OrderByDescending(todo => todo.ID).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

                // 计算总页码
                pagingTodo.PageCount = todoSum / pageSize;

                if (todoSum % pageSize != 0)
                {
                    pagingTodo.PageCount += 1;
                }
            }

            return pagingTodo;
        }

        // GET: api/Todo/5
        //[ResponseType(typeof(Todo))]
        //public IHttpActionResult GetTodo(int id)
        //{
        //    Todo todo = db.Todo.Find(id);
        //    if (todo == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(todo);
        //}

        // PUT: api/Todo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTodo(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != todo.ID)
            //{
            //    return BadRequest();
            //}

            //db.Entry(todo).State = EntityState.Modified;
            int id = todo.ID;
            Todo dbTodo = db.Todo.Find(id);
            dbTodo.Name = todo.Name;
            dbTodo.Completed = todo.Completed;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Todo
        [ResponseType(typeof(void))]
        public IHttpActionResult PostTodo(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Todo.Add(todo);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Todo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteTodo(int id)
        {
            Todo todo = db.Todo.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            db.Todo.Remove(todo);
            db.SaveChanges();

            //return Ok(todo);
            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TodoExists(int id)
        {
            return db.Todo.Count(e => e.ID == id) > 0;
        }
    }
}