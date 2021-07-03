using ATM_CORE.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_CORE.Repository.Implements
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Data.EntityContext entityContext;
        public Repository(Data.EntityContext entityContext)
        {
            this.entityContext = entityContext;

        }
        public TEntity Create(TEntity t)
        {
            try
            {
                entityContext.Set<TEntity>().Add(t);
                entityContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public int Delete(int id)
        {
            int respuesta = 0;
            try
            {
                TEntity TEntity = entityContext.Set<TEntity>().Find(id);
                entityContext.Set<TEntity>().Remove(TEntity);
                entityContext.SaveChanges();
                respuesta = 1;
            }
            catch (Exception ex)
            {
                throw ex;
             }
             return respuesta;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

       

        public int Update(TEntity t)
        {
            int respuesta = 0;
            try
            {
                entityContext.Set<TEntity>().Update(t);
                entityContext.SaveChanges();
                respuesta = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

         async Task<TEntity> IRepository<TEntity>.Find(int id)
        {
            TEntity TEntity = null;
            try
            {

                TEntity = await entityContext.Set<TEntity>().FindAsync(id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TEntity;
        }
    }
}
