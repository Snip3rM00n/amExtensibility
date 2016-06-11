using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amExtensibility
{
	/// <summary>
	/// A collection of Enumerable extensions.
	/// </summary>
	public static class EnumerableExtentions
	{
		/// <summary>
		/// Randomizes items in an IEnumerable.
		/// </summary>
		/// <typeparam name="T">The type of the IEnumerable</typeparam>
		/// <param name="source">The source IEnumerable</param>
		/// <returns>The IEnumerable randomized in order.</returns>
		public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
		{
			Random rand = new Random();
			return source.OrderBy(item => rand.Next());
		}
	}
}
