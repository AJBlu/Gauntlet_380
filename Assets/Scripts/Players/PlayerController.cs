using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private MeshRenderer _handRenderer;
    [SerializeField] private GameObject _projectilePrefab;
    private MeshRenderer _selfRenderer;
    private Vector3 _moveInput;
    private Vector3 _lastMovement;
    private Rigidbody _rb;
    private Collider _playerCollider;
    private float _speed;
    private float _rotationSpeed = 1440f;
    private float _shotDelay = 0.25f;
    private bool _isShooting = true;
    private PlayerGeneric _playerData;
    private Transform _parentTransform;
    public bool hasCharacter;
    public bool canRejoin;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerCollider = GetComponent<Collider>();
        _playerData = gameObject.GetComponent<PlayerGeneric>();
        _selfRenderer = gameObject.GetComponent<MeshRenderer>();
        //transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        //This is test code to see if join works as should
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        _speed = 0;
        _playerCollider.isTrigger = true;
        gameObject.tag = "Untagged";
        _rb.useGravity = false;
        _parentTransform = transform.parent;
    }
    public void OnMovePerformed(InputAction.CallbackContext value)
    {
        if(canRejoin == false && _playerData.isDead == false)
        {
            _moveInput = new Vector3(value.ReadValue<Vector2>().x, 0, value.ReadValue<Vector2>().y);
            if (_moveInput != Vector3.zero)
            {
                _lastMovement = _moveInput;
            }
        }
    }
    public void OnShootPerformed(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            if (Time.timeScale == 1)
            {
                if (hasCharacter && _playerData.isDead == false)
                {
                    if (_isShooting == false)
                    {
                        Debug.Log("Shooting");
                        GameObject shot;
                        shot = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
                        shot.GetComponent<Projectile>().SetShotAttributes(_playerData.playerData.ShotStrength, _playerData.playerData.shotSpeed, _lastMovement, this.gameObject);
                        StartCoroutine(ShootingTimer());
                    }
                }
            }
        }
    }
    public void OnMagicPerformed(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            if (hasCharacter && _playerData.isDead == false)
            {
                if (Time.timeScale == 1f)
                {
                    if (_playerData.inventory._potions > 0)
                    {
                        _playerData.OnMagic();
                        string prompt = "Magic potions affect everything on screen.";
                        StartCoroutine(GameManager.Instance.PromptPopUp(prompt));
                    }
                }
            }
        }
    }
    public void OnJoinElf(InputAction.CallbackContext value)
    {
        if(hasCharacter == false && canRejoin == false)
        {
            //Adds ElfSO to Player Generic
            if (GameManager.Instance.elfJoined == false)
            {
                GameManager.Instance.elfJoined = true;
                hasCharacter = true;
                transform.parent = null;
                this.GetComponent<MeshRenderer>().material.color = Color.green;
                _playerCollider.isTrigger = false;
                gameObject.tag = "Player";
                _rb.useGravity = true;
                _selfRenderer.enabled = true;
                _handRenderer.enabled = true;
                _playerData.hero = Hero.ELF;
                _playerData.playerData = GameManager.Instance.playerClasses[0];
                GameManager.Instance.ElfJoined();
                _playerData.assignPlayerAttributes();
                _playerData.hasSpawnedOnce = true;
                _speed = _playerData.playerData.RunningSpeed;
                _isShooting = false;
            }
        }
        if (canRejoin && _playerData.hero == Hero.ELF)
        {
            GameManager.Instance.elfJoined = true;
            hasCharacter = true;
            transform.parent = null;
            this.GetComponent<MeshRenderer>().material.color = Color.green;
            _playerCollider.isTrigger = false;
            gameObject.tag = "Player";
            _rb.useGravity = true;
            _selfRenderer.enabled = true;
            _handRenderer.enabled = true;
            _playerData.hero = Hero.ELF;
            _playerData.playerData = GameManager.Instance.playerClasses[0];
            GameManager.Instance.ElfJoined();
            _playerData.assignPlayerAttributes();
            _playerData.hasSpawnedOnce = true;
            _speed = _playerData.playerData.RunningSpeed;
            _isShooting = false;
            canRejoin = false;
            _playerData.isDead = false;
        }
    }
    public void OnJoinWarrior(InputAction.CallbackContext value)
    {
        if(hasCharacter == false && canRejoin == false)
        {
            //Adds WarriorSO to Player Generic
            if (GameManager.Instance.warriorJoined == false)
            {
                GameManager.Instance.warriorJoined = true;
                hasCharacter = true;
                transform.parent = null;
                this.GetComponent<MeshRenderer>().material.color = Color.red;
                _playerCollider.isTrigger = false;
                gameObject.tag = "Player";
                _rb.useGravity = true;
                _selfRenderer.enabled = true;
                _handRenderer.enabled = true;
                _playerData.hero = Hero.WARRIOR;
                _playerData.playerData = GameManager.Instance.playerClasses[1];
                GameManager.Instance.WarriorJoined();
                _playerData.assignPlayerAttributes();
                _playerData.hasSpawnedOnce = true;
                _speed = _playerData.playerData.RunningSpeed;
                _isShooting = false;
            }
        }
        if(canRejoin && _playerData.hero == Hero.WARRIOR)
        {
            GameManager.Instance.warriorJoined = true;
            hasCharacter = true;
            transform.parent = null;
            this.GetComponent<MeshRenderer>().material.color = Color.red;
            _playerCollider.isTrigger = false;
            gameObject.tag = "Player";
            _rb.useGravity = true;
            _selfRenderer.enabled = true;
            _handRenderer.enabled = true;
            _playerData.hero = Hero.WARRIOR;
            _playerData.playerData = GameManager.Instance.playerClasses[1];
            GameManager.Instance.WarriorJoined();
            _playerData.assignPlayerAttributes();
            _playerData.hasSpawnedOnce = true;
            _speed = _playerData.playerData.RunningSpeed;
            _isShooting = false;
            canRejoin = false;
            _playerData.isDead = false;
        }
    }
    public void OnJoinWizard(InputAction.CallbackContext value)
    {
        if(hasCharacter == false && canRejoin == false)
        {
            //Adds WizardSO to Player Generic
            if (GameManager.Instance.wizardJoined == false)
            {
                GameManager.Instance.wizardJoined = true;
                hasCharacter = true;
                transform.parent = null;
                this.GetComponent<MeshRenderer>().material.color = Color.yellow;
                _playerCollider.isTrigger = false;
                gameObject.tag = "Player";
                _rb.useGravity = true;
                _selfRenderer.enabled = true;
                _handRenderer.enabled = true;
                _playerData.hero = Hero.MAGE;
                _playerData.playerData = GameManager.Instance.playerClasses[2];
                GameManager.Instance.WizardJoined();
                _playerData.assignPlayerAttributes();
                _playerData.hasSpawnedOnce = true;
                _speed = _playerData.playerData.RunningSpeed;
                _isShooting = false;
            }
        }
        if(canRejoin && _playerData.hero == Hero.MAGE)
        {
            GameManager.Instance.wizardJoined = true;
            hasCharacter = true;
            transform.parent = null;
            this.GetComponent<MeshRenderer>().material.color = Color.yellow;
            _playerCollider.isTrigger = false;
            gameObject.tag = "Player";
            _rb.useGravity = true;
            _selfRenderer.enabled = true;
            _handRenderer.enabled = true;
            _playerData.hero = Hero.MAGE;
            _playerData.playerData = GameManager.Instance.playerClasses[2];
            GameManager.Instance.WizardJoined();
            _playerData.assignPlayerAttributes();
            _playerData.hasSpawnedOnce = true;
            _speed = _playerData.playerData.RunningSpeed;
            _isShooting = false;
            canRejoin = false;
            _playerData.isDead = false;
        }
    }
    public void OnJoinValkyrie(InputAction.CallbackContext value)
    {
        if(hasCharacter == false && canRejoin == false)
        {
            //Adds ValkyrieSO to Player Generic
            if (GameManager.Instance.valkyrieJoined == false)
            {
                GameManager.Instance.valkyrieJoined = true;
                hasCharacter = true;
                transform.parent = null;
                this.GetComponent<MeshRenderer>().material.color = Color.blue;
                _playerCollider.isTrigger = false;
                gameObject.tag = "Player";
                _rb.useGravity = true;
                _selfRenderer.enabled = true;
                _handRenderer.enabled = true;
                _playerData.hero = Hero.VALKYRIE;
                _playerData.playerData = GameManager.Instance.playerClasses[3];
                GameManager.Instance.ValkyrieJoined();
                _playerData.assignPlayerAttributes();
                _playerData.hasSpawnedOnce = true;
                _speed = _playerData.playerData.RunningSpeed;
                _isShooting = false;
            }
        }
        if(canRejoin && _playerData.hero == Hero.VALKYRIE) 
        {
            GameManager.Instance.valkyrieJoined = true;
            hasCharacter = true;
            transform.parent = null;
            this.GetComponent<MeshRenderer>().material.color = Color.blue;
            _playerCollider.isTrigger = false;
            gameObject.tag = "Player";
            _rb.useGravity = true;
            _selfRenderer.enabled = true;
            _handRenderer.enabled = true;
            _playerData.hero = Hero.VALKYRIE;
            _playerData.playerData = GameManager.Instance.playerClasses[3];
            GameManager.Instance.ValkyrieJoined();
            _playerData.assignPlayerAttributes();
            _playerData.hasSpawnedOnce = true;
            _speed = _playerData.playerData.RunningSpeed;
            _isShooting = false;
            canRejoin = false;
            _playerData.isDead = false;
        }
    }
    public void DisablePlayer()
    {
        if(_playerData.hero == Hero.ELF)
        {
            GameManager.Instance.ElfDeadPrompt();
        }
        if (_playerData.hero == Hero.WARRIOR)
        {
            GameManager.Instance.WarriorDeadPrompt();
        }
        if (_playerData.hero == Hero.MAGE)
        {
            GameManager.Instance.WizardDeadPrompt();
        }
        if (_playerData.hero == Hero.VALKYRIE)
        {
            GameManager.Instance.ValkyrieDeadPrompt();
        }
        hasCharacter = false;
        gameObject.tag = "Untagged";
        transform.parent = _parentTransform;
        //transform.position = Vector3.zero;
        _rb.useGravity = false;
        _playerCollider.isTrigger = true;
        _selfRenderer.enabled = false;
        _handRenderer.enabled = false;
        canRejoin = true;
    }
    private void FixedUpdate()
    {
        if(_playerData.isDead)
        {
            _rb.velocity = Vector3.zero;
        }
        if (hasCharacter)
        {
            _rb.velocity = _moveInput * _speed;
        }
        if(_moveInput != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(_moveInput, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed);
        }
    }
    IEnumerator ShootingTimer()
    {
        _isShooting = true;
        _speed = 0;
        yield return new WaitForSeconds(_shotDelay);
        _isShooting = false;
        _speed =_playerData.playerData.RunningSpeed;
    }
}
