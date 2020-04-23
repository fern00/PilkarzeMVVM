using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersMVVM.Model
{
    class Player
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int Age { set; get; }
        public double Weight { set; get; }

        public Player(string firstname, string lastname, int age, double weight)
        {
            FirstName = firstname;
            LastName = lastname;
            Age = age;
            Weight = weight;
        }

        public Player(Player player)
        {
            FirstName = player.FirstName;
            LastName = player.LastName;
            Age = player.Age;
            Weight = player.Weight;
        }

        public Player() { }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, wiek: {Age}, waga: {Weight} kg";
        }
    }
}
