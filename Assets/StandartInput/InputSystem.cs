using UnityEngine;
using UnityEngine.InputSystem;
using Cursor = UnityEngine.Cursor;

public class InputSystem : MonoBehaviour
{
    [Header("Character Input Values")]
    public bool moveRight;
    public bool moveLeft;
    
    public bool jump;
    public bool punch;
    public bool kick;

    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;

    public void OnMoveLeft(InputValue value)
    {
        MoveLeftInput(value.isPressed);
    }

    public void OnMoveRight(InputValue value)
    {
        MoveRightInput(value.isPressed);
    }

    public void OnPunch(InputValue value)
    {
        PunchInput(value.isPressed);
    }
    
    public void OnKick(InputValue value)
    {
        KickInput(value.isPressed);
    }

    public void OnJump(InputValue value)
    {
        JumpInput(value.isPressed);
    }
    
    private void KickInput(bool newKickState)
    {
        kick = newKickState;
    }

    
    private void PunchInput(bool newPunchState)
    {
        punch = newPunchState;
    }

    private void JumpInput(bool newJumpState)
    {
        jump = newJumpState;
    }

    private void MoveLeftInput(bool newMoveState)
    {
        moveLeft = newMoveState;
    }
    
    private void MoveRightInput(bool newMoveState)
    {
        moveRight = newMoveState;
    }

    
#if !UNITY_IOS || !UNITY_ANDROID

    private void OnApplicationFocus(bool hasFocus)
    {
        SetCursorState(cursorLocked);
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }

#endif
}
