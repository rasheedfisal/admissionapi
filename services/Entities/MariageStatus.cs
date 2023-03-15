using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace admissionapi.services.Entities;
public class MariageStatus: BaseEntity {
    [Required]
    [MaxLength(100)]
    public string MRStatus { get; set; } = string.Empty;

    [Required]
    public Guid AdmId { get; set; }

    [ForeignKey(nameof(AdmId))]
    public Admission? Admission { get; set; }
}