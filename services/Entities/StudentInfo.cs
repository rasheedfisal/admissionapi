using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace admissionapi.services.Entities;
public class StudentInfo: BaseEntity {
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    [MaxLength(100)]
    public string ClassName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Gender { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Religion { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string ImagePath { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string BirthCrt { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string PassportCrt { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? DocOne { get; set; }

    [MaxLength(200)]
    public string? DocTwo { get; set; }

    [Required]
    public Guid AdmId { get; set; }

    [ForeignKey(nameof(AdmId))]
    public Admission? Admission { get; set; }

}