
namespace Inworx.Chat
{

class Client
{
  private int port;
  private string ip;
  private User user;
  
  public Client(string nick, int port, string ip)
  {
    user = new User(nick);
	this.port = port;
	this.ip = ip;
  }
}

}