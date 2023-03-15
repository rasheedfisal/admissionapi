using admissionapi.services.IRepository;

namespace admissionapi.services.IConfiguration;

    public interface IUnitOfWork
    {
        IAdmRepository Admission { get; }
        IGardianRepository Gardian { get; }
        IFatherRepository Father { get; }
        IMotherRepository Mother { get; }
        IMartialRepository Martial { get; }
        IEmgRepository Emergency { get; }
        IStdRepository Student { get; }
        Task CompleteAsync();
    }

