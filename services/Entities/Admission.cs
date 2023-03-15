using System.ComponentModel.DataAnnotations;


namespace admissionapi.services.Entities;
public class Admission: BaseEntity {
    [Required]
    [MaxLength(20)]
    // public string AdmissionIndex { get {return AdmissionIndex;}
    // set {
    //     value = $"ADM-{Id.ToString().Substring(0,5)}-{AddedDate.Year}{AddedDate.Hour}{AddedDate.Second}";
    // } }
    public string AdmissionIndex { get; set; } = $"ADM-{Guid.NewGuid().ToString().Substring(0,5)}{DateTime.Now.Year}{DateTime.Now.Hour}{DateTime.Now.Second}";

    public virtual GardianInfo Gardian { get; set; }
    public virtual EmergencyInfo Emergency { get; set; }
    public virtual MariageStatus Martial { get; set; }
    public virtual FatherInfo Father { get; set; }
    public virtual MotherInfo Mother { get; set; }
    public virtual ICollection<StudentInfo> Students { get; set; }
}