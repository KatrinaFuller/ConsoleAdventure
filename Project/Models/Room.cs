using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {

    //props
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }


    //methods
    public void AddExit(string direction, IRoom room)
    {
      Exits.Add(direction, room);
    }

    public IRoom Go(string direction)
    {
      if (Exits.ContainsKey(direction))
      {
        return Exits[direction];
      }
      return this;
    }

    public string GetTemplate()
    {
      string template = $"Room: {Name} \n {Description}\n";
      foreach (var exit in Exits)
      {
        template += "\n \t" + exit.Key + " brings you to Room " + exit.Value.Name + Environment.NewLine;
      }
      foreach (var item in Items)
      {
        template += $"Item: \n{item.Name} \t {item.Description} \n";
      }
      return template;
    }


    //constructor
    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }
  }
}