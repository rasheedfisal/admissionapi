using System.ComponentModel.DataAnnotations;

namespace admissionapi.api.Dtos.Responses;

public class StdResponse
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

    [Required]
    public string imgPath { get; set; } = string.Empty;

    [Required]
    public string birthCrtPath { get; set; } = string.Empty;

    [Required]
    public string passportCrtPath { get; set; } = string.Empty;

    public string? docOneCrtPath { get; set; }

    public string? docTwoCrtPath { get; set; }
}