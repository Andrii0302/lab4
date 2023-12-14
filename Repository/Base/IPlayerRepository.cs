using System.Collections.Generic;
using laba4oop.Entities;

namespace laba4oop.Repository.Base
{
    public interface IPlayerRepository
    {
        void Create(PlayerEntity player);
        List<PlayerEntity> ReadAll();
        PlayerEntity ReadById(int playerId);
        void Update(PlayerEntity player);
        void Delete(int playerId); 
    }
}