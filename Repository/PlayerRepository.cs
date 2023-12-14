using System.Collections.Generic;
using System.Linq;
using laba4oop.Entities;
using laba4oop.Repository.Base;

namespace laba4oop.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private DbContext.DbContext dataBase;

        public PlayerRepository(DbContext.DbContext dbContext)
        {
            dataBase = dbContext;
        }

        public void Create(PlayerEntity player)
        {
            player.Id = dataBase.Players.Count + 1;
            player.UserName = "Player" + (dataBase.Players.Count + 1);
            dataBase.Players.Add(player);
        }

        public List<PlayerEntity> ReadAll()
        {
            return dataBase.Players;
        }

        public PlayerEntity ReadById(int playerId)
        {
            return dataBase.Players.FirstOrDefault(p => p.Id == playerId);
        }

        public void Update(PlayerEntity player)
        {
            var existingPlayer = dataBase.Players.FirstOrDefault(p => p.Id == player.Id);
            if (existingPlayer != null)
            {
                existingPlayer.UserName = player.UserName;
                existingPlayer.CurrentRating = player.CurrentRating;
                existingPlayer.GamesCount = player.GamesCount;
            }
        }

        public void Delete(int playerId)
        {
            var playerToDelete = dataBase.Players.FirstOrDefault(p => p.Id == playerId);
            if (playerToDelete != null)
            {
                dataBase.Players.Remove(playerToDelete);
            }
        }
    }
}