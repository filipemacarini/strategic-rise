using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicRise.Models
{
    public partial class GameCard : ObservableObject
    {
		public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
		[ObservableProperty]
		public Color _borderColor;
        public Type GameSetupPage { get; set; }

        public GameCard(string name, string description, string photoPath, Type gameSetupPage)
		{
			Name = name;
			Description = description;
			PhotoPath = photoPath;
			BorderColor = Color.FromRgb(22, 22, 29);
			GameSetupPage = gameSetupPage;
		}
	}
}
