using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace admissionapi.services.Entities;
public class MotherInfo: BaseEntity {
    [Required]
    [MaxLength(200)]
    public string FullName { get; set; } = string.Empty;

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
    public Guid AdmId { get; set; }

    [ForeignKey(nameof(AdmId))]
    public Admission? Admission { get; set; }

}