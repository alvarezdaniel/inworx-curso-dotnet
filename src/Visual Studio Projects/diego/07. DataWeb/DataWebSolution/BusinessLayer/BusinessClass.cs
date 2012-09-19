using System;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class BusinessClass
	{
		public BusinessClass()
		{
		}

		public DataSet GetData()
		{
			DataClass data = new DataClass();
			return data.GetData();
		}
	}
}
