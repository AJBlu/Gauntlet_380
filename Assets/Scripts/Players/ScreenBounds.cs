using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    private Camera MainCamera;
    private Vector3 _maxScreenBounds;
    private Vector3 _minScreenBounds;
    private float _objectWidth;
    private void Awake()
    {
        MainCamera = Camera.main;
    }
    void Start()
    {
        _objectWidth = transform.GetComponent<MeshRenderer>().bounds.extents.x;
    }
    private void Update()
    {
        //This is if you aren't using the UI camera
        //maxScreenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width - Screen.width, Screen.height, transform.position.z));
        //This is if you are using the UI camera
        _maxScreenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width - Screen.width * 0.2f, Screen.height, transform.position.z));
        _minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    }
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minScreenBounds.x + _objectWidth, _maxScreenBounds.x - _objectWidth), transform.position.y, Mathf.Clamp(transform.position.z, _minScreenBounds.z + _objectWidth, _maxScreenBounds.z - _objectWidth));
    }
}
