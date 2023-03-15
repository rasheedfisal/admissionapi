using admissionapi.services.Entities;

namespace admissionapi.services.IRepository;

public interface IAdmRepository: IGenericRepository<Admission>
{
    Task<Admission?> GetAdmissionByPhone(string key);
}