using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 playersMiddle;
    private float cameraY;
    private float minPositionX;
    private float maxPositionX;
    private float minPositionZ;
    private float maxPositionZ;

    private void Awake()
    {
        cameraY = transform.position.y;
        //This needs to be changed to whatever the levels size is
        minPositionX = -4f;
        maxPositionX = 28f;
        minPositionZ = -7.5f;
        maxPositionZ = 32.5f;
    }

    private void Update()
    {
        //This is just a test way to get the middle will be changed later when game is more complete
        playersMiddle = GameObject.FindGameObjectWithTag("Middle").transform.position;
        playersMiddle.y = cameraY;
        if (playersMiddle != null)
        {
            if (transform.position.x != playersMiddle.x || transform.position.z != playersMiddle.z)
            {
                //Clamps camera at the edge of 
                transform.position = new Vector3(Mathf.Clamp(playersMiddle.x, minPositionX, maxPositionX), cameraY, Mathf.Clamp(playersMiddle.z, minPositionZ, maxPositionZ));
            }
        }
    }
}
