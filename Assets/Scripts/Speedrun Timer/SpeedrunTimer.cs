using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedrunTimer : MonoBehaviour
{
    public FloatVariable timeElapsedInSeconds;
    public BoolVariable paused;

    public void Update()
    {
        //If paused is true then stop ticking the clock:
        if (paused.CurrentValue == true) return;

        timeElapsedInSeconds.Value += Time.deltaTime;
    }
}
