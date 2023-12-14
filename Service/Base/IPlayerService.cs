using System.Collections.Generic;
using laba4oop.Entities;

namespace laba4oop.Service.Base
{
    public interface IPlayerService
    {
        void CreatePlayer(string userName, int initialRating);
        List<PlayerEntity> GetAllPlayers();
        PlayerEntity GetPlayerById(int playerId);
        void UpdatePlayer(PlayerEntity player);
        void DeletePlayer(int playerId);
    }
}