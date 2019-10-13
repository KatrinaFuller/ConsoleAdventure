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
      Console.WriteLine("Welcome to the Corn Maze! Press (Y)es to play or (N)o because you are too scared");
      switch (Console.ReadLine().ToLower())
      {
        case "y":
        case "yes":
          new GameController().Run();
          break;
        case "n":
        case "no":
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
