using System;
using ConsoleAdventure.Project;
using ConsoleAdventure.Project.Controllers;

namespace ConsoleAdventure
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("Welcome to the Corn Maze! Press (y)es to play or (n)o to not.");
      new GameController().Run();
      // switch ()
      // {
      //   case "y":
      //     break;
      //   case "n":

      //     break;
      // }
    }
  }
}
