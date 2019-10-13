using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Item : IItem
  {
    //props
    public string Name { get; set; }
    public string Description { get; set; }


    //constructor
    public Item(string name, string description)
    {
      Name = name;
      Description = description;
    }
  }
}