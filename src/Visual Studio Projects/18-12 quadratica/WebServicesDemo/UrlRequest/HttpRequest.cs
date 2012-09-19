using System;
using System.Web;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace UrlRequest
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class HttpRequest
	{
		public static int nResp = 0;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			HttpWebRequest req1 = (HttpWebRequest)WebRequest.Create("http://www.clarin.com.ar");
			Console.WriteLine("Consultando {0}", req1.Address.AbsoluteUri);
			Handler h = new Handler();
			AsyncCallback callback = new AsyncCallback(h.ProcessResponse);
			req1.BeginGetResponse(callback, req1);
			

			HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost/helloworldweb/webform1.aspx");
			Console.WriteLine("Consultando {0}", req2.Address.AbsoluteUri);
			HttpRequest.ProcessResponse( (HttpWebResponse)req2.GetResponse() );
			
			Console.ReadLine();
		}

		public static void ProcessResponse(HttpWebResponse resp)
		{
			Stream s = resp.GetResponseStream();
			StreamReader sr = new StreamReader(s, Encoding.ASCII);
			
			StringBuilder sb = new StringBuilder();
			char [] datos = new char[1024];
			int nBytes;
			do
			{
				nBytes = sr.Read(datos, 0, (int)1024);
				sb.Append(datos);
			}while(nBytes == 1024);

			Console.WriteLine("Respuesta sincronica: " + resp.ResponseUri);
		}
	}

	public class Handler
	{
		public void ProcessResponse(IAsyncResult ar)
		{
			HttpWebRequest req = (HttpWebRequest) ar.AsyncState;

			HttpWebResponse resp = (HttpWebResponse) req.EndGetResponse(ar);

			Stream s = resp.GetResponseStream();
			StreamReader sr = new StreamReader(s, Encoding.ASCII);
			
			StringBuilder sb = new StringBuilder();
			char [] datos = new char[1024];
			int nBytes;
			do
			{
				nBytes = sr.Read(datos, 0, (int)1024);
				sb.Append(datos);
			}while(nBytes == 1024);

			Console.WriteLine("Respuesta asincronica: " + resp.ResponseUri);
		}
	}
}
