using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {

    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      //create rooms
      Room room1 = new Room("1", "Room 1");
      Room room2 = new Room("2", "Room 2");
      Room room3 = new Room("3", "Room 3");
      Room room4 = new Room("4", "Room 4");
      Room room5 = new Room("5", "Room 5");

      //relationships between the rooms
      room1.Exits.Add("east", room2);
      room2.Exits.Add("west", room1);

      room2.Exits.Add("east", room3);
      room3.Exits.Add("west", room2);

      room3.Exits.Add("north", room4);     //dies in room 4

      room3.Exits.Add("south", room5);     //wins in room 5

    }

    //constructor
    // public Game()
    // {
    //   Player = new Player();
    //   Setup();
    // }
  }
}