using Core.DTOs;

namespace Core.Interfaces
{
    public interface IJobAndEjucationServices
    {
        Task<JobsAndEgucationsDTO> GetData(float lat1, float lon1, float lat2, float lon2);
    }
}
