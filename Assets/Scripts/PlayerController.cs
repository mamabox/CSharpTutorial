using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using static UnityEngine.InputSystem.DefaultInputActions;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private bool newInputSystem = false;

    [SerializeField] private GameObject dartPrefab;
    [SerializeField] private Transform dartSpawnPoint;

    private PlayerInput _playerActions;
    private Vector2 _moveInput;

    /***
     * 
     * AWAKE, START, UPDATE
     *
     ****/

    // These functions will be called when the attached GameObject is toggled.
    private void OnEnable()
    {
        _playerActions.Player.Enable();
    }

    private void OnDisable()
    {
        _playerActions.Player.Disable();
    }

    private void Awake()
    {
       _playerActions = new PlayerInput();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame, FixedUpdate is executed at a specific rate
    void Update()
    {
        if (newInputSystem)
        {
            NewInputSystem();
        }
        else
        {
            OldInputSystem();
        }
    }

    private void NewInputSystem()
    {
        _moveInput = _playerActions.Player.Move.ReadValue<Vector2>();
        _moveInput.y = 0f;
        gameObject.transform.Translate(Time.deltaTime * speed * _moveInput);
    }

    /***
     * 
     * ACTIONS
     *
     ****/

    private void OnFire()
    {
        //Debug.Log("FIRE!");
        Instantiate(dartPrefab, dartSpawnPoint.position, dartSpawnPoint.rotation);
    }

    /***
     * 
     * OLD INPUT SYSTEM
     *
     ****/

    private void OldInputSystem()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //gameObject.transform.Translate(-Time.deltaTime*speed,0,0);
            gameObject.transform.Translate(Time.deltaTime * speed * Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Time.deltaTime * speed * Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dartPrefab,dartSpawnPoint.position, dartSpawnPoint.rotation);
        }
    }
}
