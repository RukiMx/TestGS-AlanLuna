using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private CharacterData _characterData;
    [SerializeField] private SpriteRenderer _avatarRenderer;


    private float _movementInput;
    private bool _isGrounded;

    public Rigidbody2D Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public bool IsGrounded { get { return _isGrounded; } private set { _isGrounded = value; Animator.SetBool("Grounded", value); } }
    public bool CanMove { get; private set; }

    #region UNITY METHODS
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = _avatarRenderer.GetComponent<Animator>();
    }

    private void Start()
    {
        // Suscribe to the Input Manager events
        InputManager.Instance.OnMove += HandleMovement;
        InputManager.Instance.OnJump += HandleJump;

        GameEvents.OnPlayerDead += () => CanMove = false;
        GetComponent<CharacterCollisionHandler>().OnGroundTouch += () => IsGrounded = true;
        GetComponent<CharacterCollisionHandler>().OnGroundExit += () => IsGrounded = false;

        CanMove = true;
    }

    private void Update()
    {
        if (!CanMove) return;
        Rigidbody.velocity = new Vector2(_movementInput * _characterData.Speed, Rigidbody.velocity.y);
    }
    #endregion

    private void HandleMovement(float direction)
    {
        if (!CanMove) return;

        _movementInput = direction;
        Animator.SetFloat("MoveSpeed", Mathf.Abs(direction));

        if (direction != 0)
        {
            bool shouldFlip = direction < 0;
            _avatarRenderer.flipX = shouldFlip;
        }

    }

    private void HandleJump()
    {
        if (IsGrounded && CanMove)
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, _characterData.JumpForce);
            Animator.SetTrigger("Jump");
            IsGrounded = false;
        }
    }
}
