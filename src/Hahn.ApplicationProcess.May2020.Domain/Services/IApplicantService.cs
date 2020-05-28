using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.May2020.Domain.Services
{
    public interface IApplicantService<T>
    {
        Task<T> Create(T applicant);

        Task<T> Update(T applicant);

        T Get(int id);

        Task<bool> Delete(int id);
    }
}