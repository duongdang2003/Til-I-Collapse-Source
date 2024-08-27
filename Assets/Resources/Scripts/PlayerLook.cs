using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : Player
{
    public float speed = 10;
    private float verticalRotate = 0;
    public bool isDone = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if(!isDone){
            Vector3 lookHorizontal = speed * mouseX * Time.deltaTime * Vector3.up;
            verticalRotate -= mouseY;
            verticalRotate = Mathf.Clamp(verticalRotate, -90f, 90f);
            transform.Rotate(lookHorizontal);
            currentGun.transform.localRotation = Quaternion.Euler(verticalRotate, 0, 0);
        }
        
    }

    public void ChangeCurrentGun(GameObject gun){
        currentGun = gun;
    }
}
