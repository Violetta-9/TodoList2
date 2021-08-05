using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ToDoList.Modells;

namespace TodoList2.Modells
{
    public class TodoList : ITodoRepository
    {
        public ConcurrentDictionary<string, TodoItem> _todo = new ConcurrentDictionary<string, TodoItem>();


        public TodoList()
        {
            Add(new TodoItem() { Name = "Item1" });
        }
        public void Add(TodoItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todo[item.Key] = item;
        }

        public TodoItem Find(string key)
        {
            TodoItem item;
            _todo.TryGetValue(key, out item);
            return item;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todo.Values;
        }

        public TodoItem Remove(string key)
        {
            TodoItem item;
            _todo.TryRemove(key, out item);
            return item;
        }

        public void UpDate(TodoItem item)
        {
            _todo[item.Key] = item;
        }
    }
}

