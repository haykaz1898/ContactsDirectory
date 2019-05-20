using System;
using System.Collections.Generic;
using Database;
using System.Linq;

namespace ContactCatalog
{
    internal class GenderEntityToModel : IEntityToModel<GenderEntity, GenderModel>
    {
        public GenderModel Convert(GenderEntity entity)
        {
            GenderModel gender;
            Enum.TryParse(entity.Gender, out gender);
            return gender;
        }

        public IEnumerable<GenderModel> Convert(IEnumerable<GenderEntity> entities)
        {
            return entities.Select(Convert);
        }
    }

}
