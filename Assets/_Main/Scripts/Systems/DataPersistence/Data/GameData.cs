using System.Collections.Generic;

public class GameData
{
    public double Price;
    public int Level;
    public GenericDictionary<int, KnifeModel> Knife;

    public GameData()
    {
        this.Price = 0;
        this.Level = 0;
        Knife = new GenericDictionary<int, KnifeModel>();
    }
}