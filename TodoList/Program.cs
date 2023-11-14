using Moq;

namespace TodoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Skapa ett mockobjekt av ITodoListStorage
            var mockStorage = new Mock<ITodoListStorage>();
            // Konfigurera mocken för att uppföra sig som förväntat
            mockStorage.Setup(storage => storage.SaveTodos(It.IsAny<List<TodoItem>>())).Returns(true);
            // Skapa en instans av TodoList och använd mockStorage som datalagring
            var todoList = new TodoList(mockStorage.Object);


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Todo List Menu:");
                Console.WriteLine("1. Add Todo");
                Console.WriteLine("2. Remove Todo");
                Console.WriteLine("3. Mark Todo as Complete");
                Console.WriteLine("4. Show All Todos");
                Console.WriteLine("5. Show Complete Todos");
                Console.WriteLine("6. Show Not Complete Todos");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Todo Title: ");
                        var title = Console.ReadLine();
                        var todo = new TodoItem { Title = title, IsComplete = false };
                        todoList.AddTodo(todo);
                        Console.WriteLine("Todo added successfully!");
                        break;
                    case "2":
                        Console.Write("Enter the index of the Todo to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int removeIndex))
                        {
                            todoList.RemoveTodo(removeIndex);
                            Console.WriteLine("Todo removed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid index.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter the index of the Todo to mark as complete: ");
                        if (int.TryParse(Console.ReadLine(), out int markCompleteIndex))
                        {
                            todoList.MarkTodoAsComplete(todoList.GetTodos()[markCompleteIndex]);
                            Console.WriteLine("Todo marked as complete!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid index.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("All Todos:");
                        var allTodos = todoList.GetTodos();
                        for (int i = 0; i < allTodos.Count; i++)
                        {
                            Console.WriteLine($"{i}. Title: {allTodos[i].Title}, Complete: {allTodos[i].IsComplete}");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Complete Todos:");
                        var completeTodos = todoList.ShowCompleteTodos();
                        for (int i = 0; i < completeTodos.Count; i++)
                        {
                            Console.WriteLine($"{i}. Title: {completeTodos[i].Title}, Complete: {completeTodos[i].IsComplete}");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Not Complete Todos:");
                        var notCompleteTodos = todoList.ShowNotCompleteTodos();
                        for (int i = 0; i < notCompleteTodos.Count; i++)
                        {
                            Console.WriteLine($"{i}. Title: {notCompleteTodos[i].Title}, Complete: {notCompleteTodos[i].IsComplete}");
                        }
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
                Console.ReadKey();

            }
        }
    }
}