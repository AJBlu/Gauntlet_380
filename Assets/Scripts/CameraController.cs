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

    private void Awake()
    {
        cameraY = transform.position.y;
        minPositionX = -10f;
        minPositionX = 10f;
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPositionX, maxPositionX), transform.position.y, transform.position.z);
        farthestPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;
        farthestPlayer.y = cameraY;
        if(farthestPlayer != null)
        {
            if (transform.position.x != farthestPlayer.x || transform.position.z != farthestPlayer.z)
            {
                transform.position = new Vector3(farthestPlayer.x, cameraY, farthestPlayer.z);
            }
        }
    }
}
