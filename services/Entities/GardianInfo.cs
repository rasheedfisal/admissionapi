using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace admissionapi.services.Entities;
public class GardianInfo: BaseEntity {
    [Required]
    [MaxLength(10)]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string SecondName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string MiddleName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Surname { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string PhoneOne { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? PhoneTwo { get; set; }

    [Required]
    [MaxLength(100)]
    public string Address { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Location { get; set; } = string.Empty;

    [Required]
    public Guid AdmId { get; set; }

    [ForeignKey(nameof(AdmId))]
    public Admission? Admission { get; set; }

}