using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public FloatVariable playerHealthVariable;
    public FloatVariable maxPlayerHealthVariable;
    public Slider healthBarSlider;

    private void Update()
    {
        healthBarSlider.value = playerHealthVariable.Value / maxPlayerHealthVariable.Value;
    }
}
