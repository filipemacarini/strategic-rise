using StrategicRise.ViewModels.Games.Domination;

namespace StrategicRise.Views.Games.Domination;

public partial class DominationSetupPage : ContentPage
{
	public DominationSetupPage()
	{
		InitializeComponent();
		BindingContext = new DominationSetupPageViewModel();
	}
}