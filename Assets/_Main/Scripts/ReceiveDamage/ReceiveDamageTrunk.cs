using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ReceiveDamageTrunk : BaseReceiveDamage
{
    [SerializeField] private DeadTrunk _deadTrunk;
    [SerializeField] private ItemTrunkDatabase _data;
    [SerializeField] private List<Transform> _listKnifeWood = new List<Transform>();
    private string _pathFile;
    private string _pathAsset;

    private void Start()
    {
        _maxHealth = _data.Model.Health;
        _currentHealth = _maxHealth;
    }
  
    protected override void DeadGameObject()
    {
        _deadTrunk.PlaySoundDead();
        StartCoroutine(DelayKnife());
    }

    private IEnumerator DelayKnife()
    {
        // Go to next level after 2 seconds
        yield return new WaitForSeconds(0.01f);
      
        GetComponent<CircleCollider2D>().enabled = false;

        // Trunk fragmentation
        // Fragmention 1
        _listKnifeWood.Add(transform.GetChild(0));
        transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        transform.GetChild(0).GetComponent<Rigidbody>().AddForce(200, 400, 0);
        transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(100, 100, 100);
        transform.GetChild(0).parent = null;
        // Fragmention 2
        _listKnifeWood.Add(transform.GetChild(0));
        transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        transform.GetChild(0).GetComponent<Rigidbody>().AddForce(-200, 400, 0);
        transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(-100, 100, 100);
        transform.GetChild(0).parent = null;
        // Fragmention 3
        _listKnifeWood.Add(transform.GetChild(0));
        transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        transform.GetChild(0).GetComponent<Rigidbody>().AddForce(0, 400, 0);
        transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(-200, 100, -100);
        transform.GetChild(0).parent = null;

        while (transform.childCount > 0)
        {
            _listKnifeWood.Add(transform.GetChild(0));
            transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
            transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale = 1;
            // Knives apart from Trunk
            if (!transform.GetChild(0).CompareTag("Apple"))
            {
                transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-150f, 150f), UnityEngine.Random.Range(50f, 50f)));
                transform.GetChild(0).GetComponent<Rigidbody2D>().AddTorque(UnityEngine.Random.Range(-100, 100));
            }
            transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            transform.GetChild(0).parent = null;
        }

        yield return new WaitForSeconds(2f);

        // Destroy parent
        Destroy(this.transform.gameObject);

        // Child
        foreach (var item in _listKnifeWood)
        {
            if(item.CompareTag("Knife"))
            {
                item.gameObject.SetActive(false);
                SpawnKnife.Instance.SetHolders(item);
            } else
            {
                Destroy(item.gameObject);
            }
        }

        GameManager.Instance.SetState(GameState.FinishLevel);
        UIManager.Instance.SetPanelState(UIManager.Instance.CurrentPanelName, StatePanel.Hide);
        UIManager.Instance.SetPanelState(PanelName.FinishLevel, StatePanel.Show);
        
    }

    protected override void SetDefaultValue()
    {
        _deadTrunk = this.GetComponent<DeadTrunk>();
#if UNITY_EDITOR
        _pathFile = "Trunk/Items/ItemTrunk00.asset";
        _pathAsset = Path.Combine(Const.Path.PATH_SCRIPTOBJECT, _pathFile);

        _data = (ItemTrunkDatabase)AssetDatabase.LoadAssetAtPath(_pathAsset, typeof(ItemTrunkDatabase));
        _maxHealth = _data.Model.Health;
#endif
    }
}