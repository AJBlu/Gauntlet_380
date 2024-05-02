using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    private Camera MainCamera;
    private Vector3 maxScreenBounds;
    private Vector3 minScreenBounds;
    private float objectWidth;
    private void Awake()
    {
        MainCamera = Camera.main;
    }
    void Start()
    {
        objectWidth = transform.GetComponent<MeshRenderer>().bounds.extents.x;
    }
    private void Update()
    {
        maxScreenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width - Screen.width * 0.2f, Screen.height, transform.position.z));
        minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    }
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + objectWidth, maxScreenBounds.x - objectWidth), transform.position.y, Mathf.Clamp(transform.position.z, minScreenBounds.z + objectWidth, maxScreenBounds.z - objectWidth));
    }
}
