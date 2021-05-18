using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Loads player settings at awake
public class SettingsLoader : MonoBehaviour
{
    public PlayerSettings settings;
    private void Awake()
    {
        settings.LoadSettings();
    }
}
