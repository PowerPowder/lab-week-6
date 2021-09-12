using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    Transform[] transformArray;

    const float moveWait = 2.0f;
    float nextTime = moveWait;

    const float scaleWait = 4.0f;

    bool isRotating = false;

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
            ResetTime();

        if (Input.GetKeyDown(KeyCode.Escape) && !isRotating)
            StartCoroutine(RotateObjects(Random.Range(0.25f, 0.75f)));
    }

    private void ResetTime()
    {
        timer = 0;
        lastTime = 0;
        nextTime = moveWait;

        CancelInvoke("ScaleObjects");
        InvokeRepeating("ScaleObjects", scaleWait, scaleWait);
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

    private void ScaleObjects()
    {
        Vector3 ls0 = transformArray[0].localScale;
        Vector3 ls1 = transformArray[1].localScale;

        float multValue;
        if (ls0.x > 1.5f || ls1.x > 1.5f)
            multValue = 1f / 1.2f;
        else
            multValue = 1.2f;

        transformArray[0].localScale = ls0 * multValue;
        transformArray[1].localScale = ls1 * multValue;
    }

    IEnumerator RotateObjects(float randomDelay)
    {
        isRotating = true;

        for (int i = 0; i < 4; i++)
        {
            transformArray[0].Rotate(0f, 0f, 90f);
            transformArray[1].Rotate(0f, 0f, 90f);
            yield return new WaitForSeconds(randomDelay);
            Debug.Log("don m8");
        }

        isRotating = false;
    }
}
