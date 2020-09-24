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
                Children =
                {
                    Widget.TodoList.Todos.Select(todo => new TodoWidget(todo)),
                    new UniMobText(
                        WidgetSize.FixedHeight(60),
                        $"Tasks left: {Widget.TodoList.UnfinishedTodoCount}"
                    )
                    {
                        FontSize = 50,
                    },
                }
            };
        }
    }
}