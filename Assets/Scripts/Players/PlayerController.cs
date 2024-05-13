using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private MeshRenderer handRenderer;
    [SerializeField] private GameObject projectilePrefab;
    private MeshRenderer selfRenderer;
    private Vector3 moveInput;
    private Rigidbody rb;
    private Collider playerCollider;
    private float speed;
    private float rotationSpeed = 720f;
    private float shotDelay = 0.5f;
    private bool isShooting = false;
    private PlayerGeneric playerData;
    public bool hasCharacter;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
        playerData = gameObject.GetComponent<PlayerGeneric>();
        selfRenderer = gameObject.GetComponent<MeshRenderer>();
        transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        //This is test code to see if join works as should
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        speed = 0;
        playerCollider.isTrigger = true;
        gameObject.tag = "Untagged";
        rb.useGravity = false;
    }
    public void OnMovePerformed(InputAction.CallbackContext value)
    {
        moveInput = new Vector3(value.ReadValue<Vector2>().x, 0, value.ReadValue<Vector2>().y);
    }
    public void OnShootPerformed(InputAction.CallbackContext value)
    {
        if(hasCharacter)
        {
            if (isShooting == false)
            {
                Debug.Log("Shooting");
                //Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                StartCoroutine(ShootingTimer());
            }
        }
    }
    public void OnMagicPerformed(InputAction.CallbackContext value)
    {
        playerData.OnMagic();
    }
    public void OnJoinElf(InputAction.CallbackContext value)
    {
        if(hasCharacter == false)
        {
            //Adds ElfSO to Player Generic
            if (PlayerJoin.Instance.elfJoined == false)
            {
                PlayerJoin.Instance.elfJoined = true;
                hasCharacter = true;
                transform.parent = null;
                this.GetComponent<MeshRenderer>().material.color = Color.green;
                playerCollider.isTrigger = false;
                gameObject.tag = "Player";
                rb.useGravity = true;
                selfRenderer.enabled = true;
                handRenderer.enabled = true;
                playerData.playerData = PlayerJoin.Instance.playerClasses[0];
                playerData.assignPlayerAttributes();
                speed = playerData.playerData.RunningSpeed;

            }
        }
    }
    public void OnJoinWarrior(InputAction.CallbackContext value)
    {
        if(hasCharacter == false)
        {
            //Adds WarriorSO to Player Generic
            if (PlayerJoin.Instance.warriorJoined == false)
            {
                PlayerJoin.Instance.warriorJoined = true;
                hasCharacter = true;
                transform.parent = null;
                this.GetComponent<MeshRenderer>().material.color = Color.yellow;
                playerCollider.isTrigger = false;
                gameObject.tag = "Player";
                rb.useGravity = true;
                selfRenderer.enabled = true;
                handRenderer.enabled = true;
                playerData.playerData = PlayerJoin.Instance.playerClasses[1];
                playerData.assignPlayerAttributes();
                speed = playerData.playerData.RunningSpeed;
            }
        }
    }
    public void OnJoinWizard(InputAction.CallbackContext value)
    {
        if(hasCharacter == false)
        {
            //Adds WizardSO to Player Generic
            if (PlayerJoin.Instance.wizardJoined == false)
            {
                PlayerJoin.Instance.wizardJoined = true;
                hasCharacter = true;
                transform.parent = null;
                this.GetComponent<MeshRenderer>().material.color = Color.blue;
                playerCollider.isTrigger = false;
                gameObject.tag = "Player";
                selfRenderer.enabled = true;
                handRenderer.enabled = true;
                rb.useGravity = true;
                playerData.playerData = PlayerJoin.Instance.playerClasses[2];
                playerData.assignPlayerAttributes();
                speed = playerData.playerData.RunningSpeed;
            }
        }
    }
    public void OnJoinValkyrie(InputAction.CallbackContext value)
    {
        if(hasCharacter == false)
        {
            //Adds ValkyrieSO to Player Generic
            if (PlayerJoin.Instance.valkyrieJoined == false)
            {
                PlayerJoin.Instance.valkyrieJoined = true;
                hasCharacter = true;
                transform.parent = null;
                this.GetComponent<MeshRenderer>().material.color = Color.red;
                playerCollider.isTrigger = false;
                gameObject.tag = "Player";
                selfRenderer.enabled = true;
                handRenderer.enabled = true;
                rb.useGravity = true;
                playerData.playerData = PlayerJoin.Instance.playerClasses[3];
                playerData.assignPlayerAttributes();
                speed = playerData.playerData.RunningSpeed;
            }
        }
    }
    private void FixedUpdate()
    {
        if(hasCharacter)
        {
            rb.velocity = moveInput * speed;
        }
        if(moveInput != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveInput, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    IEnumerator ShootingTimer()
    {
        isShooting = true;
        speed = 0;
        yield return new WaitForSeconds(shotDelay);
        isShooting = false;
        speed = playerData.playerData.RunningSpeed;
    }
}
