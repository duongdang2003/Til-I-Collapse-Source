using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player
{
    private Vector2 moveDir;
    public bool isReloading = false;
    private readonly float speed = 1200f;
    private Collider[] grounCheck;
    public float x, y, z, xSize, ySize, zSize;
    public float jumpForce;
    private void Update() {
        grounCheck = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 2.8f);
        if(grounCheck.Length > 0){

        }
    }
    private void FixedUpdate() {
        // rb.velocity = speed * Time.deltaTime * moveDir.normalized;
        rb.velocity = new Vector3((transform.forward.x * moveDir.y + transform.right.x * moveDir.x) * speed * Time.deltaTime,
        rb.velocity.y, (transform.forward.z * moveDir.y + transform.right.z * moveDir.x) * speed * Time.deltaTime);
    }
    public void SetMoveDir(Vector2 dir){
        moveDir = dir;
    }
    public void FinishReload(){
        isReloading = false;
    }
    public bool IsOnGround(){
        return grounCheck.Length > 0 ? true : false; 
    }
    public void Jump(){
        if(IsOnGround()){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jump");
        }
    }
    private void OnDrawGizmos() {
        Gizmos.DrawSphere(new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z), xSize);
    }
}
