using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerControls controls;
    private Vector2 moveInput;
    private void Awake()
    {

    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward *Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
    }
    public void ReceiveInput(Vector2 _moveInput)
    {
        moveInput = _moveInput;
    }
}
