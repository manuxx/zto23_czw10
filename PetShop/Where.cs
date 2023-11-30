using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.DomainClasses
{
    public class Where<TItem>
    {
        public static CriteriaBuilder<TItem, TProperty> HasAn<TProperty>(Func<TItem, TProperty> propertySelector)
        {
            return new CriteriaBuilder<TItem, TProperty>(propertySelector);
        }

        public static CriteriaBuilder<TItem, TProperty> HasComparable<TProperty>(Func<TItem, TProperty> propertySelector) where TProperty : IComparable<TProperty>
        {
            return new CriteriaBuilder<TItem, TProperty>(propertySelector);
        }
    }

    public class CriteriaBuilder<TItem, TProperty>
    {
        private readonly Func<TItem, TProperty> _propertySelector;

        public CriteriaBuilder(Func<TItem, TProperty> propertySelector)
        {
            _propertySelector = propertySelector;
        }

        public Criteria<TItem> EqualTo(TProperty species)
        {
            return new PredicateCriteria<TItem>(p => _propertySelector(p).Equals(species));
        }

        public Criteria<TItem> GreaterThan<TComparableProperty>(TComparableProperty v)
            where TComparableProperty : IComparable<TProperty>
        {
            return new PredicateCriteria<TItem>(p => v.CompareTo(_propertySelector(p)) < 0);
        }
    }
}
