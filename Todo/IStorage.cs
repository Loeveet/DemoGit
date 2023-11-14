using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    public interface IStorage
    {
        List<TodoItem> GetAllTodos();

        /// <summary>
        /// Adds the item to the database, or if it already exists, updates it
        /// </summary>
        /// <param name="todoItem">The item to save</param>
        void SaveTodoItem(TodoItem todoItem);
        void RemoveTodoItem(int index);
    }
}
