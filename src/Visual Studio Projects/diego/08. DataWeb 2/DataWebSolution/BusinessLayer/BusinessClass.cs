using System;
using System.Data;
using DataLayer;
using ServiceLayer;

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
            try
            {
                DataClass data = new DataClass();
			    return data.GetData();
            }
            catch(InworxException e)
            {
                InworxException ex = new InworxException("Error en Business Layer - " + e.Message + " - " + e.StackTrace, e);
                throw ex;
            }
		}
	}
}
