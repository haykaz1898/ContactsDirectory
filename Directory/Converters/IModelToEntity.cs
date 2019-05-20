using System.Collections.Generic;

namespace ContactCatalog
{
    internal interface IModelToEntity<S, T>
    {
        T Convert(S model);
        IEnumerable<T> Convert(IEnumerable<S> models);
    }

}
