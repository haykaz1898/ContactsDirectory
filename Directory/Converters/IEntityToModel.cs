using System.Collections.Generic;

namespace ContactCatalog
{
    internal interface IEntityToModel<S, T>
    {
        T Convert(S entity);
        IEnumerable<T> Convert(IEnumerable<S> entities);
    }

}
