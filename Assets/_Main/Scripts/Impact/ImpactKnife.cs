using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactKnife : BaseImpact
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private HitKnife _hitKnife;

    protected override void HitGameObject(Collision2D collision)
    {
        if (collision.gameObject.name == this.gameObject.name)
        {
            _hitKnife.PlaySoundHit();
            _rigidbody2D.isKinematic = true;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, -2);

            StartCoroutine(EndGame());
            return;
        }

        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.isKinematic = true;
        Destroy(this.GetComponent<ImpactKnife>());
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.SetState(GameStates.GameOver);
    }


    protected override void LoadComponent()
    {
        base.LoadComponent();
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        _hitKnife = this.GetComponent<HitKnife>();

    }
}
