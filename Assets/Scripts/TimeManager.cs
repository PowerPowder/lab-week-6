using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    int lastTime = 0;

    private void Update()
    {
        if ((int) Time.time >= lastTime)
        {
            Debug.Log(lastTime);
            lastTime++;
        }
    }
}
