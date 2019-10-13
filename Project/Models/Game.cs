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
      Room room1 = new Room("1", "You wake up in a room you have never seen before. A TV comes on and it's Jigsaw telling you he wants to play a game. He has stuck you in this house and there is only one way out. He ends by saying 'Choose wisely which way to go or you will face a certain death.'");
      Room room2 = new Room("2", "Your only way is to go down this creepy hallway");
      Room room3 = new Room("3", "You have made it to the end of the hallway, but are now faced with opposite ways to go. Choose wisely......");
      Room room4 = new Room("4", "You are getting so scared walking down this way and wondering if you made the right choice. It's not too late to turn back now.");
      Room room5 = new Room("5", "As you come around the corner you see lots of blood. But you are curious to see what it is coming from.");
      Room room6 = new Room("6", "As you enter this room you hit a trip wire and a blade comes down and chops your head off. \nDeath has fallen upon you!");
      Room room7 = new Room("7", "You are getting so scared walking down this way and wondering if you made the right choice. It's not too late to turn back now.");
      Room room8 = new Room("8", "You think you see some light but are not sure if your mind is just playing tricks on you.");
      Room room9 = new Room("9", "You have escaped! But unfortunately for someone else, Jigsaw is now on to his next victum.");

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