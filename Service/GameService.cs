using System.Collections.Generic;
using laba4oop.Repository.Base;
using laba4oop.Entities;
using laba4oop.Service.Base;

namespace laba4oop.Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void CreateGame(int gameRating)
        {
            var game = new GameEntity { GameRating = gameRating };
            _gameRepository.Create(game);
        }

        public List<GameEntity> GetAllGames()
        {
            return _gameRepository.ReadAll();
        }

        public GameEntity GetGameById(int gameId)
        {
            return _gameRepository.ReadById(gameId);
        }

        public void UpdateGame(GameEntity game)
        {
            _gameRepository.Update(game);
        }

        public void DeleteGame(int gameId)
        {
            _gameRepository.Delete(gameId);
        }
    }
}