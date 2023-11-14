using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodolistProgram;
using Todo;

namespace Todo.Tests
{
    public class UserInteractionTests
    {
        [Fact]
        public void GetInputWorksWhenUserInputsString()
        {
            // Arrange
            var mock = new Mock<IConsoleWrapper>();
            var expected = "Daniel";
            mock.Setup(x => x.ReadLine()).Returns(expected);
            var sut = new UserInteractionWrapper(mock.Object);

            // Act
            var actual = sut.GetStringInput("Vad heter du?");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetInputKeepsTryingOnEmpty()
        {
            // Arrange
            var mock = new Mock<IConsoleWrapper>();
            var expected = "Daniel";
            mock.SetupSequence(x => x.ReadLine())
                .Returns("")
                .Returns("")
                .Returns("")
                .Returns(expected);
            var sut = new UserInteractionWrapper(mock.Object);

            // Act
            var actual = sut.GetStringInput("Vad heter du?");

            // Assert
            Assert.Equal(expected, actual);
            mock.Verify(x => x.ReadLine(), Times.Exactly(4));
        }

        //[Fact]
        //public void Test_UserInteraction_GetUserInput_Sequential()
        //{
        //    // Arrange
        //    var mock = new Mock<IConsoleWrapper>();

        //    var sequence = new MockSequence();

        //    mock.Setup(x =>
        //        x.ReadLine("Ange titel: ")).Returns("Vattna blommorna");


        //    var sut = new UserInteractionWrapper<mock.Object>();

        //    //Act
        //    var result1 = sut.GetInput("Ange titel: ");
        //    var result2 = sut.GetInput("Ange beskrivning: ");

        //    // Assert
        //    Assert.Equal("Vattna blommorna", result1);
        //    Assert.Equal("Alla blommor utom de i köket", result2);
        //}

        //[Theory]
        //[InlineData("Daniel", "Vad heter du?")]
        //[InlineData("", "Vad heter du?", typeof(ArgumentNullException))]
        //[InlineData(null, "Vad heter du?", typeof(ArgumentNullException))]
        //public void GetInputHandlesDifferentScenarios(string expected, string instruction, Type expectedExceptionType = null)
        //{
        //    // Arrange
        //    var mock = new Mock<IConsoleWrapper>();
        //    mock.Setup(x => x.ReadLine())
        //        .Returns(expected);
        //    var sut = new UserInteractionWrapper(mock.Object);

        //    // Act och Assert
        //    if (expectedExceptionType == null)
        //    {
        //        var acutal = sut.GetStringInput(instruction);
        //        Assert.Equal(expected, acutal);
        //    }
        //    else
        //    {
        //        Assert.Throws(expectedExceptionType, () => sut.GetStringInput(instruction));
        //    }
        //}

        [Fact]
        public void GetTodoItemByIndex_IndexWithinRange_ReturnsTodoItem()
        {
            // Arrange
            var todoListStorageMock = new Mock<IStorage>();
            var todoListService = new TodoList(todoListStorageMock.Object);

            todoListStorageMock.Setup(x => x.GetAllTodos()).Returns(new List<TodoItem>
                 {
                     new TodoItem {  },
                     new TodoItem {  },
                     new TodoItem {  }
                 });

            // Act
            var result = todoListService.GetTodoItemByIndex(2);

            // Assert
            Assert.NotNull(result);
        }

        //        [Fact]
        //        public void GetTodoItemByIndex_IndexOutOfRange_ThrowsException()
        //        {
        //            // Arrange
        //            var todoListStorageMock = new Mock<IStorage>();
        //            var todoListService = new TodoList(todoListStorageMock.Object);

        //            todoListStorageMock.Setup(x => x.GetAllTodos()).Returns(new List<TodoItem>
        //     {
        //         new TodoItem {  },
        //         new TodoItem {  },
        //         new TodoItem {  }
        //     });

        //            // Act and Assert
        //            Assert.Throws<InvalidOperationException>(() => todoListService.GetTodoItemByIndex(5));
        //        }
        //        [Fact]
        //        public void GetInputWorksWhenUserInputsInt()
        //        {
        //            // Arrange
        //            var mock = new Mock<IConsoleWrapper>();
        //            var expected = "42";
        //            mock.SetupSequence(x => x.ReadLine())
        //                .Returns(expected);
        //            var sut = new UserInteractionWrapper(mock.Object);

        //            // Act
        //            var actual = sut.GetIntInput("Ange ett heltal:");

        //            // Assert
        //            Assert.Equal(42, actual);
        //        }

        //        [Fact]
        //        public void GetInputKeepsTryingOnNonValidInteger()
        //        {
        //            // Arrange
        //            var mock = new Mock<IConsoleWrapper>();
        //            var expected = "42";
        //            mock.SetupSequence(x => x.ReadLine())
        //                .Returns("inte ett heltal")
        //                .Returns("inte heller ett heltal")
        //                .Returns("")
        //                .Returns(expected);
        //            var sut = new UserInteractionWrapper(mock.Object);

        //            // Act
        //            var actual = sut.GetIntInput("Ange ett heltal:");

        //            // Assert
        //            Assert.Equal(42, actual);
        //            mock.Verify(x => x.ReadLine(), Times.Exactly(4));
        //        }
    }
}
