using System;

namespace Inworx.Chat
{

class Message
{
  private string text;
  private string sender;
  private DateTime fecha;
  
  public Message()
  {
    text = "";
	sender = "";
	fecha = DateTime.Now;
  }
}

}