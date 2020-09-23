using System;
using System.Collections.Generic;
using UniMob.UI;
using UniMob.UI.Widgets;
using UnityEngine;

namespace NavigatorSample
{
    public class NavigationApp : UniMobUIApp
    {
        protected override Widget Build(BuildContext context)
        {
            return new Navigator("main", new Dictionary<string, Func<Route>>
            {
                ["main"] = BuildMainRoute,
                ["detail"] = BuildDetailRoute,
            });
        }

        private Route BuildMainRoute()
        {
            return new AnimatedPageRoute(
                name: "main",
                duration: 0.2f,
                builder: (context, tween) => new CompositeTransition
                {
                    Opacity = tween,

                    Child = new MainWidget
                    {
                        ShowDetail = () => Navigator.PushNamed(context, "detail"),
                    }
                }
            );
        }

        private Route BuildDetailRoute()
        {
            return new AnimatedPageRoute(
                name: "detail",
                duration: 0.2f,
                builder: (context, tween) => new CompositeTransition
                {
                    Opacity = tween,
                    Position = tween.Drive(new Vector2Tween(Vector2.left, Vector2.zero)),

                    Child = new DetailWidget
                    {
                        Close = () => Navigator.Pop(context),
                    },
                }
            );
        }
    }
}