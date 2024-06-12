using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Sonawis.Shared.Domain.Entities;
public abstract class AuditableEntity
{
    /// <summary>
    /// The date the record was created.
    /// </summary>
    [JsonIgnore]
    public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// The application id that created the record.
    /// </summary>
    [JsonIgnore]
    public int CreatedApplicationId { get; set; }

    /// <summary>
    /// The last date the record was updated.
    /// </summary>
    [JsonIgnore]
    public DateTime? ModifiedOnUtc { get; set; }

    /// <summary>
    /// The application that last updated the record.
    /// </summary>
    [JsonIgnore]
    public int? LastUpdatedApplicationId { get; set; }

    /// <summary>
    /// The logical delete field.
    /// </summary>
    [JsonIgnore]
    [DefaultValue(false)]
    public bool Deleted { get; set; }

    /// <summary>
    /// The application that deleted the record.
    /// </summary>
    [JsonIgnore]
    public int? DeletedApplicationId { get; set; }

    /// <summary>
    /// The date when the record was delted.
    /// </summary>
    [JsonIgnore]
    public DateTime? DeletedOnUtc { get; set; }
}
