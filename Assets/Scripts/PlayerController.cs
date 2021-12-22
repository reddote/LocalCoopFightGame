using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public float Speed{
        get => speed;
        set => speed = value;
    }

    public float JumpForce{
        get => jumpForce;
        set => jumpForce = value;
    }

    public float Health{
        get => health;
        set => health = value;
    }

    public float Damage{
        get => damage;
        set => damage = value;
    }

    public float AttackCoolDown{
        get => attackCoolDown;
        set => attackCoolDown = value;
    }

    public float Rebound{
        get => rebound;
        set => rebound = value;
    }

    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float health = 100;
    [SerializeField] private float damage = 50;
    [SerializeField] private float attackCoolDown = 1f;
    [SerializeField] private HitBoxController hitBox;
    [SerializeField] private float rebound = 50;
    [SerializeField] private PlayerAnimationController animator;
    private string _move = "Move";
    private float _moveDirection;
    private float _attackDirection = 0;
    private Rigidbody2D _playerRb;
    private bool _isJumped = false;
    private bool _isMoving = false;
    private int _jumpCount = 0;
    private bool _isAttacked = false;
    private Vector3 _swapRot = new Vector3(0,180f,0);


    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if (_isMoving){
            Move();
            animator.SetAnimationBool(_move, true);
        } else{
            animator.SetAnimationBool(_move, false);
        }

        if (_moveDirection != 0){
            ChangeRotation((int)_moveDirection);
            _attackDirection = _moveDirection;
        }

        if (_isAttacked){
            attackCoolDown -= Time.deltaTime;
            if (attackCoolDown <= 0){
                attackCoolDown = 1f;
                _isAttacked = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (_isJumped && _jumpCount < 2){
            Jump();
        }
    }

    public void SetJump(bool jumping){
        _isJumped = jumping;
    }
    
    public void SetMove(bool moving, float direction){
        _isMoving = moving;
        _moveDirection = direction;
    }
    
    private void Move(){
        Vector3 move = new Vector3(_moveDirection, 0, 0);
        transform.position += move * (Time.deltaTime * speed);
    }

    public void TakeDamage(float dmg){
        health -= dmg;
    }

    public void ChangeRotation(int direction){
        if (direction == 1){
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }else if(direction == -1){
            transform.rotation = Quaternion.Euler(_swapRot);
        }
    }

    public void HitOtherPlayer(){
        if (!_isAttacked){
            if (hitBox.GetEnemyPlayer()){
                var _temp = hitBox.GetEnemyPlayer().GetComponent<PlayerController>();
                if (_temp){
                    animator.SetAnimationBool("Punch", true);
                    //other player pushed a little bit when attack hits
                    _temp._playerRb.AddForce(Vector2.right * _attackDirection * rebound);
                    //other player take damage
                    _temp.TakeDamage(damage);
                }
            }
            _isAttacked = true;
            animator.SetAnimationBool("Punch", false);
        }
    }

    private void Jump(){
        _playerRb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Force);
        _isJumped = false;
        _jumpCount++;
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Ground")){
            if (_jumpCount>1){
                _jumpCount = 0;
            }
        }
    }
}
