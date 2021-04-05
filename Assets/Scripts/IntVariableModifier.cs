using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntVariableModifier : MonoBehaviour
{
    public IntVariable targetIntVariable;

    public void AddIntVariable(int amount)
    {
        targetIntVariable.Value += amount;
    }

    public void SubtractIntVariable(int amount)
    {
        targetIntVariable.Value -= amount;
    }
}
