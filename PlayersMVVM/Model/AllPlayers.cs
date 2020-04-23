using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PlayersMVVM.Model
{
    class AllPlayers
    {
        //Listy do wyświetlenia
        List<int> AgeList = age();
        List<Player> PlayersList = LoadPlayers(@"players.json");

        //Metody
        public void AddPlayerMethod(Player player) { PlayersList.Add(player); }
        public void RemovePlayerMethod(int index) { PlayersList.RemoveAt(index); }
        public void ModifyPlayerMethod(Player player, int index) { PlayersList[index] = player; }
        public List<int> GetAgeList { get => AgeList; }
        public List<Player> GetPlayerList { get => PlayersList; }
        
        //Generowanie listy wieku
        private static List<int> age()
        {
            List<int> l = new List<int>();
            for (int i = 10; i < 60; i++)
                l.Add(i);
            return l;
        }

        //Wczytywanie graczy z json
        private static List<Player> LoadPlayers(string FileName)
        {
            List<Player> PlayersList = new List<Player>();
            if (File.Exists(FileName))
                PlayersList = JsonConvert.DeserializeObject<List<Player>>(File.ReadAllText(FileName));
            return PlayersList;
        }

        //Zapisywanie graczy do json
        public void SavePlayers(string FileName)
        {
            string save = JsonConvert.SerializeObject(PlayersList);
            File.WriteAllText(FileName, save);
        }
    }
}
