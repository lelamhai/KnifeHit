using UnityEngine;

public class StopParticleSystem : BaseMonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void Start()
    {
        var main = _particleSystem.main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }

    void OnParticleSystemStopped()
    {
        transform.gameObject.SetActive(false);
    }

    protected override void SetDefaultValue()
    {
        _particleSystem = this.transform.GetComponent<ParticleSystem>();
    }
}