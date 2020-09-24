using System.Linq;
using Samples.SimpleTodoList.Domain;
using Samples.SimpleTodoList.Presentation;
using UniMob.UI;
using UniMob.UI.Widgets;
using UnityEngine;

namespace Samples.SimpleTodoList
{
    public class TodoListApp : UniMobUIApp
    {
        private readonly TodoList _store = new TodoList();

        protected override void Initialize()
        {
            _store.Todos = _store.Todos
                .Append(new Todo {Title = "Get Coffee"})
                .Append(new Todo {Title = "Write simpler code"})
                .ToArray();

            _store.Todos[0].Finished = true;
        }

        protected override Widget Build(BuildContext context)
        {
            return new Container
            {
                BackgroundColor = Color.white,
                Child = new TodoListWidget(_store),
            };
        }
    }
}