using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorDeLocker : MonoBehaviour
{
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
