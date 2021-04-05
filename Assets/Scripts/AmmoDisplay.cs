using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AmmoDisplay : MonoBehaviour
{
    public IntVariable ammoVariable;
    public TextMeshProUGUI text;

    private void Update()
    {
        text.text = ammoVariable.Value.ToString() + "/" + ammoVariable.DefaultValue.ToString();
    }
}
