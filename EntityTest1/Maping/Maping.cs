using EntityTest1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test1;
using Test1Context.DTO;

namespace People.EntityTest1.Maping
{
    public static class Maping
    {
        public static GameDTO map(Game game)
        {
            return new GameDTO()
            {
                Name = game.Name,
            };
        }
        public static Game map(GameDTO game, bool getreference)
        {
            List<User> users;
            if (getreference)
            {
                users = (game.Users).Select(u => map(u, false)).ToList();
            }
            else
            {
                users = game.Users.Select(u => new User() { Id = u.Id }).ToList();
            }
            return new Game()
            {
                Id = game.Id,
                Name = game.Name,
                Users = users
            };
        }
        public static TeamDTO map(Team game)
        {
            return new TeamDTO()
            {
                Name = game.Name,
                GameId = game.Game.Id
            };
        }
        public static Team map(TeamDTO team, bool getreference)
        {
            List<User> users;
            if (getreference)
            {
                users = (team.Users).Select(u => map(u, false)).ToList();
            }
            else
            {
                users = team.Users.Select(u => new User() { Id = u.Id }).ToList();
            }
            return new Team()
            {
                Id = team.Id,
                Name = team.Name,
                Users = users
            };
        }
        public static UserDTO map(User user)
        {
            return new UserDTO()
            {
                Name = user.Name,
                Games = user.Games.Select(map).ToList()
            };
        }
        public static User map(UserDTO user, bool getreference)
        {
            List<Game> games;
            List<Team> teams;
            if (getreference)
            {
                games = user.Games.Select(u => map(u, false)).ToList();
                teams = user.Teams.Select(u => map(u, false)).ToList();
            }
            else
            {
                games = user.Games.Select(u => new Game() { Id = u.Id }).ToList();
                teams = user.Teams.Select(u => new Team() { Id = u.Id }).ToList();
            }
            return new User()
            {
                Id = user.Id,
                Name = user.Name,
                Games = games,
                Teams = teams
            };
        }

        public static GamesLibraryDTO map(GamesLibrary gamesLibrary)
        {
            return new GamesLibraryDTO()
            {
                GameId = gamesLibrary.Game.Id,
                UserId = gamesLibrary.User.Id,
            };
        }
        public static GamesLibrary map(GamesLibraryDTO gamesLibrary,bool getRefetence)
        {
            User user;
            Game game;

            if(getRefetence)
            {
                user = map(gamesLibrary.User, false);
                game = map(gamesLibrary.Game, false);

            }
            else
            {
                user = new User() { Id = gamesLibrary.User.Id, };
                game = new Game() { Id = gamesLibrary.Game.Id, };
            }
            return new GamesLibrary()
            {
                Id = gamesLibrary.Id,

                User = user,
                Game = game
            };
        }
    }
}
