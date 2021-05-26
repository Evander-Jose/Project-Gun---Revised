using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class SpeedrunTimerDisplay : MonoBehaviour
{
    public FloatVariable speedrunSeconds;
    public TextMeshProUGUI text;

    private void Update()
    {
        SpeedrunTime speedrunTime = new SpeedrunTime(speedrunSeconds.Value);
        text.text = speedrunTime.minutes + ":" + speedrunTime.seconds + ":" + speedrunTime.milliSeconds;
    }
}
