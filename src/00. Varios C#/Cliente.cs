using System;
using System.Collections;

namespace Inworx
{

  class Cliente
  {
    private string nombre = "";
    private string apellido = "";
	
	public Cliente(string nombre, string apellido)
	{
	  this.nombre = nombre;
	  this.apellido = apellido;
	}
	
	//metodo publico para el paquete. Desde afuera no se ve.
	internal string GetNombre()
	{
	  return nombre + " " + apellido;
	}

	//new public string ToString() //Me permite cambiar la firma del metodo
	override public string ToString() //sobreescribe el metodo
	{
	  return nombre + " " + apellido;
	}
  }

  public class PruebaCliente
  {
    public static void Main(string[] args)
	{
	  //Instancio un cliente
	  //Cliente c = new Cliente("Diego", "Campos");
	  
	  //Coleccion de clientes
	  ArrayList Clientes = new ArrayList();
	  
	  for (int i = 0; i < 3; i ++)
	  {
	    if (i == 0)
		  Clientes.Add(new Cliente("Diego", "Campos"));
		else if (i == 1)
		  Clientes.Add(new Cliente("Daniel", "Alvarez"));
		else
		  Clientes.Add(new Cliente("Gaston", "Insua"));
	  }

	  IEnumerator ptr = Clientes.GetEnumerator();

	  /*foreach (Cliente c in Clientes)
	  {
	    System.Console.WriteLine(c.GetNombre());
	  };*/
	  for (int i = 0; i < Clientes.Count; i++)
	  {
		System.Console.WriteLine(((Cliente)Clientes[i]).GetNombre());
	  };
	  //Imprimo los datos
	  //System.Console.WriteLine(c.GetNombre());
	}
  }

}