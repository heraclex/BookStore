using System.Collections.Generic;

namespace Ojb.Framework.Domain.Interfaces
{
    using System.Reflection;

    /// <summary>
    ///     This serves as a base interface for <see cref="Entity.EntityWithTypedId{TId}" /> and 
    ///     <see cref = "Entity" />. Also provides a simple means to develop your own base entity.
    /// </summary>
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }
        IEnumerable<PropertyInfo> GetSignatureProperties();
        bool IsTransient();
    }
}
