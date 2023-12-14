using laba4oop.Entities;
using System.Collections.Generic;

namespace laba4oop.DbContext
{ 
    public class DbContext
    {
        public List<PlayerEntity> Players { get; set; }
        public List<GameEntity> Games { get; set; }

        public DbContext()
        {
            Players = new List<PlayerEntity>();
            Games = new List<GameEntity>();

            Players.Add(new PlayerEntity { Id = 1, UserName = "Player1", CurrentRating = 10, GamesCount = 0 });
            Players.Add(new PlayerEntity { Id = 2, UserName = "Player2", CurrentRating = 10, GamesCount = 0 });
        }
    }
}