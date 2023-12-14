using System.Collections.Generic;
using laba4oop.Entities;


namespace laba4oop.Repository.Base
{
    public interface IGameRepository
    {
        void Create(GameEntity game);
        List<GameEntity> ReadAll();
        GameEntity ReadById(int gameId);
        void Update(GameEntity game);
        void Delete(int gameId);
    }
}