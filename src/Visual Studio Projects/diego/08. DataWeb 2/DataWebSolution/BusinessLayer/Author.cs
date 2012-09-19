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
        private string fname;
        private string lname;

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
        
        public string FName
        {
            get { return fname; }
            set { fname = value; }
        }

        public string LName
        {
            get { return lname; }
            set { lname = value; }
        }
        
        public void Update()
        {
            AuthorDALC dalc = new AuthorDALC();
            dalc.Update(this.id, this.fname, this.lname);
        }
    }
}
