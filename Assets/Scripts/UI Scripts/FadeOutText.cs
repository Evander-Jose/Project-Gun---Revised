using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeOutText : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        StartCoroutine(FadeOutTextColor());
    }

    //Does exactly what it says:
    private IEnumerator FadeOutTextColor()
    {
        while(text.color.a > 0)
        {
            Color textColor = text.color;
            text.color = new Color(textColor.r, textColor.g, textColor.b, textColor.a - Time.deltaTime);
            yield return null;
        }
    }
}
