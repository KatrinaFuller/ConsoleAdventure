using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Player : IPlayer
  {
    //props
    public string Name { get; set; }
    public List<Item> Inventory { get; set; }

    //constructor
    public Player()
    {
      Name = Name;
      Inventory = new List<Item>();
    }
  }
}