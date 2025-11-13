using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ConfigurationService.Models;
public class HealthCheck
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CheckId { get; set; }
    public int ServiceId { get; set; }
    public bool IsUp { get; set; }
    public int StatusCode { get; set; }
    public int ResponseTimeMs { get; set; }
    public DateTime CheckedAt { get; set; } = DateTime.UtcNow;
    public Service ?Service { get; set; }

}