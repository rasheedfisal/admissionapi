

using System.ComponentModel.DataAnnotations;

namespace admissionapi.api.Dtos.Requests;

public class AdmissionRequest
{
    [Required]
    public string g_title { get; set; } = string.Empty;
    [Required]
    public string g_firstName { get; set; } = string.Empty;

    [Required]
    public string g_secondName { get; set; } = string.Empty;

    [Required]
    public string g_middleName { get; set; } = string.Empty;

    [Required]
    public string g_surname { get; set; } = string.Empty;

    [Required]
    public string g_email { get; set; } = string.Empty;

    [Required]
    public string g_phone1 { get; set; } = string.Empty;

    public string? g_phone2 { get; set; }

    [Required]
    public string g_address { get; set; } = string.Empty;

    [Required]
    public string g_location { get; set; } = string.Empty;

    [Required]
    public string e_relation { get; set; } = string.Empty;

    [Required]
    public string e_contact { get; set; } = string.Empty;

    [Required]
    public string e_email { get; set; } = string.Empty;

    [Required]
    public string mr_status { get; set; } = string.Empty;

    [Required]
    public string f_firstName { get; set; } = string.Empty;

    [Required]
    public string f_secondName { get; set; } = string.Empty;

    [Required]
    public string f_middleName { get; set; } = string.Empty;

    [Required]
    public string f_surname { get; set; } = string.Empty;

    [Required]
    public string f_email { get; set; } = string.Empty;

    [Required]
    public string f_phone1 { get; set; } = string.Empty;

    public string? f_phone2 { get; set; }

    [Required]
    public string f_address { get; set; } = string.Empty;

    [Required]
    public string m_fullname { get; set; } = string.Empty;

    [Required]
    public string m_email { get; set; } = string.Empty;

    [Required]
    public string m_phone1 { get; set; } = string.Empty;

    public string? m_phone2 { get; set; }

     [Required]
    public string m_address { get; set; } = string.Empty;

    [Required]
    public List<StdRequest> s_info { get; set; }


}