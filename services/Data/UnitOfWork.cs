using Microsoft.Extensions.Logging;
using admissionapi.services.IConfiguration;
using admissionapi.services.IRepository;
using admissionapi.services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admissionapi.services.Data;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public IAdmRepository Admission { get; private set; }
        public IGardianRepository Gardian { get; private set; }
        public IFatherRepository Father { get; private set; }
        public IMotherRepository Mother { get; private set; }
        public IMartialRepository Martial { get; private set; }
        public IEmgRepository Emergency { get; private set; }
        public IStdRepository Student { get; private set; }
        private readonly ILogger _logger;
        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("db_logs");

            Admission = new AdmRepository(context, _logger);
            Gardian = new GardianRepository(context, _logger);
            Father = new FatherRepository(context, _logger);
            Mother = new MotherRepository(context, _logger);
            Emergency = new EmgRepository(context, _logger);
            Martial = new MartialRepository(context, _logger);
            Student = new StdRepository(context, _logger);
        }


        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

