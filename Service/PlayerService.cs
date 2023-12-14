using System.Collections.Generic;
using laba4oop.Repository.Base;
using laba4oop.Entities;
using laba4oop.Service.Base;

namespace laba4oop.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void CreatePlayer(string userName, int initialRating)
        {
            var player = new PlayerEntity { UserName = userName, CurrentRating = initialRating, GamesCount = 0 };
            _playerRepository.Create(player);
        }

        public List<PlayerEntity> GetAllPlayers()
        {
            return _playerRepository.ReadAll();
        }

        public PlayerEntity GetPlayerById(int playerId)
        {
            return _playerRepository.ReadById(playerId);
        }

        public void UpdatePlayer(PlayerEntity player)
        {
            _playerRepository.Update(player);
        }

        public void DeletePlayer(int playerId)
        {
            _playerRepository.Delete(playerId);
        }
    }
}