using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tracer : MonoBehaviour
{
    public UnityEvent OnTracerEnabled;
    private void OnEnable()
    {
        OnTracerEnabled.Invoke();
    }
}
