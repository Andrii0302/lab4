using System.Collections.Generic;
using System.Linq;
using laba4oop.Entities;
using laba4oop.Repository.Base;

namespace laba4oop.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly DbContext.DbContext dataBase;

        public GameRepository(DbContext.DbContext dbContext)
        {
            dataBase = dbContext;
        }

        public void Create(GameEntity game)
        {
            game.Id = dataBase.Games.Count + 1;
            dataBase.Games.Add(game);
        }

        public List<GameEntity> ReadAll()
        {
            return dataBase.Games;
        }

        public GameEntity ReadById(int gameId)
        {
            return dataBase.Games.FirstOrDefault(g => g.Id == gameId);
        }

        public void Update(GameEntity game)
        {
            var existingGame = dataBase.Games.FirstOrDefault(g => g.Id == game.Id);
            if (existingGame != null)
            {
                existingGame.GameRating = game.GameRating;
            }
        }

        public void Delete(int gameId)
        {
            var gameToDelete = dataBase.Games.FirstOrDefault(g => g.Id == gameId);
            if (gameToDelete != null)
            {
                dataBase.Games.Remove(gameToDelete);
            }
        }
    }
}