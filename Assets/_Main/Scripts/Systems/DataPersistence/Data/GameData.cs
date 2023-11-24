using System;

[Serializable]
public class GameData
{
    public double Price;
    public int Level;
    public Sound Sound;
    public Gift Gift;
    public bool Vibration;

    public GenericDictionary<int, KnifeModel> Knife;

    public GameData()
    {
        this.Price = 0;
        this.Level = 0;
        this.Vibration = true;
        this.Sound = new Sound();
        this.Gift = new Gift();
        this.Knife = new GenericDictionary<int, KnifeModel>();
    }
}

[Serializable]
public struct Sound
{
    public float VolumeBG;
    public float VolumeFX;

    public Sound(float volumeBG, float volumeFX)
    {
        this.VolumeBG = volumeBG;
        this.VolumeFX = volumeFX;
    }
}

[Serializable]
public struct Gift
{
    public string Time;
    public int Price;

    public Gift(string time)
    {
        this.Time = time;
        this.Price = -1;
    }
}