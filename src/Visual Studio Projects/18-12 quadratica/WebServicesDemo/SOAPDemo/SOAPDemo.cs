using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Text;

namespace SOAPDemo
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class SOAPDemo
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			string str = BuildSOAPMessage();
			string results = GetSOAPData("http://localhost/woodgrove/Bank.asmx", "GetAccount", str);
			Console.WriteLine("Resultado: " + results);
			Console.ReadLine();
		}

		public static string GetSOAPData(string url,string action,string content)
		{
			Stream s;
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			string hdr = "SOAPAction: \"http://localhost/" + action + "\"";
			req.Headers.Add(hdr);
			req.ContentType="text/xml; charset=utf-8";
			req.Method = "POST";
			if (content.Length > 0)
			{
				req.ContentLength=content.Length;
				s = req.GetRequestStream();
				StreamWriter sw = new StreamWriter(s);
				sw.Write(content);
				sw.Close();
			}

			try
			{
				HttpWebResponse res = (HttpWebResponse)req.GetResponse();
				return GetResponseAsString(res);
			}
			catch(System.Exception e)
			{
				// appropriate exception handling 
			}
			return "";
		}

		public static string BuildSOAPMessage()
		{
			MemoryStream st;
			string str;
			byte [] buffer;
			st = new MemoryStream(1024);


			XmlTextWriter tr = new XmlTextWriter(st,Encoding.UTF8);
			tr.WriteStartDocument();
			tr.WriteStartElement("soap","Envelope","http://schemas.xmlsoap.org/soap/envelope/");
			tr.WriteAttributeString("xmlns","xsi",null,"http://www.w3.org/2001/XMLSchema-instance");
			tr.WriteAttributeString("xmlns","xsd",null,"http://www.w3.org/2001/XMLSchema");
			tr.WriteAttributeString("xmlns","soap",null,"http://schemas.xmlsoap.org/soap/envelope/");

			tr.WriteStartElement("Header","http://schemas.xmlsoap.org/soap/envelope/");
			tr.WriteStartElement(null,"MyHeader","http://woodgrovebank.com");
			tr.WriteElementString("Username","Pat");
			tr.WriteElementString("Password","pwd");
			tr.WriteEndElement();
			tr.WriteEndElement();

			tr.WriteStartElement("Body","http://schemas.xmlsoap.org/soap/envelope/");
			tr.WriteStartElement(null,"GetAccount","http://woodgrovebank.com");
			tr.WriteElementString("acctNumber","1234");
			tr.WriteEndElement();
			tr.WriteEndElement(); 
			tr.WriteEndDocument();
			tr.Flush();
			buffer = st.GetBuffer();
			Decoder d = Encoding.UTF8.GetDecoder();
			char [] chars = new char[buffer.Length];
			//skip the byte order mark
			d.GetChars(buffer,2,buffer.Length-2,chars,0);
			str = new String(chars);
			tr.Close();
			st.Close();
			return str;
		}

		public static string GetResponseAsString(WebResponse res)
		{
			Stream s = res.GetResponseStream();
			StreamReader sr = new StreamReader(s,Encoding.ASCII);
			StringBuilder sb = new StringBuilder();
			char [] data = new char[1024];
			int nBytes;
			do 
			{
				nBytes = sr.Read(data,0,(int)1024);
				sb.Append(data);
			} while (nBytes == 1024);
			return sb.ToString();
		}
	}
}
