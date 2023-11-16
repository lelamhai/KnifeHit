using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;

public class TrunkControl : BaseMonoBehaviour
{
    [SerializeField] private ItemTrunkDatabase _data;
    [SerializeField] private int _currentRotationElement = 0;
    [SerializeField] private bool _delay = true;

    private float _speed = 0;
    private float _duration = 0;
    private string _pathFile;
    private string _pathAsset;

    private void Start()
    {
        GameManager.Instance.SetupLevel(_data.Model.Health);
    }

    private void FixedUpdate()
    {
        this.transform.Rotate(new Vector3(0, 0, _speed * Time.fixedDeltaTime));

        if (!_delay) return;
        StartCoroutine(RandomElement());
    }

    private IEnumerator RandomElement()
    {
        _delay = false;
        _currentRotationElement = Random.Range(0, _data.Model.TrunkElement.Count);
        _speed = _data.Model.TrunkElement[_currentRotationElement].Speed;
        _duration = _data.Model.TrunkElement[_currentRotationElement].Duration;
        yield return new WaitForSeconds(_duration);
        _delay = true;
    }

    protected override void SetDefaultValue()
    {
#if UNITY_EDITOR
        _pathFile = "Trunk/Items/ItemTrunk00.asset";
        _pathAsset = Path.Combine(Const.Path.PATH_SCRIPTOBJECT, _pathFile);

        _data = (ItemTrunkDatabase)AssetDatabase.LoadAssetAtPath(_pathAsset, typeof(ItemTrunkDatabase));
#endif
    }
}