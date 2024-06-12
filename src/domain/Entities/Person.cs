using Sonawis.Shared.Domain.ValueObjects;

namespace Sonawis.Shared.Domain.Entities;

/// <summary>
/// A base class for person type data
/// </summary>
public class Person : Entity
{
    public Person(
        int id,
        FirstName firstName,
        MiddleName middleName,
        LastName lastName,
        DateTime birthDate,
        Email email) : base(id)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        BirthDate = birthDate;
        Email = email;
    }

    /// <summary>
    /// The person's first name.
    /// </summary>    
    public FirstName FirstName { get; init; }

    /// <summary>
    /// The person's middle name
    /// </summary>    
    public MiddleName MiddleName { get; init; }

    /// <summary>
    /// The person's last name.
    /// </summary>
    public LastName LastName { get; init; }

    /// <summary>
    /// The person's date of birth.
    /// </summary>    
    public DateTime BirthDate { get; set; }

    ///// <summary>
    ///// The person's gender at birth (Use: 1 for Male, 2 for Female, 3 Other).
    ///// </summary>
    //public int SexTypeId { get; init; }
    //public virtual SexType SexType { get; init; }

    /// <summary>
    /// The person's email address.
    /// </summary>
    public Email Email { get; init; }
}
