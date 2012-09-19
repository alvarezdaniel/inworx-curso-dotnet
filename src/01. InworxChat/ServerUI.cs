
namespace Inworx.Chat
{
  class ServerUI
  {
	public static void Main(string[] args)
	{
	  Server Servidor = new Server("127.0.0.1", 7777);
	  Servidor.Start();
	  Servidor.Stop();
	  System.Console.WriteLine("ya ta!!");
	}
  }
}