using UniMob;
using UniMob.UI;
using UniMob.UI.Widgets;
using UnityEngine;

namespace Samples.HelloWorld
{
    public class SimpleCounterApp : UniMobUIApp
    {
        [Atom] private int Counter { get; set; } = 0;

        protected override Widget Build(BuildContext context)
        {
            return new Container
            {
                BackgroundColor = Color.white,
                Size = WidgetSize.Stretched,
                Child = BuildContent(),
            };
        }

        private Widget BuildContent()
        {
            return new Column
            {
                MainAxisAlignment = MainAxisAlignment.Center,
                CrossAxisAlignment = CrossAxisAlignment.Center,
                Children =
                {
                    BuildCounterText(),
                    BuildIncrementButton()
                }
            };
        }

        private Widget BuildCounterText()
        {
            // wrap frequently updated widgets into Builder widget
            // to reduce widget tree rebuild count (optionally)
            return new Builder(context =>
            {
                return new UniMobText(WidgetSize.Fixed(400, 100))
                {
                    Value = $"Counter: {Counter}",
                    FontSize = 40,
                    MainAxisAlignment = MainAxisAlignment.Center,
                    CrossAxisAlignment = CrossAxisAlignment.Center,
                };
            });
        }

        private Widget BuildIncrementButton()
        {
            return new UniMobButton
            {
                OnClick = () => Counter++,
                Child = new Container
                {
                    BackgroundColor = Color.grey,
                    Child = new UniMobText(WidgetSize.Fixed(400, 100))
                    {
                        Value = "Increment",
                        FontSize = 40,
                        MainAxisAlignment = MainAxisAlignment.Center,
                        CrossAxisAlignment = CrossAxisAlignment.Center,
                    }
                },
            };
        }
    }
}