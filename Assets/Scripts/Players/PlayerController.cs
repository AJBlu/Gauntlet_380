using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerControls controls;
    private Vector3 moveInput;
    private Rigidbody rb;
    public int speed;

    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        controls.Enable();
        controls.Player1.Move.performed += OnMovePerformed;
        controls.Player1.Move.canceled += OnMoveCancelled;
        controls.Player1.Shoot.performed += OnShootPerformed;
    }
    private void OnDisable()
    {
        controls.Disable();
        controls.Player1.Move.performed -= OnMovePerformed;
        controls.Player1.Move.canceled -= OnMoveCancelled;
        controls.Player1.Shoot.performed -= OnShootPerformed;
    }
    private void OnMovePerformed(InputAction.CallbackContext value)
    {
        moveInput = new Vector3(value.ReadValue<Vector2>().x, 0, value.ReadValue<Vector2>().y);
    }
    private void OnMoveCancelled(InputAction.CallbackContext value)
    {
        moveInput = Vector2.zero;
    }
    private void OnShootPerformed(InputAction.CallbackContext value)
    {
        Debug.Log("Shooting");
    }
    private void FixedUpdate()
    {
        rb.velocity = moveInput * speed;
    }
}
