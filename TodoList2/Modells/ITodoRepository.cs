using System.Collections.Generic;
using ToDoList.Modells;

namespace TodoList2.Modells
{
    public interface ITodoRepository
    {
        public void Add(TodoItem item);
        public IEnumerable<TodoItem> GetAll();
        public TodoItem Remove(string key);
        public void UpDate(TodoItem item);
        public TodoItem Find(string key);


    }
}