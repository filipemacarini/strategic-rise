using Android.Content.Res;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicRise.Platforms.Android
{
	public class CustomeShell : ShellRenderer
	{
		public CustomeShell()
		{

		}

		protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
		{
			return new CustomeShellBottomViewAppearance();
		}
	}

	public class CustomeShellBottomViewAppearance : IShellBottomNavViewAppearanceTracker
	{
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public void ResetAppearance(BottomNavigationView bottomView)
		{
			throw new NotImplementedException();
		}

		public void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
		{
			bottomView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilityUnlabeled;
			bottomView.ItemIconSize = 120;
			bottomView.SetBackgroundColor(Color.FromRgb(22, 22, 29).ToPlatform());
			bottomView.ItemIconTintList = ColorStateList.ValueOf(Colors.White.ToPlatform());
			bottomView.SetPadding(90, 40, 90, 40);
			
			BottomNavigationMenuView bottomNavView = bottomView.GetChildAt(0) as BottomNavigationMenuView;
			for (byte i = 0; i < bottomNavView?.ChildCount; i++)
			{
				if (bottomNavView.GetChildAt(i).Selected)
				{
					var item = bottomNavView.GetChildAt(i) as BottomNavigationItemView;
					item?.SetIconTintList(ColorStateList.ValueOf(Color.FromRgb(180, 180, 200).ToPlatform()));
				}
			}
		}
	}
}
