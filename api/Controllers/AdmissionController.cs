using admissionapi.api.Dtos.Requests;
using admissionapi.api.Dtos.Responses;
using admissionapi.api.Services;
using admissionapi.services.Entities;
using admissionapi.services.IConfiguration;
using Microsoft.AspNetCore.Mvc;

namespace admissionapi.api.Controllers;

public class AdmissionController : BaseController
{
     private readonly IImageProcessor _imageProcessor;
    private readonly IUriService _uriService;
    public AdmissionController(IUnitOfWork unitOfWork, IImageProcessor imageProcessor, IUriService uriService) : base(unitOfWork)
    {
        _imageProcessor = imageProcessor;
        _uriService = uriService;
    }

    [HttpPost]
    // [RequestSizeLimit(bytes: 5_000_000)]
    [Route("Add")]
    public async Task<IActionResult> Add([FromForm] AdmissionRequest adm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ErrorsDto
            {
                Errors = new List<string>()
                {
                    "fill in required fields"
                }
            });
        }

        var add_Adm = await _unitOfWork.Admission.AddAsync(new Admission());
        var AddG = await _unitOfWork.Gardian.AddAsync(new GardianInfo
        {
            Title = adm.g_title,
            FirstName = adm.g_firstName,
            SecondName = adm.g_secondName,
            MiddleName = adm.g_middleName,
            Surname = adm.g_surname,
            Email = adm.g_email,
            PhoneOne = adm.g_phone1,
            PhoneTwo = adm.g_phone2,
            Address = adm.g_address,
            Location = adm.g_location,
            AdmId = add_Adm!.Id,
        }); 
            var AddEmg = await _unitOfWork.Emergency.AddAsync(new EmergencyInfo
        {
            Relation = adm.e_relation,
            Phone = adm.e_contact,
            Email = adm.e_email,
            AdmId = add_Adm!.Id,
        }); 

        var AddMr = await _unitOfWork.Martial.AddAsync(new MariageStatus
        {
            MRStatus = adm.mr_status,
            AdmId = add_Adm!.Id,
        });

            var AddFa = await _unitOfWork.Father.AddAsync(new FatherInfo
        {
            FirstName = adm.f_firstName,
            SecondName = adm.f_secondName,
            MiddleName = adm.f_middleName,
            Surname = adm.f_surname,
            Email = adm.f_email,
            PhoneOne = adm.f_phone1,
            PhoneTwo = adm.f_phone2,
            Address = adm.f_address,
            AdmId = add_Adm!.Id,
        });  

        var AddMa = await _unitOfWork.Mother.AddAsync(new MotherInfo
        {
            FullName = adm.m_fullname,
            Email = adm.m_email,
            PhoneOne = adm.m_phone1,
            PhoneTwo = adm.m_phone2,
            Address = adm.m_address,
            AdmId = add_Adm!.Id,
        });  

        foreach (var std in adm.s_info)
        {
            await _unitOfWork.Student.AddAsync(new StudentInfo
            {
                Name = std.name,
                BirthDate = std.birthDate,
                ClassName = std.className,
                Gender = std.gender,
                Religion = std.religion,
                ImagePath = await _imageProcessor.SaveAllFormatAsync(std.img),
                BirthCrt = await _imageProcessor.SaveAllFormatAsync(std.birthCrt),
                PassportCrt = await _imageProcessor.SaveAllFormatAsync(std.passportCrt),
                DocOne = await _imageProcessor.SaveAllFormatAsync(std.docOneCrt),
                DocTwo = await _imageProcessor.SaveAllFormatAsync(std.docTwoCrt),
                AdmId = add_Adm!.Id,
            });  
        }


        if (add_Adm is null || AddG is null || AddEmg is null || AddMr is null || AddFa is null || AddMa is null)
        {
            return BadRequest(new ErrorsDto
            {
                Errors = new List<string>()
                {
                    "Error Processing Request"
                }
            });
        }
        await _unitOfWork.CompleteAsync();

        return Ok();
    }

    [HttpPut]
    [RequestSizeLimit(bytes: 5_000_000)]
    [Route("Update")]
    public async Task<IActionResult> Update([FromForm] AdmissionUpdateRequest adm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ErrorsDto
            {
                Errors = new List<string>()
                {
                    "fill in required fields"
                }
            });
        }
        foreach (var fi in adm.s_info)
        {
            if (fi.std_id != "new")
            {
                var GetExistingLogo = await _unitOfWork.Student.GetAsync(Guid.Parse(fi.std_id));
            if (fi.img is not null)
            {
                
                if (GetExistingLogo?.ImagePath is not null)
                {
                    await _imageProcessor.RemoveImageAsync(GetExistingLogo.ImagePath);
                }
            }
            if (fi.birthCrt is not null)
            {
                if (GetExistingLogo?.BirthCrt is not null)
                {
                    await _imageProcessor.RemoveImageAsync(GetExistingLogo.BirthCrt);
                }
            }
             if (fi.passportCrt is not null)
            {
                if (GetExistingLogo?.PassportCrt is not null)
                {
                    await _imageProcessor.RemoveImageAsync(GetExistingLogo.PassportCrt);
                }
            }
            if (fi.docOneCrt is not null)
            {
                if (GetExistingLogo?.DocOne is not null)
                {
                    await _imageProcessor.RemoveImageAsync(GetExistingLogo.DocOne);
                }
            }
             if (fi.docTwoCrt is not null)
            {
                if (GetExistingLogo?.DocTwo is not null)
                {
                    await _imageProcessor.RemoveImageAsync(GetExistingLogo.DocTwo);
                }
            }
            }
            
        }
         

        var AddG = await _unitOfWork.Gardian.UpdateAsync(new GardianInfo
        {
            Id = adm.g_id,
            FirstName = adm.g_firstName,
            SecondName = adm.g_secondName,
            MiddleName = adm.g_middleName,
            Surname = adm.g_surname,
            Email = adm.g_email,
            PhoneOne = adm.g_phone1,
            PhoneTwo = adm.g_phone2,
            Address = adm.g_address,
            Location = adm.g_location
        }, adm.g_id); 
            var AddEmg = await _unitOfWork.Emergency.UpdateAsync(new EmergencyInfo
        {
            Id = adm.e_id,
            Relation = adm.e_relation,
            Phone = adm.e_contact,
            Email = adm.e_email,
        }, adm.e_id); 

        var AddMr = await _unitOfWork.Martial.UpdateAsync(new MariageStatus
        {
            Id = adm.mr_id,
            MRStatus = adm.mr_status,
        }, adm.mr_id);

            var AddFa = await _unitOfWork.Father.UpdateAsync(new FatherInfo
        {
            Id = adm.f_id,
            FirstName = adm.f_firstName,
            SecondName = adm.f_secondName,
            MiddleName = adm.f_middleName,
            Surname = adm.f_surname,
            Email = adm.f_email,
            PhoneOne = adm.f_phone1,
            PhoneTwo = adm.f_phone2,
            Address = adm.f_address,
        }, adm.f_id);  

        var AddMa = await _unitOfWork.Mother.UpdateAsync(new MotherInfo
        {
            Id = adm.m_id,
            FullName = adm.m_fullname,
            Email = adm.m_email,
            PhoneOne = adm.m_phone1,
            PhoneTwo = adm.m_phone2,
            Address = adm.m_address,
        }, adm.m_id);  

        foreach (var std in adm.s_info)
        {
            if (std.std_id.StartsWith("new"))
            {
                await _unitOfWork.Student.AddAsync(new StudentInfo
                {
                    Name = std.name,
                    BirthDate = std.birthDate,
                    ClassName = std.className,
                    Gender = std.gender,
                    Religion = std.religion,
                    ImagePath = await _imageProcessor.SaveAllFormatAsync(std.img),
                    BirthCrt = await _imageProcessor.SaveAllFormatAsync(std.birthCrt),
                    PassportCrt = await _imageProcessor.SaveAllFormatAsync(std.passportCrt),
                    DocOne = await _imageProcessor.SaveAllFormatAsync(std.docOneCrt),
                    DocTwo = await _imageProcessor.SaveAllFormatAsync(std.docTwoCrt),
                    AdmId = adm.adm_id,
                });  
            } else
            {
                await _unitOfWork.Student.UpdateAsync(new StudentInfo
                {
                    Id = Guid.Parse(std.std_id),
                    Name = std.name,
                    BirthDate = std.birthDate,
                    ClassName = std.className,
                    Gender = std.gender,
                    Religion = std.religion,
                    ImagePath = std.img is not null ? await _imageProcessor.SaveAllFormatAsync(std.img) : null,
                    BirthCrt = std.birthCrt is not null ? await _imageProcessor.SaveAllFormatAsync(std.birthCrt) : null,
                    PassportCrt = std.passportCrt is not null ? await _imageProcessor.SaveAllFormatAsync(std.passportCrt) : null,
                    DocOne = std.docOneCrt is not null ? await _imageProcessor.SaveAllFormatAsync(std.docOneCrt) : null,
                    DocTwo = std.docTwoCrt is not null ? await _imageProcessor.SaveAllFormatAsync(std.docTwoCrt) : null,
                }, Guid.Parse(std.std_id));//brandDto.Logo is not null ? await _imageProcessor.SaveAllFormatAsync(brandDto.Logo) : null,
            }
        }


        if (AddG is null || AddEmg is null || AddMr is null || AddFa is null || AddMa is null)
        {
            return BadRequest(new ErrorsDto
            {
                Errors = new List<string>()
                {
                    "Error Processing Request"
                }
            });
        }
        await _unitOfWork.CompleteAsync();

        return Ok();
    }

    [HttpGet]
    [Route("GetAdmission", Name = "GetAdmission")]
    public async Task<IActionResult> GetAdmission([FromQuery] string ph)
    {
        try
        {
            string phone = ph.Replace(" ", "+");
            var result = await _unitOfWork.Admission.GetAdmissionByPhone(phone);

            if (result is null) return NotFound("Item Not Found");

            return Ok(new AdmissionResponse
            {
             adm_id = result.Id,
             admIndex = result.AdmissionIndex,
             AdmDate =  result.AddedDate,
             gphone_isFound = true,
             gphone_num = result.Gardian.PhoneOne,
             g_id = result.Gardian.Id,
             g_title = result.Gardian.Title, 
             g_fullname = $"{result.Gardian.FirstName} {result.Gardian.SecondName} {result.Gardian.MiddleName} {result.Gardian.Surname}",
             g_firstName = result.Gardian.FirstName,
             g_secondName = result.Gardian.SecondName,
             g_middleName = result.Gardian.MiddleName,
             g_surname = result.Gardian.Surname,
             g_email = result.Gardian.Email,
             g_phone1 = result.Gardian.PhoneOne,
             g_phone2 = result.Gardian.PhoneTwo,
             g_address = result.Gardian.Address,
             g_location = result.Gardian.Location,
             e_id = result.Emergency.Id,
             e_relation = result.Emergency.Relation,
             e_contact = result.Emergency.Phone,
             e_email = result.Emergency.Email,
             mr_id = result.Martial.Id,
             mr_status = result.Martial.MRStatus,
             f_id = result.Father.Id,
             f_fullname = $"{result.Father.FirstName} {result.Father.SecondName} {result.Father.MiddleName} {result.Father.Surname}",
             f_firstName = result.Father.FirstName, 
             f_secondName = result.Father.SecondName, 
             f_middleName = result.Father.MiddleName, 
             f_surname = result.Father.Surname, 
             f_email = result.Father.Email, 
             f_phone1 = result.Father.PhoneOne, 
             f_phone2 = result.Father.PhoneTwo, 
             f_address = result.Father.Address, 
             m_id = result.Mother.Id, 
             m_fullname = result.Mother.FullName, 
             m_email = result.Mother.Email,
             m_phone1 = result.Mother.PhoneOne, 
             m_phone2 = result.Mother.PhoneTwo, 
             m_address = result.Mother.Address,
             s_info = result.Students.Select(x => new StdResponse {
                std_id = x.Id.ToString(),
                name = x.Name,
                birthDate = x.BirthDate,
                className = x.ClassName,
                gender = x.Gender,
                religion = x.Religion,
                imgPath = string.IsNullOrEmpty(x.ImagePath) ? null : $"{_uriService.GetBaseRoot()}/{x.ImagePath!.Replace("\\", "/")}"!,
                birthCrtPath = string.IsNullOrEmpty(x.BirthCrt) ? null : $"{_uriService.GetBaseRoot()}/{x.BirthCrt!.Replace("\\", "/")}"!,
                passportCrtPath = string.IsNullOrEmpty(x.PassportCrt) ? null : $"{_uriService.GetBaseRoot()}/{x.PassportCrt!.Replace("\\", "/")}"!,
                docOneCrtPath = string.IsNullOrEmpty(x.DocOne) ? null : $"{_uriService.GetBaseRoot()}/{x.DocOne!.Replace("\\", "/")}"!,
                docTwoCrtPath = string.IsNullOrEmpty(x.DocTwo) ? null : $"{_uriService.GetBaseRoot()}/{x.DocTwo!.Replace("\\", "/")}"!,
             }).ToList()
            });
        }
        catch(Exception ex)
        {
            return BadRequest(new ErrorsDto
            {
                Success = false,
                Errors = new List<string>()
                {
                    ex.Message
                }
            });
        }
    }
    [HttpDelete]
    [Route("DeleteStd")]
    public async Task<IActionResult> DeleteStd([FromQuery] Guid stdid)
    {
        try
        {
            await _unitOfWork.Student.DeleteAsync(stdid);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
        catch (System.Exception ex)
        {
            return BadRequest(new ErrorsDto
            {
                Success = false,
                Errors = new List<string>()
                {
                    ex.Message
                }
            });
        }
    }
}