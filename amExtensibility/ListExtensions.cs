using System.Collections.Generic;
using System;

namespace amExtensibility
{
	/// <summary>
	/// A collection of extentions for Lists.
	/// </summary>
	public static class ListExtensions
	{
		/// <summary>
		/// Gets the next item in a list
		/// </summary>
		/// <typeparam name="T">The type of the list (generic)</typeparam>
		/// <param name="list">The List that you're getting the next object from</param>
		/// <param name="item">The previous object you were working with.</param>
		/// <returns>The next item in the list.</returns>
		public static T NextOf<T>(this IList<T> list, T item)
		{
			return list[(list.IndexOf(item) + 1) == list.Count ? 0 : (list.IndexOf(item) + 1)];
		}

		/// <summary>
		/// Joins two lists together without needing to Concat.
		/// </summary>
		/// <typeparam name="T">The type of the list (generic)</typeparam>
		/// <param name="list">The list you're adding to.</param>
		/// <param name="ListToJoin">The list you want to add the original list.</param>
		/// <param name="removeDuplicates">Remove duplicates while combining lists (default False)</param>
		/// <returns>A list of two combined lists (with or without duplicates)</returns>
		public static IList<T> JoinList<T>(this IList<T> list, IList<T> ListToJoin, bool removeDuplicates = false)
		{
			List<T> thisList = (List<T>)list;
			thisList.AddRange(ListToJoin);

			if (removeDuplicates)
			{
				thisList.RemoveDuplicates();
			}

			return thisList;
		}

		/// <summary>
		/// Removes duplicate items from a list.
		/// </summary>
		/// <typeparam name="T">The type of the list (generic)</typeparam>
		/// <param name="list">The list you want to remove duplicates from.</param>
		/// <returns>A duplicate free list.</returns>
		public static IList<T> RemoveDuplicates<T>(this IList<T> list)
		{
			List<T> tmpList = (List<T>)list;
			var noDuplicates = new HashSet<T>(list);
			list.Clear();
			tmpList.AddRange(noDuplicates);

			return tmpList;
		}

		/// <summary>
		/// Shuffles the items in a list
		/// </summary>
		/// <typeparam name="T">The type of the list (generic)</typeparam>
		/// <param name="list">The list you want to shuffle.</param>
		/// <returns>A list of shuffled items.</returns>
		public static IList<T> Shuffle<T>(this IList<T> list)
		{
			Random rand = new Random();

			for (int i = list.Count - 1; i >= 0; i--)
			{
				T tmp = list[i];
				int index = rand.Next(i + 1);

				list[i] = list[index];
				list[index] = tmp;
			}

			return list;
		}
	}
}
