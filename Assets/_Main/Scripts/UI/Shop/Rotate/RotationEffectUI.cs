using UnityEngine;

public class RotationEffectUI : BaseMonoBehaviour
{
    [SerializeField] private float _speed = 0;
 
    private void FixedUpdate()
    {
        this.transform.Rotate(new Vector3(0, 0, _speed * Time.fixedDeltaTime));
    }

    protected override void SetDefaultValue()
    {}
}