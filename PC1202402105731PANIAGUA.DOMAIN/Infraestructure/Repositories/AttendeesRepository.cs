using Microsoft.EntityFrameworkCore;
using PC1202402105731PANIAGUA.DOMAIN.Core.Entities;
using PC1202402105731PANIAGUA.DOMAIN.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC1202402105731PANIAGUA.DOMAIN.Infraestructure.Repositories
{
    internal class AttendeesRepository 
    {
        private readonly EventManagementDbContext _dbcontext;

        
        public AttendeesRepository (EventManagementDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        //Sincrona
        public IEnumerable<Attendees> GetCategoriesSync()
        {
            var categories = _dbcontext.Attendees.ToList();
            return categories;
        }

        //Asincrona
        public async Task<IEnumerable<Attendees>> GetCategories()
        {
            var categories = await _dbcontext.Attendees.ToListAsync();
            return categories;
        }

        public async Task<Attendees> GetCategoryById(int id)
        {
            var category = await _dbcontext
                            .Attendees
                            .Where(c => c.Id == id)
                            .FirstOrDefaultAsync();
            return category;
        }

        public async Task<int> Insert(Attendees category)
        {
            category.IsActive = true;
            await _dbcontext.Attendees.AddAsync(category);
            int rows = await _dbcontext.SaveChangesAsync();
            return rows > 0 ? category.Id : -1;
        }

        public async Task<bool> Update(Attendees category)
        {
            _dbcontext.Attendees.Update(category);
            int rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            //var category = _dbContext.Category.Find(id);
            var category = await GetCategoryById(id);
            if (category == null)
                return false;

            //_dbContext.Category.Remove(category);
            //int rows= await _dbContext.SaveChangesAsync();

            //eliminacion logica:
            category.IsActive = false;
            int rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;

        }

    }
}
