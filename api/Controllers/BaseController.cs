using admissionapi.services.IConfiguration;
using Microsoft.AspNetCore.Mvc;

namespace admissionapi.api.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class BaseController: ControllerBase
    {
        public IUnitOfWork _unitOfWork;
        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }