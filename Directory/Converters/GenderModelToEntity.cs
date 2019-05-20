using System;
using System.Collections.Generic;
using Database;
using System.Linq;

namespace ContactCatalog
{
    internal class GenderModelToEntity : IModelToEntity<GenderModel,GenderEntity>
    {
        public GenderEntity Convert(GenderModel model)
        {
            return new GenderEntity
            {
                Gender = model.ToString(),
                GenderId = (int)model + 1
            };
        }

        public IEnumerable<GenderEntity> Convert(IEnumerable<GenderModel> models)
        {
            return models.Select(Convert);
        }
    }

}
