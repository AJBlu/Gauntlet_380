using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private List<Transform> playerTransforms = new List<Transform>();
    [SerializeField] private Vector3 farthestPlayer;
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
        farthestPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;
        farthestPlayer.y = cameraY;
        if (farthestPlayer != null)
        {
            if (transform.position.x != farthestPlayer.x || transform.position.z != farthestPlayer.z)
            {
                transform.position = new Vector3(Mathf.Clamp(farthestPlayer.x, minPositionX, maxPositionX), cameraY, Mathf.Clamp(farthestPlayer.z, minPositionX, maxPositionX));
            }
        }
    }
}
