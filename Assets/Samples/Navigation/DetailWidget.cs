using System;
using System.Collections.Generic;
using UniMob.UI;
using UniMob.UI.Widgets;
using UnityEngine;

namespace Samples.Navigation
{
    public class DetailWidget : StatefulWidget
    {
        public Action Close { get; set; }

        public override State CreateState() => new DetailState();
    }

    public class DetailState : HocState<DetailWidget>
    {
        public override Widget Build(BuildContext context)
        {
            return new Navigator("/", new Dictionary<string, Func<Route>>
            {
                ["/"] = BuildDefaultRoute,
            });
        }

        private Route BuildDefaultRoute()
        {
            return new AnimatedPageRoute(
                name: "default",
                duration: 0.2f,
                builder: (context, tween) => new Container
                {
                    Size = WidgetSize.Stretched,
                    BackgroundColor = Color.grey,

                    Child = new UniMobButton
                    {
                        OnClick = () => Widget.Close?.Invoke(),

                        Child = new UniMobText(WidgetSize.Fixed(600, 200))
                        {
                            Value = "Close Detail",
                            FontSize = 60,
                            Color = Color.black,
                            MainAxisAlignment = MainAxisAlignment.Center,
                            CrossAxisAlignment = CrossAxisAlignment.Center,
                        }
                    }
                });
        }
    }
}