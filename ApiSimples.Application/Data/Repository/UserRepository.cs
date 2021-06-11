using ApiSimples.Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiSimples.Application.Data.Repository
{
    public class UserRepository
    {
        protected readonly Context Context;
        private DbSet<User> Dataset;

        public UserRepository(Context context)
        {
            Context = context;
            Dataset = Context.Set<User>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await Dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                {
                    return false;
                }

                Dataset.Remove(result);
                await Context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await Dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<User> InsertAsync(User item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                Dataset.Add(item);

                await Context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<User> SelectAsync(Guid id)
        {
            try
            {
                return await Dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<User>> SelectAsync()
        {
            try
            {
                return await Dataset.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> UpdateAsync(User item)
        {
            try
            {
                var result = await Dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if (result == null)
                {
                    return null;
                }

                Context.Entry(result).CurrentValues.SetValues(item);
                await Context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}
