using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

public class ButtonGift : BaseButton, IDataPersistence
{
    [SerializeField] private GiftRewardDatabase _data;
    [SerializeField] private TimerUI _displayUI;

    [SerializeField] private int _days;
    [SerializeField] private int _hours;
    [SerializeField] private int _minutes;
    [SerializeField] private int _seconds;
    [SerializeField] private AudioClip _audioClip;



    private DateTime _date = DateTime.Now;
    private DateTime _today;
    private bool _canReward = false;
    private float _timer = 0;

    private void Awake()
    {
        RegisterData();
    }

    private void OnEnable()
    {
        StartTimer();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        TimeSpan timeSpan = new TimeSpan(-_days, -_hours, -_minutes, -_seconds);
        _date = _date.Add(timeSpan);
        _canReward = false;
    }

    private void StartTimer()
    {
        if (string.IsNullOrEmpty(_data.Time))
        {
            _displayUI.Format_Reward();
            _canReward = true;
            return;
        } else
        {
            _date = ParseDateTime(_data.Time);
        }

        TimeSpan timeSpan = new TimeSpan(_days, _hours, _minutes, _seconds);
        _date = _date.Add(timeSpan);

        _today = DateTime.Now;

        _timer = (int)_today.Subtract(_date).TotalSeconds;

        int result = DateTime.Compare(_today, _date);
        switch (result)
        {
            case -1:
                if (_timer < 0)
                {
                    _timer = (int)Mathf.Abs(_timer);
                    StartCoroutine(IECountDown((result) =>
                    {
                        _canReward = true;
                        _displayUI.Format_Reward();
                    }));
                }
                else
                {
                    _canReward = true;
                    _displayUI.Format_Reward();
                }
                break;

            case 0:
            case 1:
                _canReward = true;
                _displayUI.Format_Reward();
                break;

            default:
                Debug.Log("None");
                break;
        }
    }

    protected override void OnClickButton()
    {
        if (!_canReward) return;
        SpawnEffect.Instance.SpawnTypeEffect(TypeEffect.Reward);
        PriceManager.Instance.AddPrice(_data.Price);
        DataPersistanceManager.Instance.SaveData();
        AudioManager.Instance.PlaySound(_audioClip);
        _canReward = false;
        StartTimer();
    }

    private IEnumerator IECountDown(UnityAction<bool> callback)
    {
        _timer = Mathf.Abs(_timer);
        do
        {
            _timer -= Time.deltaTime;
            _displayUI.Format_1(_timer);
            yield return null;

        } while (_timer > 0);
        callback?.Invoke(true);
    }

    public void LoadData(GameData data)
    {}

    public void SaveData(GameData data)
    {
        if (!_canReward) return;

        _date = DateTime.Now;
        string date = ParseTimestamp(_date);
        data.Gift.Time = date;


        int price = _data.Price;
        data.Gift.Price = price;

        _data.Time = date;
    }

    public void RegisterData()
    {
        DataPersistanceManager.Instance.RegisterEventDataPersistance(this);
    }

    private DateTime ParseDateTime(string timestamp)
    {
        return DateTime.ParseExact(timestamp, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
    }

    private String ParseTimestamp(DateTime date)
    {
        return date.ToString("yyyyMMddHHmmss");
    }
}