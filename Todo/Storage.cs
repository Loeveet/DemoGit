using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    public class Storage : IStorage
    {
        public static List<TodoItem> TodoItems { get; set; }

        public Storage()
        {
            TodoItems = new List<TodoItem>();
        }

        public List<TodoItem> GetAllTodos() => TodoItems;

        public void RemoveTodoItem(int index) => TodoItems.RemoveAt(index);

        public void SaveTodoItem(TodoItem todoItem)
        {
            var item = TodoItems.FirstOrDefault(x => x.Id == todoItem.Id);
            if (item == null)
            {
                TodoItems.Add(todoItem);
            }
            else
            {
                // update list in database
            }


        }
    }
}
