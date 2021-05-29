using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedrunLeaderboard : MonoBehaviour
{
    public FloatVariable fastestTime;
    public FloatVariable currentFinishedTime;

    private const string fastestTimeKey = "FASTEST_TIME";

    public void SaveNewFastestTime()
    {
        bool currentIsFaster = currentFinishedTime.Value < fastestTime.Value && currentFinishedTime.Value > 0;
        if(currentIsFaster)
        {
            PlayerPrefs.SetFloat(fastestTimeKey, currentFinishedTime.Value);
            PlayerPrefs.Save();

            fastestTime.Value = LoadSavedTime();
        }
    }

    public void ResetFastestTime()
    {
        PlayerPrefs.SetFloat(fastestTimeKey, fastestTime.DefaultValue);
        PlayerPrefs.Save();

        fastestTime.Value = LoadSavedTime();     
    }

    public void UpdateFastestTime()
    {
        fastestTime.Value = LoadSavedTime();
    }

    private float LoadSavedTime()
    {
        if (PlayerPrefs.HasKey(fastestTimeKey))
            return PlayerPrefs.GetFloat(fastestTimeKey);
        else
            return 0;
    }
}
