using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDatabase : BaseDatabase
{
    public GenericDictionary<int, ItemKnifeDatabase> Database = new GenericDictionary<int, ItemKnifeDatabase>();
}