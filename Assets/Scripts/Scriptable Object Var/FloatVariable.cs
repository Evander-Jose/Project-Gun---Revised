using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object Variable/Float Variable")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] private float defaultValue;
    private float currentValue;
    public float Value
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
    public float DefaultValue
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
