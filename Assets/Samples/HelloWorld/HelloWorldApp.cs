using UniMob.UI;
using UniMob.UI.Widgets;
using UnityEngine;

namespace Samples.HelloWorld
{
    public class HelloWorldApp : UniMobUIApp
    {
        protected override Widget Build(BuildContext context)
        {
            return new Container
            {
                Size = WidgetSize.Stretched,
                BackgroundColor = Color.white,
                Child = new UniMobText(
                    value: "Hello World!",
                    size: WidgetSize.Stretched
                )
                {
                    Color = Color.blue,
                    FontSize = 60,
                },
            };
        }
    }
}