using System;
using System.Collections.Generic;

public class GameData
{
    public GenericDictionary<int, KnifeModel> Knife;

    public GameData()
    {
        Knife = new GenericDictionary<int, KnifeModel>();
    }
}