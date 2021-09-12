using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    int lastTime;
    float timer;

    void Start()
    {
        ResetTime();
    }

    void Update()
    {
        if ((int) timer >= lastTime)
        {
            Debug.Log(lastTime);
            lastTime++;
        }

        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = (Time.timeScale == 1f ? 0f : 1f);
            Debug.Log("Spacebar pressed");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetTime();
        }
    }

    private void ResetTime()
    {
        timer = 0;
        lastTime = 0;
    }
}
