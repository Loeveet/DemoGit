using Moq;

namespace TodoList.Tests
{
    public class TodoListTests
    {
        [Fact]
        public void AddTodo_Should_Add_Item_To_Todos()
        {
            // Arrange
            // Skapa ett mockobjekt av ITodoListStorage f�r att simulera datalagring
            var mockStorage = new Mock<ITodoListStorage>();
            // Konfigurera mocken s� att SaveTodos returnerar true n�r den kallas
            mockStorage.Setup(storage => storage.SaveTodos(It.IsAny<List<TodoItem>>())).Returns(true);
            // Skapa en instans av TodoList och anv�nd mockStorage som datalagring
            var sut = new TodoList(mockStorage.Object);
            // Skapa en ny uppgift
            var todoItem = new TodoItem { Id = 1, Title = "Buy groceries", Description = "Milk, eggs, bread", IsComplete = false };
            var expected = true; // F�rv�ntat resultat

            // Act
            var actual = sut.AddTodo(todoItem); // L�gg till uppgiften i listan

            // Assert
            Assert.Equal(expected, actual); // Kontrollera att metoden returnerar det f�rv�ntade resultatet
        }

        [Fact]
        public void RemoveTodo_Should_Remove_Item_From_Todos()
        {
            // Arrange
            // Skapa ett mockobjekt av ITodoListStorage f�r att simulera datalagring
            var mockStorage = new Mock<ITodoListStorage>();
            // Skapa en instans av TodoList och anv�nd mockStorage som datalagring
            var sut = new TodoList(mockStorage.Object);
            // Skapa en ny uppgift
            var todoItem = new TodoItem { Id = 1, Title = "Buy groceries", Description = "Milk, eggs, bread", IsComplete = false };
            sut.AddTodo(todoItem); // L�gg till uppgiften i listan

            // Act
            sut.RemoveTodo(0); // Ta bort uppgiften fr�n listan med hj�lp av dess index

            // Assert
            Assert.DoesNotContain(todoItem, sut.GetTodos()); // Kontrollera att uppgiften inte l�ngre finns i listan
        }

        [Fact]
        public void MarkAsComplete_Should_Mark_Item_As_Complete_In_Todos()
        {
            // Arrange
            // Skapa ett mockobjekt av ITodoListStorage f�r att simulera datalagring
            var mockStorage = new Mock<ITodoListStorage>();
            // Konfigurera mocken s� att SaveTodos returnerar true n�r den kallas
            mockStorage.Setup(storage => storage.SaveTodos(It.IsAny<List<TodoItem>>())).Returns(true);
            // Skapa en instans av TodoList och anv�nd mockStorage som datalagring
            var sut = new TodoList(mockStorage.Object);
            // Skapa en ny uppgift
            var todoItem = new TodoItem { Id = 1, Title = "Buy groceries", Description = "Milk, eggs, bread", IsComplete = false };
            sut.AddTodo(todoItem); // L�gg till uppgiften i listan

            // Act
            var actual = sut.MarkTodoAsComplete(todoItem); // Markera uppgiften som klar

            // Assert
            Assert.True(actual); // Kontrollera att metoden returnerar true, vilket indikerar att uppgiften har markerats som klar
        }

        [Fact]
        public void ShowAllTodosThatIsComplete()
        {
            // Arrange
            // Skapa ett mockobjekt av ITodoListStorage f�r att simulera datalagring
            var mockStorage = new Mock<ITodoListStorage>();
             // Skapa en instans av TodoList och anv�nd mockStorage som datalagring
            var sut = new TodoList(mockStorage.Object);
            // Skapa en ny uppgift
            var todo1 = new TodoItem { Id = 1, Title = "Buy groceries", Description = "Milk, eggs, bread", IsComplete = true };
            var todo2 = new TodoItem { Id = 2, Title = "Read a book", Description = "Forrest Gump", IsComplete = false };
            var todo3 = new TodoItem { Id = 3, Title = "Go for a run", Description = "Atleast 5km", IsComplete = true };

            sut.AddTodo(todo1); // L�gg till uppgiften i listan
            sut.AddTodo(todo2); // L�gg till uppgiften i listan
            sut.AddTodo(todo3); // L�gg till uppgiften i listan


            // Act
            var actual = sut.ShowCompleteTodos();
            // Assert
            Assert.Collection(actual,
                item => Assert.Equal(todo1, item),  // Kontrollera att de klara todos �r med i listan
                item => Assert.Equal(todo3, item));
        }

        [Fact]
        public void ShowAllTodosThatIsNotComplete()
        {
            // Arrange
            // Skapa ett mockobjekt av ITodoListStorage f�r att simulera datalagring
            var mockStorage = new Mock<ITodoListStorage>();
            // Skapa en instans av TodoList och anv�nd mockStorage som datalagring
            var sut = new TodoList(mockStorage.Object);
            // Skapa en ny uppgift
            var todo1 = new TodoItem { Id = 1, Title = "Buy groceries", Description = "Milk, eggs, bread", IsComplete = true };
            var todo2 = new TodoItem { Id = 2, Title = "Read a book", Description = "Forrest Gump", IsComplete = false };
            var todo3 = new TodoItem { Id = 3, Title = "Go for a run", Description = "Atleast 5km", IsComplete = true };

            sut.AddTodo(todo1); // L�gg till uppgiften i listan
            sut.AddTodo(todo2); // L�gg till uppgiften i listan
            sut.AddTodo(todo3); // L�gg till uppgiften i listan


            // Act
            var actual = sut.ShowNotCompleteTodos();
            // Assert
            Assert.Collection(actual,
                item => Assert.Equal(todo2, item));
        }
    }

}