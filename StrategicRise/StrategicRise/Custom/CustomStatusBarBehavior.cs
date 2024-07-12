using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicRise.Custom
{
    class CustomStatusBarBehavior
    {
        public static Color StatusColor = Color.FromRgb(45, 45, 57);
        public static StatusBarStyle StatusStyle = StatusBarStyle.Default;

		public static readonly BindableProperty StatusBarColorProperty =
			BindableProperty.CreateAttached(
				"StatusBarColor",
				typeof(Color),
				typeof(CustomStatusBarBehavior),
				Color.FromRgb(0, 0, 0),
				propertyChanged: OnStatusBarColorChanged);

		public static readonly BindableProperty StatusBarStyleProperty =
			BindableProperty.CreateAttached(
				"StatusBarStyle",
				typeof(StatusBarStyle),
				typeof(CustomStatusBarBehavior),
				StatusBarStyle.Default,
				propertyChanged: OnStatusBarStyleChanged);

		private static void OnStatusBarStyleChanged(BindableObject view, object oldValue, object newValue)
		{
			Page page = view as Page;
			if (page != null)
			{
				if ((StatusBarStyle)newValue != (StatusBarStyle)oldValue)
				{
					StatusStyle = (StatusBarStyle)newValue;
					AddBehavior(page);
				}
			}
		}

		private static void OnStatusBarColorChanged(BindableObject view, object oldValue, object newValue)
		{
			Page page = view as Page;
			if (page != null)
			{
				if ((Color) newValue != (Color) oldValue)
				{
					StatusColor = (Color) newValue;
					AddBehavior(page);
				}
			}
		}

		private static void AddBehavior(Page page)
		{
			page.Behaviors.Add(new StatusBarBehavior
			{
				StatusBarColor = StatusColor,
				StatusBarStyle = StatusStyle
			});
		}
	}
}
