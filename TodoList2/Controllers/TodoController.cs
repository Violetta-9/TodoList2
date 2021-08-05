using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Modells;
using TodoList2.Modells;

namespace TodoList2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository TodoItems;
        private readonly Test Test;

        public TodoController(ITodoRepository todoItems, Test test)
        {
            TodoItems = todoItems;
            Test = test;
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            Test.Name = "12323323";
            return TodoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var result = TodoItems.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            return new ObjectResult(result);//метод возвращает код 200 и тело ответа в формате JSON
        }

        [HttpPost]
        public IActionResult  Create([FromBody] TodoItem item)
        {

            if (item == null)
            {
                return BadRequest();
            }
            TodoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var todo = TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            TodoItems.UpDate(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result = TodoItems.Find(id);
            if (result != null)
            {
                TodoItems.Remove(id);
                return new NoContentResult();
            }

            return NotFound();
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] TodoItem item, string id)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var todo = TodoItems.Find(id);
            if ( todo== null)
            {
                return NotFound();
            }

            item.Key = todo.Key;
            TodoItems.UpDate(item);
            return new NoContentResult();
        }
    }
}

