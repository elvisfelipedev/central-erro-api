using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CentralErros.Business.Interfaces.Repositories;
using CentralErros.Business.Models;
using CentralErros.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CentralErros.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly Contexto Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(Contexto db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            var entidade = await ObterPorId(id);
            DbSet.Remove(entidade);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
