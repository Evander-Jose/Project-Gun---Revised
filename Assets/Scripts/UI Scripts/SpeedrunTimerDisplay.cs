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
        //This timer will display milliseconds, seconds and minutes.

        #region Millis
        //To calculate the milliseconds, I would just take the speedrun seconds and then subtract them by the nearest whole number:
        float millis = speedrunSeconds.Value - Mathf.Round(speedrunSeconds.Value);

        //If the seconds got rounded up, then millis would result in a negative:
        if(millis < 0)
        {
            //30.74522 - 31 = -1.74522
            //Make millis have a zero in the first digit:
            millis -= -1;

            //Then take the first two decimal places by multiplying by 100:
            millis *= 100f;

            //Then round the millis:
            millis = (float)Math.Truncate(millis);
        }
        //If the seconds got rounded down, then millis would result in 0.xxxxxxx:
        else if(millis > 0) 
        {
            //Take the first two decimal places by multiplying by 100:
            //0.12345 * 100 = 12.345
            millis *= 100f;

            //Then round the millis:
            millis = (float)Math.Truncate(millis);
        }
        #endregion

        #region Seconds

        int minutesQuotient = (int)Math.Truncate(speedrunSeconds.Value / 60f);
        int seconds = (int)Math.Truncate(speedrunSeconds.Value) - 60 * minutesQuotient;

        #endregion

        #region Minutes

        int minutes = (int)Math.Truncate(speedrunSeconds.Value / 60f);

        #endregion

        text.text = minutes.ToString() + ":" + seconds.ToString() + ":" + millis.ToString();
    }
}
