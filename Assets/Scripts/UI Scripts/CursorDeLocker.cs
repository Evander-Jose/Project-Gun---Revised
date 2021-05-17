using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorDeLocker : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
