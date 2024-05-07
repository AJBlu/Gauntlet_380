using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Material mat;
    Color startcolor, endcolor;
    bool reverse, cycle;

    private void Awake()
    {
        startcolor = Color.gray;
        endcolor = Color.white;
        reverse = false;
        cycle = false;
    }
    private void Update()
    {
        if (!cycle)
        {
            if (!reverse)
                StartCoroutine(whiteFlash(startcolor, endcolor));
            else
                StartCoroutine(whiteFlash(endcolor, startcolor));
        }
    }
    IEnumerator whiteFlash(Color start, Color end)
    {
        float currentTime = 0;
        float cycleTime = 1.25f;
        cycle = true;
        while (currentTime < cycleTime)
        {
            currentTime += Time.deltaTime;
            float ratio = currentTime / cycleTime;
            mat.color = Color.Lerp(start, end, ratio);
            yield return null;

        }
        reverse = !reverse;
        cycle = false;

    }

}
