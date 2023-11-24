using UnityEngine;
using UnityEngine.UI;

public class AudioManager : Singleton<AudioManager>, IDataPersistence
{
    [SerializeField] private SoundDatabase _data;
    [SerializeField] private AudioSource _bgSource;
    [SerializeField] private AudioSource _fxSource;
    [SerializeField] private Slider _soundBG;
    [SerializeField] private Slider _soundFX;

    private void Awake()
    {
        RegisterData();
    }

    private void Start()
    {
        AllAudio(_data.VolumeBG, _data.VolumeFX);
    }

    public void PlaySound(AudioClip audioClip)
    {
        _fxSource.PlayOneShot(audioClip);
    }

    public void AllAudio(float valueBG, float valueFX)
    {
        BGAudio(valueBG);
        FXAudio(valueFX);
        _soundBG.value = valueBG;
        _soundFX.value = valueFX;
    }

    public void Mute()
    {
        BGAudio(0);
        FXAudio(0);
    }

    public void BGAudio(float value)
    {
        _bgSource.volume = value;
        _data.VolumeBG = value;
    }

    public void FXAudio(float value)
    {
        _fxSource.volume = value;
        _data.VolumeFX = value;
    }

    protected override void SetDefaultValue()
    {
        Transform bg = this.transform.Find("BGAudio");
        _bgSource = bg.GetComponent<AudioSource>();

        Transform fx = this.transform.Find("FXAudio");
        _fxSource = fx.GetComponent<AudioSource>();
    }

    public void LoadData(GameData data)
    {}

    public void SaveData(GameData data)
    {
        Sound sound = new Sound();
        sound.VolumeBG = _data.VolumeBG;
        sound.VolumeFX = _data.VolumeFX;

        data.Sound = sound;
    }

    public void RegisterData()
    {
        DataPersistanceManager.Instance.RegisterEventDataPersistance(this);
    }
}