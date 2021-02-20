using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[SelectionBase]
public class Player : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float extraHeightValue;
    [SerializeField] private int maxJumpQtd;
    [SerializeField] private LayerMask plataformLayerMask;

    [SerializeField] private int _jumpQtd;
    private Collider2D _playerMainCollider;
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;

    public bool hasLeft;
    public bool hasRight;
    public bool hasJump;
    public bool hasDown;

    public bool isGrounded = true;

    public event Action<bool, bool> OnMovimentChanged = delegate { };
    public event Action<bool, bool, bool, bool> OnAbilitiesChanged = delegate { };

    private Vector2 _lastMovement;

    private void Awake()
    {
        _jumpQtd = maxJumpQtd;
        _lastMovement = Vector2.zero;
        _playerInput = new PlayerInput();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerMainCollider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        _playerInput.terrain.jump.started += _ => Jump();
        _playerInput.terrain.ResetLevel.started += _ => ResetLevel();
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

        else if (!hasRight && xMovement > 0)
        {
            xMovement = 0;
        }

        Vector2 movement = new Vector2(xMovement, 0);


        if (_lastMovement != movement)
        {
            bool isMoving = movement != Vector2.zero;
            OnMovimentChanged(isMoving, isMoving ? movement.x < 0 : _lastMovement.x < 0);
        }

        _lastMovement = movement;
        movement *= Time.deltaTime * horizontalSpeed;
        movement.y = _rigidbody2D.velocity.y;


        _rigidbody2D.velocity = movement;
        if (movement.x != 0 && IsGrounded())
            AudioManager.Instance.PlaySound(global::Sound.PlayerMove);

        if (_jumpQtd != maxJumpQtd && movement.y < 0)
        {
            isGrounded = IsGrounded();
        }
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
        if (hasJump && _jumpQtd > 0)
        {
            isGrounded = false;
            Vector2 vel = _rigidbody2D.velocity;
            vel.y = 0;
            _rigidbody2D.velocity = vel;
            _rigidbody2D.AddForce(transform.up * jumpSpeed);
            _jumpQtd--;
        }
    }

    protected virtual void OnOnAbilitiesChanged()
    {
        OnAbilitiesChanged(hasLeft, hasRight, hasJump, hasDown);
    }

    private bool IsGrounded()
    {
        var bounds = _playerMainCollider.bounds;
        RaycastHit2D raycastHit = Physics2D.BoxCast(bounds.center,
            bounds.size,
            0f, Vector2.down, extraHeightValue, plataformLayerMask);

        Color rayColor;

        bool result = raycastHit.collider != null;

        rayColor = result ? Color.green : Color.red;


        if (result)
        {
            _jumpQtd = maxJumpQtd;
        }

        Debug.DrawRay(bounds.center + new Vector3(bounds.extents.x, 0), Vector2.down * (bounds.extents.y
            + extraHeightValue), rayColor);
        Debug.DrawRay(_playerMainCollider.bounds.center - new Vector3(bounds.extents.x, 0), Vector2.down *
            (bounds.extents.y + extraHeightValue), rayColor);
        Debug.DrawRay(_playerMainCollider.bounds.center - new Vector3(bounds.extents.x,
                bounds.extents.y + extraHeightValue),
            Vector2.right * bounds.extents.x * 2, rayColor);

        return result;
    }


    public bool IsPressingDown()
    {
        return _playerInput.terrain.Down.triggered;
    }

    public void ResetLevel()
    {
        SceneController.ResetScene();
    }
}