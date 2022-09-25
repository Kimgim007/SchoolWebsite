using EntityTest1.Entity;
using EntityTest1.Service;
using System;

namespace Test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.Добавить пользователя");
            Console.WriteLine("2.Добавить команду");
            Console.WriteLine("3.Добавить игру");
        
            Console.WriteLine();
            Console.WriteLine("4.Показать всех пользователей");
            Console.WriteLine("5.Показать все команды");
            Console.WriteLine("6.Показать все игры");
            Console.WriteLine();
            Console.WriteLine("7 Добавить игру в библиотеку пользователя");
            Console.WriteLine("8 Просматреть библиотеку какого нибудь пользователя");
            GameService gameService = new GameService();
            TeamService teamService = new TeamService();
            UserService userService = new UserService();
            GamesLibraryService gamesLibraryService = new GamesLibraryService();
            string answer = Console.ReadLine();
            switch (answer)

            {
                case "1":
                    {
                        Console.WriteLine("Как вы хотите назвать пользователя ?");
                        string name = Console.ReadLine();
                        var user = new User(name);
                        user.Games.Add(gameService.Get(1));
                        userService.Add(user);

                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Как вы хотите назвать команду ?");
                        string name = Console.ReadLine();
                        Console.WriteLine("По какой игре будет команда");
                        Console.WriteLine(string.Join('\n',gameService.GetAll()));
                        int num = Int32.Parse(Console.ReadLine());
                        Game game = gameService.Get(num);
                        teamService.Add(new Team(name, game));                     
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Как вы хотите назвать игру ?");
                        string name = Console.ReadLine();                       
                        gameService.Add(new Game(name));
                        break;
                    }

                case "4":
                    {
                        var users = userService.GetAll();
                        Console.WriteLine(string.Join('\n',users));
                        break;
                    }
                case "5":
                    {
                        Console.WriteLine(string.Join('\n',teamService.GetAll()));
                        break;
                    }
                case "6":
                    {
                        var game = gameService.GetAll();
                        Console.WriteLine(string.Join('\n', game));

                        break;
                    }
                case "7":
                    {
                        Console.WriteLine("Какому пользователю хотите добавить игру");

                        Console.WriteLine(string.Join('\n',userService.GetAll()));
                        int num  = Int32.Parse(Console.ReadLine());
                        User user = userService.Get(num);

                        Console.WriteLine("Какую игру вы хотите добавить");
                        Console.WriteLine(string.Join('\n',gameService.GetAll()));
                        int num2 = Int32.Parse(Console.ReadLine());
                        Game game = gameService.Get(num2);

                        gamesLibraryService.Add(new GamesLibrary(game, user));
                        break;
                    }
                case "8":
                    {
                        Console.WriteLine("Игры какого пользователя вы хотите увидеть ");
                        Console.WriteLine(string.Join('\n', userService.GetAll()));
                        int num = Int32.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine(string.Join('\n',gamesLibraryService.GetAll(num)));
                        break;
                    }

            }
        }
    }
}
