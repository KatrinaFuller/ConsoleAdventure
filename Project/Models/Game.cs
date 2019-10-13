using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {

    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }
    public bool UsingFlashlight { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      UsingFlashlight = false;

      //create rooms
      Room room1 = new Room("1", "starting point");
      Room room2 = new Room("2", "second room");
      Room room3 = new Room("3", "third room");
      Room room4 = new Room("4", "fourth room");
      Room room5 = new Room("5", "fifth room");
      Room room6 = new Room("6", "Death has fallen upon you");
      Room room7 = new Room("7", "seventh room");
      Room room8 = new Room("8", "eighth room");
      Room room9 = new Room("9", "You win!");

      //relationships between the rooms
      room1.Exits.Add("east", room2);
      room2.Exits.Add("west", room1);

      room2.Exits.Add("east", room3);
      room3.Exits.Add("west", room2);

      room3.Exits.Add("north", room4);
      room4.Exits.Add("south", room3);

      room4.Exits.Add("west", room5);
      room5.Exits.Add("east", room4);

      room5.Exits.Add("west", room6); //dies in room 6

      room3.Exits.Add("south", room7);
      room7.Exits.Add("north", room3);

      room7.Exits.Add("west", room8);
      room8.Exits.Add("east", room7);

      room8.Exits.Add("west", room9); //wins in room 9




      //items
      Item flashlight = new Item("flashlight", "Would you look at that! Just look at it!");

      //adding item to room
      room1.Items.Add(flashlight);

      //starting room
      CurrentRoom = room1;

    }

    // constructor
    public Game()
    {
      CurrentPlayer = new Player();
      Setup();
    }
  }
}