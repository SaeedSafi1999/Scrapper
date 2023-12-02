using Core.DTOs;
using Core.Interfaces;
using Infrestructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Services.ApplicationServices
{
    public class JobAndEjucationServices : IJobAndEjucationServices
    {
        private readonly AppDataContext _db;

        public JobAndEjucationServices(AppDataContext db)
        {
            _db = db;
        }

        public async Task<JobsAndEgucationsDTO> GetData(float lat1, float lon1, float lat2, float lon2)
        {
            var Jobs = await _db.Jobs.Where(x => x.lat >= lat1 && x.Lang <= lon1 && x.Lang <= lon2 && x.lat >= lat2).ToListAsync();
            var ejucations = await _db.Ejucations.Where(x => x.lat >= lat1 && x.lang <= lon1 && x.lang <= lon2 && x.lat >= lat2).ToListAsync();
            return new JobsAndEgucationsDTO
            {
                Ejucations = ejucations,
                Jobs = Jobs
            };
        }
    }
}
