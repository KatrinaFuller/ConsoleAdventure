using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    //props
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }

    //constructor
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }

    //methods
    public void Go(string direction)
    {
      //changing rooms
      string from = _game.CurrentRoom.Name;
      _game.CurrentRoom = _game.CurrentRoom.Go(direction);
      string to = _game.CurrentRoom.Name;

      //if failing to go anywhere
      if (from == to)
      {
        Messages.Add("Nope, trust me, you do not want to go this way");
        return;
      }
      Messages.Add($"You have left Room {from} and are now in Room {to}");
      Messages.Add(_game.CurrentRoom.GetTemplate(_game));
    }
    public void Help()
    {
      // Console.Clear();
      Messages.Add("Go - allows you to move to different rooms \nTake - allows you to take an item \nUse - allows you to use an item you have in your inventory \nLook - allows you to look around the room you are in \nQuit - when you give up and want to quit");
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      Messages.Add(_game.CurrentRoom.GetTemplate(_game));
    }

    public void Quit()
    {
      throw new System.NotImplementedException();
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void Setup(string playerName)
    {
      Messages.Add($"You are now in Room {_game.CurrentRoom.Name}");
      Messages.Add(_game.CurrentRoom.GetTemplate(_game));

    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {

      //check if an item in the room
      if (_game.CurrentRoom.Items.Count == 0)
      {
        Messages.Add("There are no items in this room for you to take.");
        return;
      }

      //check if named an actual item that is in the room
      foreach (Item item in _game.CurrentRoom.Items)
      {
        if (item.Name == itemName)
        {
          Messages.Add($"You grabbed the {itemName}");
          //once item is taken, that item is removed from the room
          _game.CurrentPlayer.Inventory.Add(item);
          _game.CurrentRoom.Items.Remove(item);
          return;
        }
      }
      Messages.Add("The item you have entered is not in this room.");
    }

    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {

      foreach (Item item in _game.CurrentPlayer.Inventory)
      {
        //check if player has an item
        if (item.Name == itemName)
        {
          //if yes and a flashlight, change using bool to true
          //if use it a second time change to false
          _game.UsingFlashlight = !_game.UsingFlashlight;
          Messages.Add($"The flashlight is now {_game.UsingFlashlight}");

        }
      }
    }
  }
}