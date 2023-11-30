using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.DomainClasses
{
    public class Where_Pet
    {
        public static CriteriaBuilder HasAn(Func<Pet, Species> propertySelector)
        {
            return new CriteriaBuilder(propertySelector);
        }
    }

    public class CriteriaBuilder
    {
        private readonly Func<Pet, Species> _propertySelector;

        public CriteriaBuilder(Func<Pet, Species> propertySelector)
        {
            _propertySelector = propertySelector;
        }

        public Criteria<Pet> EqualTo(Species species)
        {
            return new PredicateCriteria<Pet>(p => _propertySelector(p).Equals(species));
        }
    }
}
