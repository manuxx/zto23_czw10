using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Machine.Specifications;
using Machine.Specifications.Utility.Internal;

namespace Training.Specificaton
{
    public static class AssertionExtensions
    {
        public static void ShouldContainOnlyInOrder<TItem>(this IEnumerable<TItem> items, params TItem[] ordered_items)
        {
            AssertionExtensions.ShouldContainOnlyInOrder<TItem>(items, (IEnumerable<TItem>)ordered_items);
        }

        public static void ShouldContainOnly<TItem>(this IEnumerable<TItem> items, params TItem[] elements)
        {
            var exception = new SpecificationException(
                string.Format(
                    "The set of items should only contain the items: {0}\r\nbut it actually contains the items: {1}",
                    elements.EachToUsefulString(), items.EachToUsefulString()));

            var items_to_check = items.ToList();
            foreach (var element in elements)
            {
                if (!items_to_check.Contains(element))
                    throw exception;
                items_to_check.Remove(element);
            }

            if (items_to_check.Count != 0)
                throw exception;
        }

        public static void ShouldContainOnlyInOrder<TItem>(this IEnumerable<TItem> items, IEnumerable<TItem> ordered_items)
        {
            List<TItem> source = new List<TItem>(items);
            if (!Enumerable.Any<TItem>(Enumerable.Where<TItem>(ordered_items, (Func<TItem, int, bool>)((ordered_element, index) => !source[index].Equals((object)ordered_element)))))
                return;
            throw new SpecificationException(string.Format("The set of items should only contain the items in the order {0}\r\nbut it actually contains the items:{1}", ordered_items.EachToUsefulString(), items.EachToUsefulString()));
        }
    }
}
