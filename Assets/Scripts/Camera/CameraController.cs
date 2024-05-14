using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 _playersMiddle;
    private float _cameraY;
    private float _minPositionX;
    private float _maxPositionX;
    private float _minPositionZ;
    private float _maxPositionZ;

    private void Awake()
    {
        _cameraY = transform.position.y;
        //This needs to be changed to whatever the levels size is also based on screen size as this affects it(maybe add blank boarder on levels to make up for this)
        _minPositionX = -4f;
        _maxPositionX = 30f;
        _minPositionZ = -36.5f;
        _maxPositionZ = 32.5f;
    }

    private void LateUpdate()
    {
        _playersMiddle = GameObject.FindGameObjectWithTag("Middle").transform.position;
        if (_playersMiddle != null)
        {
            _playersMiddle.y = _cameraY;
            if (transform.position.x != _playersMiddle.x || transform.position.z != _playersMiddle.z)
            {
                //Clamps camera at the edge of level
                transform.position = new Vector3(Mathf.Clamp(_playersMiddle.x, _minPositionX, _maxPositionX), _cameraY, Mathf.Clamp(_playersMiddle.z, _minPositionZ, _maxPositionZ));
            }
        }
    }
}
