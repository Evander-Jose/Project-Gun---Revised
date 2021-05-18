using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatVariableSlider : MonoBehaviour
{
    public Slider slider;
    public FloatVariable floatVariableToAssign;

    private void OnEnable()
    {
        slider.value = floatVariableToAssign.Value;
    }

    private void Update()
    {
        floatVariableToAssign.Value = slider.value;
    }
}
