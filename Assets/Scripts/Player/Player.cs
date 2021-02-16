using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float jumpSpeed;
    
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;

    public bool hasLeft;
    public bool hasRight;
    public bool hasJump;
    public bool hasDown;
    

    public event Action<bool, bool, bool> OnMovimentChanged = delegate { };
    public event Action<bool, bool, bool, bool> OnAbilitiesChanged = delegate { };

    private Vector2 _lastMovement;
    private bool _lastDirection = true;

    private void Awake()
    {
        _lastMovement = Vector2.zero;
        _playerInput = new PlayerInput();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _playerInput.terrain.jump.started += _ => Jump();

    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void FixedUpdate()
    {
        float xMovement = _playerInput.terrain.Movement.ReadValue<float>();

        if (!hasLeft && xMovement < 0)
            xMovement = 0;
            
        else if(!hasRight && xMovement > 0)
        {
            xMovement = 0;
        }
        
        Vector2 movement = new Vector2(xMovement, 0);

        bool atualDirection = xMovement > 0;


        if (_lastMovement != movement)
        {
            if (xMovement != 0)
            {
                OnMovimentChanged(movement != Vector2.zero, atualDirection, _lastDirection != atualDirection);
                _lastDirection = atualDirection;
            }
            else
            {
                OnMovimentChanged(movement != Vector2.zero, atualDirection, false);
            }
        }


        _lastMovement = movement;

        Vector3 vel = movement;
        transform.position = transform.position + vel * (Time.deltaTime * horizontalSpeed);
        //
        // var positionOffset = (Physics2D.gravity * _rigidbody2D.gravityScale) + (movement * horizontalSpeed);
        // _rigidbody2D.MovePosition(_rigidbody2D.position + positionOffset * Time.fixedDeltaTime);


    }


    public void ChangeHasLeft(bool activate)
    {
        hasLeft = activate;
        OnOnAbilitiesChanged();
    }

    public void ChangeHasRight(bool activate)
    {
        hasRight = activate;
        OnOnAbilitiesChanged();
    }

    public void ChangeHasJump(bool activate)
    {
        hasJump = activate;
        OnOnAbilitiesChanged();
    }

    public void ChangeHasDown(bool activate)
    {
        hasDown = activate;
        OnOnAbilitiesChanged();
    }

    private void Jump()
    {
        if (hasJump)
        {
            Vector2 vel = _rigidbody2D.velocity;
            vel.y = 0;
            _rigidbody2D.velocity = vel;
            _rigidbody2D.AddForce(transform.up * jumpSpeed);
        }
    }
    protected virtual void OnOnAbilitiesChanged()
    {
        OnAbilitiesChanged(hasLeft, hasRight, hasJump, hasDown);
    }

    public bool IsPressingDown()
    {
        return _playerInput.terrain.Down.triggered;
    }
}