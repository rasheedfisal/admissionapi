using System.ComponentModel.DataAnnotations;

namespace admissionapi.api.Dtos.Requests;

public class StdUpdateRequest
{
    [Required]
    public string std_id { get; set; } = string.Empty;
    [Required]
    public string name { get; set; } = string.Empty;

    [Required]
    public DateTime birthDate { get; set; }

    [Required]
    public string className { get; set; } = string.Empty;

    [Required]
    public string religion { get; set; } = string.Empty;

    [Required]
    public string gender { get; set; } = string.Empty;

    
    public IFormFile? img { get; set; }

    
    public IFormFile? birthCrt { get; set; }

    
    public IFormFile? passportCrt { get; set; }

   
    public IFormFile? docOneCrt { get; set; }

    
    public IFormFile? docTwoCrt { get; set; }
}