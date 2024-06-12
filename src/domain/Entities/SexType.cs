using System.ComponentModel.DataAnnotations.Schema;

namespace Sonawis.Shared.Domain.Entities;
public class SexType : Enumeration<SexType>
{
    public static readonly SexType Male = new(1, nameof(Male));

    public static readonly SexType Female = new(2, nameof(Female));

    public static readonly SexType Other = new(3, nameof(Other));
    public SexType(int id, string name)
        : base(id, name)
    {

    }
}
