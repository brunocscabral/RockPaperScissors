using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Business.Interfaces;
using RockPaperScissors.Business.Models;
using RockPaperScissors.Infra.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RockPaperScissors.Infra.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly GameDbContext _gameDbContext;

        public Repository(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        public async Task<List<TEntity>> Get()
        {
            return await _gameDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Get(int Id)
        {
            return await _gameDbContext.Set<TEntity>().FindAsync(Id);
        }

        public async Task Create(TEntity entity)
        {
            _gameDbContext.Set<TEntity>().Add(entity);
            await SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            _gameDbContext.Set<TEntity>().Update(entity);
            await SaveChanges();
        }

        public async Task Delete(int Id)
        {
            _gameDbContext.Set<TEntity>().Remove(await Get(Id));
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _gameDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _gameDbContext?.Dispose();
        }
    }
}
