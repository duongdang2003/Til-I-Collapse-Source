using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : Player
{
    private bool canReload = false;
    public void Move(InputAction.CallbackContext context){
        if(context.performed){
            Vector2 dir = context.ReadValue<Vector2>();
            playerMovement.SetMoveDir(dir);
        } if(context.canceled){
            playerMovement.SetMoveDir(Vector3.zero);
        }
    }
    public void Shoot(InputAction.CallbackContext context){
        if(context.performed && !playerMovement.isReloading){
            animator.SetBool("Shoot", true);
        } else if(context.canceled){
            animator.SetBool("Shoot", false);
        }
    }
    public void Reload(InputAction.CallbackContext context){
        if(context.performed && !playerMovement.isReloading && canReload){
            ReloadAction();
        }
    }
    public void SwitchRifle(InputAction.CallbackContext context){
        if(context.performed){
            playerShoot.SwitchWeapon(0);
        }
    }
    public void SwitchMagnum(InputAction.CallbackContext context){
        if(context.performed){
            playerShoot.SwitchWeapon(1);
        }
    }
    public void Jump(InputAction.CallbackContext context){
        if(context.performed){
            playerMovement.Jump();
        }
    }

    public void ReloadAction(){
        animator.SetBool("Shoot", false);
        playerMovement.isReloading = true;
        animator.SetTrigger("Reload");
    }
    public void AllowReload(){
        canReload = true;
    }
    public void DenyReload(){
        canReload = false;
    }
    public void ChangeComponent(Animator newAnimator){
        animator = newAnimator;
    }
}
