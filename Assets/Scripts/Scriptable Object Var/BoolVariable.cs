using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object Variable/Bool Variable")]
public class BoolVariable : ScriptableObject
{
    private bool currentValue;
    [SerializeField] private bool defaultValue;

    public bool CurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            currentValue = value;
        }
    }

    private void OnEnable()
    {
        currentValue = defaultValue;
    }
}
