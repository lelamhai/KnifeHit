using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Format_1(float timer)
    {
        int days = (int)(timer / 864000) % 365;
        int hours = (int)(timer / 3600) % 24;
        int minute = (int)(timer / 60) % 60;
        int seconds = (int)(timer % 60);

        _text.text = "";

        if (days > 0)
        {
            _text.text += days + "d ";
        }

        if (hours > 0)
        {
            _text.text += hours + "h ";
        }

        if (minute > 0)
        {
            _text.text += minute + "m ";
        }

        if (seconds > 0)
        {
            _text.text += seconds + "s ";
        }
    }

    public void Format_Reward()
    {
        _text.text = "Claim";
    }
}
