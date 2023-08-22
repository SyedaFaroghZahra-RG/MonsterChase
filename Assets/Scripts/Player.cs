using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 11f;
    [SerializeField] private float _moveForce = 10f;
    private float _movementX;
    private bool _isGrounded = true;
    
    private Rigidbody2D _myBody;
    private Animator _anim;
    private SpriteRenderer _sr;

    private string WALK_ANIMATION = "IsWalking";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    private void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }
    
    private void PlayerMoveKeyboard()
    {
        _movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(_movementX, 0f, 0f) * _moveForce * Time.deltaTime;
    }

    private void AnimatePlayer()
    {
        if (_movementX > 0)
        {
            _anim.SetBool(WALK_ANIMATION, true);
            _sr.flipX = false;
        }
        else if (_movementX < 0)
        {
            _anim.SetBool(WALK_ANIMATION, true);
            _sr.flipX = true;
        }
        else
        {
            _anim.SetBool(WALK_ANIMATION, false);
        }
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _isGrounded = false;
            _myBody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(GROUND_TAG))
        {
            _isGrounded = true;
        }

        if (other.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
