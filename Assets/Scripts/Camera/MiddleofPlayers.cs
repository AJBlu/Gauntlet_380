using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MiddleofPlayers : MonoBehaviour
{
    private GameObject[] playerTransforms;
    private float totalX;
    private float totalY;
    private float totalZ;
    private float centerX;
    private float centerZ;
    private float distanceX;
    private float distanceZ;
    private float tempDistX;
    private float tempDistZ;
    private void Update()
    {
        //This is just a test way to get the players will be changed when we have the fuction to add new players in when clicking a button
        playerTransforms = GameObject.FindGameObjectsWithTag("Player");
        if (playerTransforms.Length != 0)
        {
            //Sets the totals to 0 since this is constantly updating we don't want the total to keep being added to.
            totalX = 0;
            totalZ = 0;
            for (int i = 0; i < playerTransforms.Length; i++)
            {
                totalX += playerTransforms[i].transform.position.x;
                totalZ += playerTransforms[i].transform.position.z;
            }
            //Calculated center of players by dividing thier position by amount of players
            centerX = totalX / playerTransforms.Length;
            centerZ = totalZ / playerTransforms.Length;
            //Calculates distance of players so that it can stop the middle from moving if players are to far from each other so that they can't attempt to leave each other
            for (int i = 0; i < playerTransforms.Length; i++)
            {
                for (int j = i + 1; j < playerTransforms.Length; j++)
                {
                    tempDistX = Mathf.Abs(playerTransforms[j].transform.position.x - playerTransforms[i].transform.position.x);
                    if (tempDistX > distanceX)
                    {
                        distanceX = tempDistX;
                    }
                    tempDistZ = Mathf.Abs(playerTransforms[j].transform.position.z - playerTransforms[i].transform.position.z);
                    if (tempDistZ > distanceZ)
                    {
                        distanceZ = tempDistZ;
                    }
                }
            }
            //Distance may be changed later or made with a changable variable set to 10 for testing purposes.
            if (distanceX < 10 && distanceZ < 10)
            {
                transform.position = new Vector3(centerX, transform.position.y, centerZ);
            }
            //If statements added to make more smooth transitions as otherwise moving in diagonals would cause it to hard cut
            if (distanceX > 10 && distanceZ < 10)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, centerZ);
            }
            if (distanceX < 10 && distanceZ > 10)
            {
                transform.position = new Vector3(centerX, transform.position.y, transform.position.z);
            }
            //Sets distance to 0 as in update it will run through the for statements again to check the distance once more and allow the players to move if need be.
            distanceX = 0;
            distanceZ = 0;
        }
    }
}
