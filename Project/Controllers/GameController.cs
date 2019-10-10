using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();

    // public bool playing = true;

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      //   Console.Clear();
      InitialSetup();
      while (true)
      {
        Print();
        GetUserInput();
      }
    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      Console.WriteLine("What would you like to do?");
      Console.WriteLine("Go , Look , Help, Quit");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"

      //   Console.WriteLine($"Command: {command}");
      switch (command)
      {
        case "q":
        case "quit":
          Environment.Exit(0);
          break;
        case "g":
        case "go":
          Console.WriteLine("Which direction would you like to go?");
          _gameService.Go(option);
          break;
        case "t":
        case "take":
          _gameService.TakeItem(option);
          break;
        case "u":
        case "use":
          _gameService.UseItem(option);
          break;
        case "l":
        case "look":
          _gameService.Look();
          break;
        case "h":
        case "help":
          _gameService.Help();
          break;

      }

    }

    //NOTE this should print your messages for the game.
    private void Print()
    {
      Console.Clear();
      foreach (var message in _gameService.Messages)
      {
        Console.WriteLine(message);
      }
      _gameService.Messages.Clear();
    }

    public void InitialSetup()
    {
      Console.WriteLine("What is your name?");
      _gameService.Setup(Console.ReadLine());
      //need room to print on console

    }

  }
}