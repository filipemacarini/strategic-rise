using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StrategicRise.Models;
using StrategicRise.Views.Games.Domination;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicRise.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        public ObservableCollection<GameCard> Games { get; set; }

        [ObservableProperty]
        public GameCard _selectedGame;

        public HomePageViewModel()
        {
            Games = new ObservableCollection<GameCard>
			{
				new GameCard( "Domination", "Expand and dominate", "Games/domination.png", typeof(DominationSetupPage) ),
				new GameCard( "Exemple", "Join this game", "", typeof(DominationSetupPage) ),
				new GameCard( "Exemple", "Join this game", "", typeof(DominationSetupPage) ),
				new GameCard( "Exemple", "Join this game", "", typeof(DominationSetupPage) ),
				new GameCard( "Exemple", "Join this game", "", typeof(DominationSetupPage) ),
			};
        }

        [RelayCommand]
        public void SelectedGameChanged()
        {
            ResetGameCardBorders(Games);
            SelectedGame.BorderColor = Color.FromArgb("00cc00");
        }

        public void ResetGameCardBorders(ObservableCollection<GameCard> games)
        {
            foreach (GameCard game in games)
            {
                game.BorderColor = Color.FromRgb(22, 22, 29);
			}
        }

        [RelayCommand]
        public async void StartGame()
        {
            if (SelectedGame != null)
            {
				var gameSetupPage = Activator.CreateInstance(SelectedGame.GameSetupPage) as Page;
				if (gameSetupPage != null)
				{
					await Application.Current.MainPage.Navigation.PushAsync(gameSetupPage);
				}
			}
		}
	}
}
