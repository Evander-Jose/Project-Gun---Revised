using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//As of now, this Scriptable Object only exists to save the values of player-related settings:
[CreateAssetMenu(menuName = "Player Settings")]
public class PlayerSettings : ScriptableObject
{
    public FloatVariable x_mouse_sens;
    public FloatVariable y_mouse_sens;
    private const string x_mouse_sens_key = "X_MOUSE_SENS";
    private const string y_mouse_sens_key = "Y_MOUSE_SENS";

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(x_mouse_sens_key, x_mouse_sens.Value);
        PlayerPrefs.SetFloat(y_mouse_sens_key, y_mouse_sens.Value);
        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        if(PlayerPrefs.HasKey(x_mouse_sens_key))
        {
            x_mouse_sens.Value = PlayerPrefs.GetFloat(x_mouse_sens_key);
        }

        if(PlayerPrefs.HasKey(y_mouse_sens_key))
        {
            y_mouse_sens.Value = PlayerPrefs.GetFloat(y_mouse_sens_key);
        }
    }

    public void RevertSettings()
    {
        x_mouse_sens.Value = x_mouse_sens.DefaultValue;
        y_mouse_sens.Value = y_mouse_sens.DefaultValue;
        SaveSettings();
    }
}
