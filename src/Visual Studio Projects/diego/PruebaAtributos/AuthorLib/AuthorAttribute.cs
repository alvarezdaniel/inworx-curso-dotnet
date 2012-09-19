using System;

namespace AuthorLib
{
	/// <summary>
	/// Summary description for AuthorAttribute.
	/// </summary>
	/// 
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class AuthorAttribute: Attribute
	{
		private string nombre;
        
        public AuthorAttribute(string Nombre)
		{
            nombre = Nombre;
		}
        
        public string Nombre
        {
            get { return nombre; }
        }
	}
}
