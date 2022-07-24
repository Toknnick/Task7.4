using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Work();
        }
    }

    class Server
    {
        private List<Player> _players = new List<Player>();

        public Server()
        {
            AddPlayers();
        }

        public void Work()
        {
            int top = 3;
            IEnumerable<Player> sortedPlayers;
            Console.WriteLine("Игроки на сервере:");
            ShowAllPlayers();
            Console.WriteLine(" \nТоп по уровню:");
            sortedPlayers = _players.OrderByDescending(player => player.Level).Take(top);
            ShowTopPlayers(sortedPlayers);
            Console.WriteLine(" \nТоп по силе:");
            sortedPlayers = _players.OrderByDescending(player => player.Power).Take(top);
            ShowTopPlayers(sortedPlayers);
        }

        private void ShowAllPlayers()
        {
            foreach (Player player in _players)
            {
                player.ShowInfo();
            }
        }

        private void ShowTopPlayers(IEnumerable<Player> sortedPlayers)
        {
            foreach (Player player in sortedPlayers)
            {
                player.ShowInfo();
            }
        }

        private void AddPlayers()
        {
            Random random = new Random();
            int minCountOfPlayers = 10;
            int maxCountOfPlayers = 20;
            int maxValue = 100;
            int countOfPlayers = random.Next(minCountOfPlayers, maxCountOfPlayers);

            for (int i = 0; i < countOfPlayers; i++)
            {
                int level = random.Next(maxValue);
                int power = random.Next(maxValue);
                _players.Add(new Player(SetNameOfPlayer(i), level, power));
            }
        }

        private string SetNameOfPlayer(int numberOfName)
        {
            List<string> namesOfSicks = new List<string>
            {
            "Анна",
            "Святослав",
            "Марк",
            "Вероника",
            "Матвей",
            "Элина",
            "Таисия",
            "Антон",
            "Арина",
            "Александр",
            "Сафия",
            "Никита",
            "Елизавета",
            "Кира",
            "София",
            "Олег",
            "Марианна",
            "Варвара",
            "Юрий",
            "Георгий"
            };
            string name = namesOfSicks[numberOfName];
            return name;
        }
    }

    class Player
    {
        private string _name;

        public int Level { get; private set; }
        public int Power { get; private set; }

        public Player(string name, int level, int power)
        {
            _name = name;
            Level = level;
            Power = power;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name}. Уровень: {Level}. Сила: {Power}.");
        }
    }
}
