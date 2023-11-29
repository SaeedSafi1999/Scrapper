using Core.DTOs;

namespace Core.Interfaces
{
    public interface IJobAndEjucationServices
    {
        Task<JobsAndEgucationsDTO> GetData();
    }
}
