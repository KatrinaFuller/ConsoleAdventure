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

    // public string GetTemplate()
    // {
    //   string template = $"Room: {Name} \n {Description}\n";

    //   foreach (var exit in Exits)
    //   {
    //     template += "\n \t" + exit.Key + " brings you to Room " + exit.Value.Name + Environment.NewLine;
    //   }
    //   foreach (var item in Items)
    //   {
    //     template += $"Item: \n{item.Name} \t {item.Description} \n";
    //   }
    //   return template;
    // }

    public string GetTemplate(IGame _game)
    {
      string template = $"Room: {Name} \n {Description}\n";



      // if flashlight is on or in rooms 1 or 2, show where to go
      if (_game.UsingFlashlight || _game.CurrentRoom.Name == "1" || _game.CurrentRoom.Name == "2")
      {
        foreach (var exit in Exits)
        {
          template += "\n \t" + exit.Key + " brings you to Room " + exit.Value.Name + Environment.NewLine;
        }
        foreach (var item in Items)
        {
          template += $"Item: \n{item.Name} \t {item.Description} \n";
        }
      }
      else
      {
        // flashlight is OFF and we are not in room 1 or 2 
        template += $"It's really dark in here. You can't see where to go.\n";
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