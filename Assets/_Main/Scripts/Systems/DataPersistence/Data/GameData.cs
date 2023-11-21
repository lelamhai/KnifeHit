using System;


[Serializable]
public class GameData
{
    public double Price;
    public int Level;
    public string TimeReward;
    //public Reward Reward;

    public GenericDictionary<int, KnifeModel> Knife;

    public GameData()
    {
        this.Price = 0;
        this.Level = 0;
        this.TimeReward = string.Empty;
        //this.Reward = new Reward();
        Knife = new GenericDictionary<int, KnifeModel>();
    }
}


//[Serializable]
//public struct Reward
//{
//    public bool CanReward;
//    public string TimeReward;

//    public Reward(bool canReward, string timeReward)
//    {
//        this.CanReward = canReward;
//        this.TimeReward = timeReward;
//    }
//}