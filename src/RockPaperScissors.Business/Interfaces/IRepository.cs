using RockPaperScissors.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RockPaperScissors.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<List<TEntity>> Get();
        Task<TEntity> Get(int Id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int Id);
        Task<int> SaveChanges();
    }
}
