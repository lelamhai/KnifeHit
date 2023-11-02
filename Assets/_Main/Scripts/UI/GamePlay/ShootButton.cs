using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootButton : BaseButton
{
    protected override void OnClickButton()
    {
        InputManager.Instance.Shooting();
    }
}
