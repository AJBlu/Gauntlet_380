using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerControls controls;
    private Vector2 moveInput;
    public int speed;

    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        objectWidth = transform.GetComponent<MeshRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<MeshRenderer>().bounds.extents.y; //extents = size of height / 2
    }
    private void Update()
    {
        //Guide to help fix this mess https://discussions.unity.com/t/keeping-player-within-screenbounds-with-moving-camera-vertical-shooter/228440/2
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        Debug.Log(screenBounds);
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward *Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth), transform.position.y, transform.position.z);
    }
}
