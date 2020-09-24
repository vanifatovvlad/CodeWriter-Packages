using System.Linq;
using Samples.SimpleTodoList.Domain;
using UniMob.UI;
using UniMob.UI.Widgets;

namespace Samples.SimpleTodoList.Presentation
{
    public class TodoListWidget : StatefulWidget
    {
        public TodoListWidget(TodoList todoList) => TodoList = todoList;

        public TodoList TodoList { get; }

        public override State CreateState() => new TodoListState();
    }

    public class TodoListState : HocState<TodoListWidget>
    {
        public override Widget Build(BuildContext context)
        {
            return new Column
            {
                MainAxisSize = AxisSize.Max,
                CrossAxisSize = AxisSize.Max,

                Children = Widget.TodoList.Todos
                    .Select(BuildTodo)
                    .Append(BuildTaskLeft())
                    .ToList(),
            };
        }

        private Widget BuildTodo(Todo todo)
        {
            return new TodoWidget(todo);
        }

        private Widget BuildTaskLeft()
        {
            return new UniMobText(
                WidgetSize.FixedHeight(60),
                $"Tasks left: {Widget.TodoList.UnfinishedTodoCount}"
            )
            {
                FontSize = 50,
            };
        }
    }
}