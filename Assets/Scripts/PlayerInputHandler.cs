using System;
using System.Collections;
using System.Collections.Generic;
using PlayMenu;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour{
    private PlayerConfiguration _playerConfiguration;
    private PlayerController _controller;

    [SerializeField] private Transform playerParent;
    
    private QAFIGHT _qafıght;

    private void Awake(){
        _controller = GetComponent<PlayerController>();
        _qafıght = new QAFIGHT();
    }

    public void InitPlayer(PlayerConfiguration temp){
        _playerConfiguration = temp;
        playerParent.GetChild(_playerConfiguration.characterIndex).gameObject.SetActive(true);
        _playerConfiguration.Input.currentActionMap[_qafıght.Player.MoveLeft.name].performed += OnperformedLeft;
        _playerConfiguration.Input.currentActionMap[_qafıght.Player.MoveLeft.name].canceled += OncanceledLeft;
        _playerConfiguration.Input.currentActionMap[_qafıght.Player.MoveLeft.name].started += OnstartLeft;
        _playerConfiguration.Input.currentActionMap[_qafıght.Player.MoveRight.name].performed += OnperformedLeft;
        _playerConfiguration.Input.currentActionMap[_qafıght.Player.MoveRight.name].canceled += OncanceledRight;
        _playerConfiguration.Input.currentActionMap[_qafıght.Player.MoveRight.name].started += OnstartRight;
        _playerConfiguration.Input.currentActionMap[_qafıght.Player.Jump.name].performed += OnperformedLeft;
        _playerConfiguration.Input.currentActionMap[_qafıght.Player.Jump.name].canceled += OnJumpCanceled;
        _playerConfiguration.Input.currentActionMap[_qafıght.Player.Jump.name].started += OnJumpStarted;
        _playerConfiguration.Input.currentActionMap[_qafıght.Player.Fist.name].performed += OnperformedLeft;
        _playerConfiguration.Input.currentActionMap[_qafıght.Player.Fist.name].canceled += OnAttackCanceled;
        _playerConfiguration.Input.currentActionMap[_qafıght.Player.Fist.name].started += OnAttackStarted;
        _playerConfiguration.Input.currentActionMap[_qafıght.Player.Kick.name].performed += OnperformedLeft;
        _playerConfiguration.Input.currentActionMap[_qafıght.Player.Kick.name].canceled += OnAttackCanceled;
        _playerConfiguration.Input.currentActionMap[_qafıght.Player.Kick.name].started += OnAttackStarted;
    }

    private void OnstartLeft(InputAction.CallbackContext obj){
        OnMove(true, -1);
    }
    
    private void OnstartRight(InputAction.CallbackContext obj){
        OnMove(true, 1);
    }
    
    private void OncanceledRight(InputAction.CallbackContext obj){
        OnMove(false,0);
    }

    private void OncanceledLeft(InputAction.CallbackContext obj){
        OnMove(false,0);
    }

    private void OnJumpStarted(InputAction.CallbackContext obj){
        OnJump(true);
    }

    private void OnJumpCanceled(InputAction.CallbackContext obj){
        OnJump(false);
    }
    
    private void OnAttackCanceled(InputAction.CallbackContext obj){
        Debug.Log("Attack Canceled");
    }
    
    private void OnAttackStarted(InputAction.CallbackContext obj){
        OnAttack();
    }

    private void OnperformedLeft(InputAction.CallbackContext obj){
        Debug.Log("pressing left rn");
        Debug.Log(obj.started);
        Debug.Log((obj.phase).ToString());
        // Debug.Log(obj.canceled);
    }

    private void OnAttack(){
        _controller.HitOtherPlayer();
    }
    
    private void OnMove(bool test, int direction){
        if (_controller != null){
            _controller.SetMove(test, direction);
        }
    }

    private void OnJump(bool temp){
        if (_controller != null){
            _controller.SetJump(temp);
        }
    }
}