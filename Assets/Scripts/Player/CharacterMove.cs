using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private CharacterData _characterData;
    [SerializeField] private SpriteRenderer _avatarRenderer; 

    

    private float _movementInput;

    public Rigidbody2D Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public bool IsGrounded { get; private set; }

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
    }

    private void Update()
    {
        Rigidbody.velocity = new Vector2(_movementInput * _characterData.Speed, Rigidbody.velocity.y);
    }
    #endregion

    private void HandleMovement(float direction)
    {
        _movementInput = direction;
        Animator.SetFloat("MoveSpeed", Mathf.Abs(direction));
        bool shouldFlip = direction < 0;
        _avatarRenderer.flipX = shouldFlip;
    }

    private void HandleJump()
    {
        if (IsGrounded)
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, _characterData.JumpForce);
            Animator.SetTrigger("Jump");
            IsGrounded = false;
        }
    }
}
