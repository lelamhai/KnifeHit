public class GamePlayUI : BaseMonoBehaviour
{
    private void OnEnable()
    {
        UIManager.Instance.clear();
    }

    protected override void SetDefaultValue()
    {}
}