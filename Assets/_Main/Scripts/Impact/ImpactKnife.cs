using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactKnife : BaseImpact
{
    [SerializeField] private VibratorDatabase _data;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private HitKnife _hitKnife;

    protected override void HitGameObject(Collision2D collision)
    {
        _rigidbody2D.isKinematic = true;
        if (collision.gameObject.name == this.gameObject.name)
        {
            _hitKnife.PlaySoundHit();
            _rigidbody2D.isKinematic = true;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, -2);

            if(_data.Vibration)
            {
                Handheld.Vibrate();
            }

            GameManager.Instance.SetState(GameState.GameOver);
            return;
        } 

        _rigidbody2D.velocity = Vector2.zero;
        //_rigidbody2D.isKinematic = true;

        ImpactKnife knife = transform.GetComponent<ImpactKnife>();
        knife.enabled = false;

    }

  

    protected override void SetDefaultValue()
    {
        base.SetDefaultValue();
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        _hitKnife = this.GetComponent<HitKnife>();
    }
}
