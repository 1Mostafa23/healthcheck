using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
namespace ConfigurationService.Models;
public class Service
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ServiceId { get; set; }

    [Required]
    [MaxLength(255)]
    public string ?Name { get; set; } 

    [Required]
    [MaxLength(2048)]
    public string ?Url { get; set; }
    public int CheckIntervalSeconds { get; set; } = 300;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<HealthCheck> HealthChecks { get; set; } = new List<HealthCheck>();
    
}