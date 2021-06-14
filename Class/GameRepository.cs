using System;
using System.Collections.Generic;
using Games.Interface;

namespace Games
{
  public class GameRepository : IFRepository<Game>
  {
    private List<Game> gameList = new List<Game>();
    public void Insert(Game newObject)
    {
      gameList.Add(newObject);
    }
    public Game ReturnById(int id)
    {
      return gameList[id];
    }
    public void Update(int id, Game newObject)
    {
      gameList[id] = newObject;
    }
    public void Remove(int id)
    {
      gameList[id].Exclude();
    }
    public List<Game> List()
    {
      return gameList;
    }
    public int NextId()
    {
      return gameList.Count;
    }
  }
}