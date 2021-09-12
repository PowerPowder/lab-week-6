﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    Transform[] transformArray;

    const float moveWait = 2.0f;
    float nextTime = moveWait;

    int lastTime;
    float timer;

    void Start()
    {
        Camera.main.orthographic = true;
        Camera.main.orthographicSize = 2.0f;
        ResetTime();
    }

    void Update()
    {
        if ((int) timer >= lastTime)
        {
            Debug.Log(lastTime);
            lastTime++;
        }

        if (timer >= nextTime)
        {
            MoveObjects((int) nextTime % (int)(2 * moveWait) == 0);
            nextTime += moveWait;
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

    private void MoveObjects(bool flipH)
    {
        Vector3 p0 = transformArray[0].position;
        Vector3 p1 = transformArray[1].position;

        if (flipH)
        {
            float temp = p0.x;
            p0.x = p1.x;
            p1.x = temp;
        }
        else
        {
            float temp = p0.y;
            p0.y = p1.y;
            p1.y = temp;
        }

        transformArray[0].position = p0;
        transformArray[1].position = p1;
    }
}
