using Frigy.Server.Models.Common.Interfaces;

namespace Frigy.Server.Models.Common.Base;

public abstract class EntityBase : IEntity
{
    public int Id { get; set; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset? Updated { get; set; }
}