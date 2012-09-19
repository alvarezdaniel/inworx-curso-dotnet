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
		private string lastName;
		private string firstName;

		public Author(string Id)
		{
			AuthorDALC dalc = new AuthorDALC();
			id = Id;
			dalc.GetData(id, out lastName, out firstName);
		}

		public string Id
		{
			get { return id; }
			set { id = value; }
		}

		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}

		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}

		public void Update()
		{
			AuthorDALC dalc = new AuthorDALC();
			dalc.Update(this.id, this.lastName, this.firstName);
		}
	}
}
