using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Inworx.Chat
{
	public class Server
	{
	  //static int const PORT = 1025; CONSTANTES
	  
	  private int port = 1025;
	  private IPAddress ip;
	  private DateTime fecha;
	  private ArrayList clientes;
	  private TcpListener escuchador;
	  
	  private bool ProcesarMensaje(TcpClient cl)
	  {
	    string str = "";
		byte[] buf = new byte[1024];
		NetworkStream ns = cl.GetStream();
		int leido = 0;
		int acum = 0;
		
		//while (acum < ns.Length)
		do
		{
		  leido = ns.Read(buf, 0, buf.Length);
		  acum += leido;
		  str = String.Concat(str, Encoding.ASCII.GetString(buf, 0, leido));
		}
		while(ns.DataAvailable);
		
		System.Console.WriteLine(str);
		
		if (ns.CanWrite)
		{
		  str = String.Concat(str, " - Respuesta");
		  buf = Encoding.ASCII.GetBytes(str);
		  ns.Write(buf, 0, str.Length);
		}
		
		cl.Close();
		return true;
	  }
	  
	  public void Start()
	  {
  	    System.Console.WriteLine("Servidor iniciado");
		escuchador.Start();

		while (true)
		{
		  TcpClient cl = escuchador.AcceptTcpClient();
		  //clientes.
		  ProcesarMensaje(cl);
		}
	  }
	  
	  public void Stop()
	  {
	    escuchador.Stop();
	  }
	  
	  public Server(string ip, int port)
	  {
	    clientes = new ArrayList();
		this.port = port;
		this.ip = IPAddress.Parse(ip);
		fecha = DateTime.Now;
		escuchador = new TcpListener(this.ip, this.port);
	  }
	  	  
	}

}