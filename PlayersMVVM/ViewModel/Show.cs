using System.Windows.Input;
using System.Windows;
using System.Collections.Generic;


namespace PlayersMVVM.ViewModel
{
    using Model;
    using BaseClasses;
    internal class Show : ViewModelBase
    {
        private AllPlayers allplayers = new AllPlayers();
        public List<int> AgeList { get => allplayers.GetAgeList; }
        public List<string> PlayersList { get => PlayersView.PlayersListView(allplayers.GetPlayerList); }

        //Interfejs publiczny
        public string CurrentFirstName { get; set; } = "Podaj imię";
        public string CurrentLastName { get; set; } = "Podaj nazwisko";
        public int CurrentAge { get; set; } = 10;
        public double CurrentWeight { get; set; } = 55.0;
        public int CurrentIndex { get; set; } = -1;

        //Polecenia
        private ICommand addplayer = null;
        private ICommand removeplayer = null;
        private ICommand modifyplayer = null;
        private ICommand showplayer = null;
        private ICommand saveplayers = null;

        public ICommand AddPlayer
        {
            get
            {
                if (addplayer == null)
                {
                    addplayer = new RelayCommend(
                        arg =>
                        {
                            allplayers.AddPlayerMethod(new Player(CurrentFirstName, CurrentLastName, CurrentAge, CurrentWeight));
                            onPropertyChanged(nameof(PlayersList));
                        },
                        arg => (!string.IsNullOrEmpty(CurrentFirstName)) && (!string.IsNullOrEmpty(CurrentLastName)) && (CurrentFirstName != "Podaj imię") 
                        && (CurrentLastName != "Podaj nazwisko")
                        );
                }
                return addplayer;
            }
        }

        public ICommand RemovePlayer
        {
            get
            {
                if(removeplayer == null)
                {
                    removeplayer = new RelayCommend(
                        arg =>
                        {
                            MessageBoxResult result = MessageBox.Show("Czy napewno chcesz usunąć zawodnika?", "Usunięto zawodnika", MessageBoxButton.YesNo);
                            if(result == MessageBoxResult.Yes)
                            {
                                allplayers.RemovePlayerMethod(CurrentIndex);
                                onPropertyChanged(nameof(PlayersList));
                            }
                        },
                        arg => CurrentIndex != -1
                        );
                }
                return removeplayer;
            }
        }

        public ICommand ModifyPlayer
        {
            get
            {
                if(modifyplayer == null)
                {
                    modifyplayer = new RelayCommend(
                        arg =>
                        {
                            MessageBoxResult result = MessageBox.Show("Czy napewno chcesz zmodyfikować zawodnika?", "Zmodyfikowano zawodnika", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.Yes)
                            {
                                allplayers.ModifyPlayerMethod(new Player(CurrentFirstName, CurrentLastName, CurrentAge, CurrentWeight), CurrentIndex);
                                onPropertyChanged(nameof(PlayersList));
                            }
                        },
                        arg => CurrentIndex != -1 && (!string.IsNullOrEmpty(CurrentFirstName)) && (!string.IsNullOrEmpty(CurrentLastName)) && (CurrentFirstName != "Podaj imię")
                        && (CurrentLastName != "Podaj nazwisko"));
                }
                return modifyplayer;
            }
        }

        public ICommand ShowPlayer
        {
            get
            {
                if(showplayer == null)
                {
                    showplayer = new RelayCommend(
                        arg =>
                        {
                            Player player = allplayers.GetPlayerList[CurrentIndex];
                            CurrentFirstName = player.FirstName;
                            CurrentLastName = player.LastName;
                            CurrentAge = player.Age;
                            CurrentWeight = player.Weight;
                            onPropertyChanged(nameof(CurrentFirstName), nameof(CurrentLastName), nameof(CurrentAge), nameof(CurrentWeight));
                        },
                        arg => CurrentIndex != -1
                        );
                }
                return showplayer;
            }
        }

        public ICommand SavePlayers
        {
            get
            {
                if (saveplayers == null)
                {
                    saveplayers = new RelayCommend(
                        arg => allplayers.SavePlayers(@"players.json"), arg => true
                        );
                }
                return saveplayers;
            }
        }

    }
}
