using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amExtensibility
{
	/// <summary>
	/// A collection of String extentions
	/// </summary>
	public static class StringExtentions
	{
		
		/// <summary>
		/// Retrieves a random character string.
		/// </summary>
		/// <param name="str">This string</param>
		/// <param name="length">Desired string length (default = 10)</param>
		/// <returns>Random character string with special characters</returns>
		public static string Random(this string str, int length = 10)
		{
			char[] range = { ' ', 'ÿ' };
			str = makeRandomString(length, 1, ' ', range);

			return str;
		}

		/// <summary>
		/// Retrieves a random character string.
		/// </summary>
		/// <param name="str">This string</param>
		/// <param name="segments">Number of desired segments</param>
		/// <param name="segmentLength">Length of each segment</param>
		/// <param name="seperator">Seperator for each segment (default = ' ')</param>
		/// <returns>Random character string with special characters</returns>
		public static string Random(this string str, int segments, int segmentLength, char seperator = ' ')
		{
			char[] range = { ' ', 'ÿ' };
			return makeRandomString(segmentLength, segments, seperator, range);
		}

		/// <summary>
		/// Retrieves a random character string.
		/// </summary>
		/// <param name="str">This string</param>
		/// <param name="length">Desired string length (default = 10)</param>
		/// <returns>Random character string from A to Z</returns>
		public static string Random_AtoZ(this string str, int length = 10)
		{
			char[] range = { 'A', 'Z' };
			return makeRandomString(10, 1, ' ', range);
		}

		/// <summary>
		/// Retrieves a random character string.
		/// </summary>
		/// <param name="str">This string</param>
		/// <param name="segments">Number of desired segments</param>
		/// <param name="segmentLength">Length of each segment</param>
		/// <param name="seperator">Seperator for each segment (default = ' ')</param>
		/// <returns>Random character string from A to Z</returns>
		public static string Random_AtoZ(this string str, int segments, int segmentLength, char seperator = ' ')
		{
			char[] range = { 'A', 'Z' };
			return makeRandomString(segmentLength, segments, seperator, range);
		}

		/// <summary>
		/// Retrieves a random 10 character string.
		/// </summary>
		/// <param name="str">This string</param>
		/// <param name="length">Desired string length (default = 10)</param>
		/// <returns>Random 10 character string from A to z without special characters</returns>
		public static string Random_Atoz(this string str, int length = 10)
		{
			char[] range = { 'A', 'z' };
			char[] invalidChars = { '[', '\\', ']', '^', '_', '`' };
			return makeRandomString(10, 1, ' ', range, invalidChars);
		}

		/// <summary>
		/// Retrieves a random 10 character string.
		/// </summary>
		/// <param name="str">This string</param>
		/// <param name="segments">Number of desired segments</param>
		/// <param name="segmentLength">Length of each segment</param>
		/// <param name="seperator">Seperator for each segment (default = ' ')</param>
		/// <returns>Random 10 character string from A to z without special characters</returns>
		public static string Random_Atoz(this string str, int segments, int segmentLength, char seperator = ' ')
		{
			char[] range = { 'A', 'z' };
			char[] invalidChars = { '[', '\\', ']', '^', '_', '`' };
			return makeRandomString(segmentLength, segments, seperator, range, invalidChars);
		}

		/// <summary>
		/// Creates a random string
		/// </summary>
		/// <param name="segLength">Length of each segment</param>
		/// <param name="segCount">Total desired segments</param>
		/// <param name="seperator">Seperator for each segment</param>
		/// <param name="charRange">Range of characters for each segment</param>
		/// <param name="invalidChars">Collection of undesirged characters</param>
		/// <returns></returns>
		private static string makeRandomString(int segLength, int segCount, char seperator, char[] charRange, char[] invalidChars = null)
		{
			string rString = string.Empty;

			for (int x = 0; x < segCount; x++)
			{
				if (x > 0) rString += seperator;

				for (int y = 0; y < segLength; y++)
				{
					char rChar = getRandChar(x, y, charRange);

					if (invalidChars != null)
					{
						while (invalidChars.Contains(rChar))
						{
							Random r = new Random(DateTime.Now.GetHashCode() + rString.GetHashCode());
							rChar = getRandChar(x + r.Next(10000), y, charRange);
						}
					}
					rString += rChar;
				}
			}

			return rString;
		}

		/// <summary>
		/// Gets a random character.
		/// </summary>
		/// <param name="x">First integer to generate seed</param>
		/// <param name="y">Second integer to generate seed</param>
		/// <param name="range">The character range to sample</param>
		/// <returns>A random character</returns>
		private static char getRandChar(int x, int y, char[] range)
		{
			int seed = (DateTime.Now.GetHashCode() + x) / (y + 1);
			Random r = new Random(seed);
			return (char)r.Next(range[0], range[1]);
		}
	}
}
