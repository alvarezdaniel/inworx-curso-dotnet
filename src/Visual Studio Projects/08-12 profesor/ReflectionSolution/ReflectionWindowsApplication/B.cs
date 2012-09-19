using System;

namespace ReflectionWindowsApplication
{
	/// <summary>
	/// Summary description for B.
	/// </summary>
	[AuthorLib.Author("AA")]
	public class B
	{
		public B()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[AuthorLib.Author("AA")]
		public override string ToString()
		{
			return "Soy B";
		}
	}
}
