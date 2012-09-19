using System;
using DataLayer;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for Author.
	/// </summary>
	public class Author
	{
		private string id;
		private string firstName;
		private string lastName;

		public Author()
		{
		}

		public string Id
		{
			get{return id;}
			set{id = value;}
		}

		public string FirstName
		{
			get{return firstName;}
			set{firstName = value;}
		}

		public string LastName
		{
			get{return lastName;}
			set{lastName = value;}
		}

		public void Insert()
		{
			AuthorDALC.Insert(id, firstName, lastName);
		}

		public void Update()
		{
			AuthorDALC.Update(id, firstName, lastName);
		}

		public void Delete()
		{
			AuthorDALC.Delete(id);
		}
	}
}
