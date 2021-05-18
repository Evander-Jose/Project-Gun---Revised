using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatVariableDisplay : MonoBehaviour
{
    public FloatVariable variableToDisplay;
    public TextMeshProUGUI text;

    private void Update()
    {
        float currentValue = variableToDisplay.Value;
        float roundedValue = Mathf.Round(currentValue * 10f) / 10f;
        text.text = roundedValue.ToString() ;
    }
}
