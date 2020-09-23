using System.Collections.Generic;
using UniMob;
using UniMob.UI;
using UniMob.UI.Widgets;
using UnityEngine;

namespace Samples.HelloWorld
{
    public class SimpleCounterApp : UniMobUIApp
    {
        private MutableAtom<int> _counter = Atom.Value("Counter", 0);

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
                Children = new List<Widget>
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
                return new UniMobText(
                    value: $"Counter: {_counter.Value}",
                    size: WidgetSize.Fixed(400, 100)
                )
                {
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
                OnClick = () => _counter.Value++,
                Child = new Container
                {
                    BackgroundColor = Color.grey,
                    Child = new UniMobText(
                        value: "Increment",
                        size: WidgetSize.Fixed(400, 100)
                    )
                    {
                        FontSize = 40,
                        MainAxisAlignment = MainAxisAlignment.Center,
                        CrossAxisAlignment = CrossAxisAlignment.Center,
                    }
                },
            };
        }
    }
}