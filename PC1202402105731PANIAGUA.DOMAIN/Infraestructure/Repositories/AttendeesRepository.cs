using Microsoft.EntityFrameworkCore;
using PC1202402105731PANIAGUA.DOMAIN.Core.Entities;
using PC1202402105731PANIAGUA.DOMAIN.Core.Interfaces;
using PC1202402105731PANIAGUA.DOMAIN.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC1202402105731PANIAGUA.DOMAIN.Infraestructure.Repositories
{
        public class AttendeesRepository : IAttendeesRepository
        {
        private readonly EventManagementDbContext _dbContext;

        public AttendeesRepository(EventManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Attendees>> GetAttendes()
        {

            var attendes = await _dbContext.Attendees.ToListAsync();
            return attendes;
        }

        public async Task<int> Insert(Attendees attendees)
        {
            await _dbContext.Attendees.AddAsync(attendees);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0 ? attendees.Id : -1;

        }

    }
}
