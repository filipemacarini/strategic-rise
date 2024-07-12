using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace StrategicRise.ViewModels.Games.Domination
{
	partial class DominationSetupPageViewModel : ObservableObject
    {
        public bool OnlineMode { get; set; }

        [ObservableProperty]
        public int _numberOfPlayers;

		[ObservableProperty]
		public int _height;

		[ObservableProperty]
		public int _width;

		[ObservableProperty]
		public bool _arRightPlayersIsVisible;

		[ObservableProperty]
		public bool _arLeftPlayersIsVisible;


		[ObservableProperty]
		public bool _arRightHeightIsVisible;

		[ObservableProperty]
		public bool _arLeftHeightIsVisible;

		[ObservableProperty]
        public string _selectedMode;

        public DominationSetupPageViewModel()
        {
			ArLeftPlayersIsVisible = ArRightPlayersIsVisible = ArLeftHeightIsVisible = ArRightHeightIsVisible = true;
            NumberOfPlayers = Height = Width = 4;
        }

        [RelayCommand]
        public async Task ReturnToHomePage()
		{
			await Application.Current.MainPage.Navigation.PopAsync();
		}

        [RelayCommand]
        public void SelectGameMode(object selectedMode)
        {
            object[] objects = (object[])selectedMode;
            Border SelectedMode = (Border) objects[0];
            Grid GridFather = (Grid) objects[1];

            ResetGameModeBackColors(GridFather);

            SelectedMode.BackgroundColor = Color.FromArgb("#2d2d39");

            OnlineMode = false;
            if (GridFather.Children.First() == SelectedMode) OnlineMode = true;
		}

        public void ResetGameModeBackColors(Grid selectedMode)
        {
            foreach (Border child in selectedMode.Children)
            {
                child.BackgroundColor = Color.FromArgb("#22222b");
            }
		}

		[RelayCommand]
		public void AddPlayer()
		{
			if (NumberOfPlayers >= 10) return;
            NumberOfPlayers++;

			UpdateArrowsPlayersVisibility();
		}

		[RelayCommand]
		public void RemovePlayer()
		{
			if (NumberOfPlayers <= 2) return;
			NumberOfPlayers--;

			UpdateArrowsPlayersVisibility();
		}

		public void UpdateArrowsPlayersVisibility()
		{
			ArLeftPlayersIsVisible = NumberOfPlayers > 2;
			ArRightPlayersIsVisible = NumberOfPlayers < 10;
		}

		[RelayCommand]
		public void AddHeight()
		{
			if (Height >= 30) return;
			Height++;

			UpdateArrowsHeightVisibility();
		}

		[RelayCommand]
		public void RemoveHeight()
		{
			if (Height <= 4) return;
			Height--;

			UpdateArrowsHeightVisibility();
		}

		public void UpdateArrowsHeightVisibility()
		{
			ArLeftHeightIsVisible = Height > 4;
			ArRightHeightIsVisible = Height < 30;
		}
	}
}
