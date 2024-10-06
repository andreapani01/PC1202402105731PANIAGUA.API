using PC1202402105731PANIAGUA.DOMAIN.Core.Entities;
using PC1202402105731PANIAGUA.DOMAIN.Infraestructure.Data;
using PC1202402105731PANIAGUA.DOMAIN.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC1202402105731PANIAGUA.DOMAIN.Core.Interfaces
{
    public class IAttendeesRepository
    {
        Task<IEnumerable<Attendees>> GetAttendees();
        Task<int> Insert(Attendees attendees);
    }
}
