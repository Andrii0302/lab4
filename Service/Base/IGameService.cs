using System.Collections.Generic;
using laba4oop.Entities;

namespace laba4oop.Service.Base
{
    public interface IGameService
    {
        void CreateGame(int gameRating);
        List<GameEntity> GetAllGames();
        GameEntity GetGameById(int gameId);
        void UpdateGame(GameEntity game);
        void DeleteGame(int gameId);
    }
}