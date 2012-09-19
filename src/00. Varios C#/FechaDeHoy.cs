using System;

namespace Inworx
{

  public class FechaDeHoy
  {
    public static void Main(string[] args)
	{
	  //imprime
	  DateTime d = DateTime.Now;
	  Console.WriteLine(d.ToString());
	  Console.WriteLine(d.DayOfWeek.ToString());
	  Console.WriteLine(d.Month.ToString());
	}
  }

}