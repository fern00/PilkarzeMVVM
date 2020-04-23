﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersMVVM.ViewModel
{
    using BaseClasses;
    using Model;
    class PlayersView : ViewModelBase
    {
        public static List<string> PlayersListView(List<Player> players)
        {
            List<string> playerslistview = new List<string>();
            for (int i = 0; i < players.Count; i++)
                playerslistview.Add(players[i].ToString());
            return playerslistview;
        }
    }
}
