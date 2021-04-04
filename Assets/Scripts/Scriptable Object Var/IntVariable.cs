using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object Variable/Int Variable")]
public class IntVariable : ScriptableObject
{
    [SerializeField] private int defaultValue;
    private int currentValue;
    public int Value
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
    public int DefaultValue
    {
        get
        {
            return defaultValue;
        }
    }

    private void OnEnable()
    {
        currentValue = defaultValue;
    }
}
