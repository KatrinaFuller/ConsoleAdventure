using System;
using ConsoleAdventure.Project;
using ConsoleAdventure.Project.Controllers;

namespace ConsoleAdventure
{
  public class Program
  {
    public static void Main(string[] args)
    {
      AskQuestion();
    }

    public static void AskQuestion()
    {
      Console.WriteLine("Welcome to the Corn Maze! Press (Y)es to play or (N)o to not.");
      switch (Console.ReadLine().ToLower())
      {
        case "y":
          new GameController().Run();
          break;
        case "n":
          Environment.Exit(0);
          break;
        default:
          Console.WriteLine("That is not an option");
          AskQuestion();
          break;
      }

    }
  }
}
