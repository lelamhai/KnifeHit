using UnityEngine;
using UnityEngine.UI;

public class Switch : BaseMonoBehaviour, IDataPersistence
{
    [SerializeField] private VibratorDatabase _data;
    [SerializeField] private Image _on;
    [SerializeField] private Image _off;
    [SerializeField] private Image _handle;
    [SerializeField] private Animator _animatorHandle;

    private bool _active = true;

    private void Awake()
    {
        RegisterData();
    }

    private void Start()
    {
        _active = _data.Vibration;
        UpdateSwitch();
    }

    public void ON()
    {
        _active = false;
        _data.Vibration = _active;
        UpdateSwitch();
    }

    public void OFF()
    {
        _active = true;
        _data.Vibration = _active;
        UpdateSwitch();
    }

    public void Handle()
    {
        _active = !_active;
        _data.Vibration = _active;
        UpdateSwitch();
    }

    private void UpdateSwitch()
    {
        if(_active)
        {
            _animatorHandle.SetBool("Active", _active);
            _on.gameObject.SetActive(_active);
            _off.gameObject.SetActive(!_active);
        } else
        {
            _animatorHandle.SetBool("Active", _active);
            _on.gameObject.SetActive(_active);
            _off.gameObject.SetActive(!_active);
        }
    }

    protected override void SetDefaultValue()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        _on = transform.Find("ON").GetComponent<Image>();
        _off = transform.Find("OFF").GetComponent<Image>();
        _handle = transform.Find("Handle").GetComponent<Image>();
    }

    public void LoadData(GameData data)
    {}

    public void SaveData(GameData data)
    {
        data.Vibration = _data.Vibration;
    }

    public void RegisterData()
    {
        DataPersistanceManager.Instance.RegisterEventDataPersistance(this);
    }
}
