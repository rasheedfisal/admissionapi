using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace admissionapi.services.Entities;
public class EmergencyInfo: BaseEntity {
    [Required]
    [MaxLength(100)]
    public string Relation { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Phone { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public Guid AdmId { get; set; }

    [ForeignKey(nameof(AdmId))]
    public Admission? Admission { get; set; }
}