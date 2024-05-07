using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Warlock : Fighter_Generic
{
    bool isRunning;
    private void Start()
    {
        isRunning = false;
    }
    new private void Update()
    {
        base.Update();
        //Debug.Log("Start Invisibility");
        if(!isRunning)
            StartCoroutine("InvisibilityFlicker");
    }

    private IEnumerator InvisibilityFlicker()
    {
        isRunning = true;
        print("Rolling!");
        visible();
        //quarter chance every five seconds
        if(Random.Range(0f,1f) < .25)
        {
            turnInvisible();
        }

        yield return new WaitForSeconds(2f);
        isRunning = false;

    }

    private void visible()
    {
        this.GetComponent<MeshRenderer>().enabled = true;
        canZap = true;
        canShoot = true;
        canFight = true;

    }

    private void turnInvisible()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        canZap = false;
        canShoot = false;
        canFight = false;

    }
}
