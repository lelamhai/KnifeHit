using UnityEngine;

public class OpenFacebookButton : BaseButton
{
    protected override void OnClickButton()
    {
        Application.OpenURL("https://www.facebook.com/lelamhai/");
    }
}