using System;
using System.Data;
using DataLayer;
using ServiceLayer;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for BusinessClass.
	/// </summary>
	public class BusinessClass
	{
		public BusinessClass()
		{
		}

		public DataSet GetData()
		{
			DataClass data;
			try
			{
				data = new DataClass();
				return data.GetData();
			}
			catch(InworxException ex)
			{
				InworxException ex2;
				ex2 = new InworxException("Error en BusinessLayer.GetData", ex);
				return null;
			}
		}
	}
}
