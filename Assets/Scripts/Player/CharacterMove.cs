using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private CharacterData _characterData;
    [SerializeField] private SpriteRenderer _avatarRenderer; 

    public Rigidbody2D _rigidbody { get; private set; }
    public Animator _animator { get; private set; }


    private float _movementInput;

    public bool IsGrounded { get; private set; }

    #region UNITY METHODS
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = _avatarRenderer.GetComponent<Animator>();
    }

    private void Start()
    {
        // Suscribe to the Input Manager events
        InputManager.Instance.OnMove += HandleMovement;
        InputManager.Instance.OnJump += HandleJump;
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector2(_movementInput * _characterData.Speed, _rigidbody.velocity.y);
    }
    #endregion

    private void HandleMovement(float direction)
    {
        _movementInput = direction;
        _animator.SetFloat("MoveSpeed", Mathf.Abs(direction));
        bool shouldFlip = direction < 0;
        _avatarRenderer.flipX = shouldFlip;
    }

    private void HandleJump()
    {
        if (IsGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _characterData.JumpForce);
            _animator.SetTrigger("Jump");
            IsGrounded = false;
        }
    }
}
