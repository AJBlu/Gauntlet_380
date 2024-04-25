using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerControls controls;
    private Vector2 moveInput;
    public int speed;

    //public Camera MainCamera;
    //private Vector3 maxScreenBounds;
    //private Vector3 minScreenBounds;
    //private float objectWidth;
    //private float objectHeight;

    private void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        //objectWidth = transform.GetComponent<MeshRenderer>().bounds.extents.x; //extents = size of width / 2
        //objectHeight = transform.GetComponent<MeshRenderer>().bounds.extents.y; //extents = size of height / 2
    }
    private void Update()
    {
        //maxScreenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
        //minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        //Debug.Log(maxScreenBounds);
        //Debug.Log("Screen Height: " + Screen.height);
        //Debug.Log("Screen Min: " + minScreenBounds);
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
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + objectWidth, maxScreenBounds.x - objectWidth), transform.position.y, Mathf.Clamp(transform.position.z, minScreenBounds.z + objectWidth, maxScreenBounds.z - objectWidth));
    }
}
