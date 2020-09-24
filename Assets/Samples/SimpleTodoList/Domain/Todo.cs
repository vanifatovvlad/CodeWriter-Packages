using UniMob;

namespace Samples.SimpleTodoList.Domain
{
    public class Todo
    {
        [Atom] public string Title { get; set; } = "";
        [Atom] public bool Finished { get; set; } = false;
    }
}