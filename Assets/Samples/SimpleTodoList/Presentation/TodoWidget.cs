using Samples.SimpleTodoList.Domain;
using UniMob.UI;
using UniMob.UI.Widgets;

namespace Samples.SimpleTodoList.Presentation
{
    public class TodoWidget : StatefulWidget
    {
        public TodoWidget(Todo todo) => Todo = todo;

        public Todo Todo { get; }

        public override State CreateState() => new TodoState();
    }

    public class TodoState : HocState<TodoWidget>
    {
        public override Widget Build(BuildContext context)
        {
            return new UniMobButton
            {
                OnClick = () => Widget.Todo.Finished = !Widget.Todo.Finished,
                Child = new UniMobText(
                    size: WidgetSize.FixedHeight(60),
                    value: $" - {Widget.Todo.Title}: {(Widget.Todo.Finished ? "Finished" : "Active")}"
                )
                {
                    FontSize = 40,
                }
            };
        }
    }
}