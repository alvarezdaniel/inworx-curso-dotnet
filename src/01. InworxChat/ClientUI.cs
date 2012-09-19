using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Inworx.Chat
{
  class ClientUI
  {
	private TcpClient conexion;
	private int port;
	private IPAddress ip;
	
    public void SendMessage(string s)
	{
		byte[] buf = new byte[1024];
		NetworkStream ns = conexion.GetStream();
		if (ns.CanWrite)
		{
		  buf = Encoding.ASCII.GetBytes(s);
		  ns.Write(buf, 0, s.Length);
		}
         
		int leido = 0;
		int acum = 0;
		string str = "";
		do
		{
		  leido = ns.Read(buf, 0, buf.Length);
		  acum += leido;
		  str = String.Concat(str, Encoding.ASCII.GetString(buf, 0, leido));
		}
		while(ns.DataAvailable);
		
		System.Console.WriteLine(str);
	}

	public ClientUI(string ip, int port)
	{
	  this.ip = IPAddress.Parse(ip);
	  this.port = port;
	}
	
	public void Conectar()
	{
	  conexion = new TcpClient();
	  conexion.Connect(ip, port);
	}
	
	public void Desconectar()
	{
	  conexion.Close();
	}

	public static void Main(string[] args)
	{
      ClientUI cliente = new ClientUI("127.0.0.1", 7777);
	  string str = "";
	  
	  while ((str = Console.ReadLine()) != "x")
	  {
	    cliente.Conectar();
	    cliente.SendMessage(str);
	    cliente.Desconectar();
	  }
      cliente.Conectar();
	  cliente.SendMessage("salir");
      cliente.Desconectar();
	  System.Console.WriteLine("ya ta!!");
	}
  }
}