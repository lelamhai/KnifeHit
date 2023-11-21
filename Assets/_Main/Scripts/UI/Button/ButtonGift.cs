using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

public class ButtonGift : BaseButton, IDataPersistence
{
    [SerializeField] private TimerUI _displayUI;

    [SerializeField] private int _days;
    [SerializeField] private int _hours;
    [SerializeField] private int _minutes;
    [SerializeField] private int _seconds;

    private DateTime _data = DateTime.Now;
    private DateTime _today;
    private bool _canReward = true;
    private float _timer = 0;

    private void Awake()
    {
        RegisterData();
    }

    private void OnEnable()
    {
        StartTimer();
    }

    protected override void Start()
    {
        base.Start();
        StartTimer();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        TimeSpan timeSpan = new TimeSpan(-_days, -_hours, -_minutes, -_seconds);
        _data = _data.Add(timeSpan);
    }

    private void StartTimer()
    {
        if (_canReward)
        {
            _displayUI.Format_Reward();
            return;
        }

        _canReward = false;

        TimeSpan timeSpan = new TimeSpan(_days, _hours, _minutes, _seconds);
        _data = _data.Add(timeSpan);

        _today = DateTime.Now;

        _timer = (int)_today.Subtract(_data).TotalSeconds;

        int result = DateTime.Compare(_today, _data);
        switch(result)
        {
            case -1:
                if (_timer < 0)
                {
                    Debug.Log("1.0");
                    _timer = (int)Mathf.Abs(_timer);
                    StartCoroutine(IECountDown((result) => {
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
        PriceManager.Instance.AddPrice(10);
        DataPersistanceManager.Instance.SaveData();
        _canReward = false;
        _data = DateTime.Now;
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
    {
        _canReward = false;

        //_data = ParseDateTime(data.Reward.TimeReward);
        _data = ParseDateTime(data.TimeReward);
    }

    public void SaveData(GameData data)
    {
        if (!_canReward) return;

        //Reward reward = new Reward();
        //reward.CanReward = _canReward;
        //reward.TimeReward = ParseTimestamp(_data);
        //data.Reward = reward;

        data.TimeReward = ParseTimestamp(_data);
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