﻿namespace Training.DomainClasses
{
	public static class CriteriaExtention
	{
		public static Alternative<TItem> Or<TItem>(this Criteria<TItem> criteria1, Criteria<TItem> criteria2)
		{
			return new Alternative<TItem>(criteria1, criteria2);
		}
	}
}
