using System.Collections;
using UnityEngine;

public class ReceiveDamageWheel : BaseReceiveDamage
{
    [SerializeField] private DeadWheel _deadWheel;

    private void Start()
    {
        GameManager.Instance.SetupLevel(_maxHealth);
    }

    private void OnEnable()
    {
        GameManager.Instance._SetupLevel += SetupLevel;
        _currentHealth = _maxHealth;
    }

    private void OnDisable()
    {
        GameManager.Instance._SetupLevel += SetupLevel;
    }

    private void SetupLevel(int count)
    {
        _maxHealth = count;
    }
  
    protected override void DeadGameObject()
    {
        StartCoroutine(DeplayKnife());
    }

    private IEnumerator DeplayKnife()
    {
        // Go to next level after 2 seconds
        yield return new WaitForSeconds(0.01f);
        //_deadWheel.PlaySoundDead();
        //GameManager.Instance.SetState(GameState.FinishLevel);
        //Destroy(gameObject);
        GetComponent<CircleCollider2D>().enabled = false;

        // Trunk fragmentation
        // Fragmention 1
        transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        transform.GetChild(0).GetComponent<Rigidbody>().AddForce(200, 400, 0);
        transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(100, 100, 100);
        transform.GetChild(0).parent = null;
        // Fragmention 2
        transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        transform.GetChild(0).GetComponent<Rigidbody>().AddForce(-200, 400, 0);
        transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(-100, 100, 100);
        transform.GetChild(0).parent = null;
        // Fragmention 3
        transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        transform.GetChild(0).GetComponent<Rigidbody>().AddForce(0, 400, 0);
        transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(-200, 100, -100);
        transform.GetChild(0).parent = null;

        while (transform.childCount > 0)
        {

            // Knives apart from Trunk
            transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
            transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-150f, 150f), UnityEngine.Random.Range(50f, 50f)));
            transform.GetChild(0).GetComponent<Rigidbody2D>().AddTorque(UnityEngine.Random.Range(-100, 100));
            transform.GetChild(0).parent = null;
        }

        yield return new WaitForSeconds(1f);
        // stop


    }

    protected override void SetDefaultValue()
    {
        _deadWheel = this.GetComponent<DeadWheel>();
    }
}