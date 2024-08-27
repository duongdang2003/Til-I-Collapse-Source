using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : Player
{
    public GameObject[] guns;
    private int currentGunIndex;
    private GameObject previousGun;
    // private void Start() {
    //     guns = GameObject.FindGameObjectsWithTag("Gun");
    // }

    public void SwitchGun(){
        previousGun = currentGun;
        for(int i=0; i < guns.Length; i++){
            if (i == currentGunIndex) ReAssignComponent(guns[i]);
        }
        // ReAssignComponent();
    }
    public void SwitchWeapon(int index){
        if(currentGunIndex != index){
            currentGunIndex = index;
            animator.SetTrigger("Hide");
            playerMovement.FinishReload();
        }
    }
    public float GetAttackDamage(){
        return playerStats.GetAttackDamage();
    }
    public float GetHeadShotDamage(){
        return playerStats.GetAttackDamage() * 1.5f;
    }
    public void ReAssignComponent(GameObject gun){
        // get last rotation of previous gun
        float lastRotation = currentGun.transform.rotation.eulerAngles.x;

        currentGun = gun;
        playerLook.ChangeCurrentGun(currentGun);
        // assign rotation for new gun
        currentGun.transform.rotation = Quaternion.Euler(new Vector3(lastRotation, 0, 0));
        StartCoroutine(ActiveGun(gun));
        animator = currentGun.GetComponent<Animator>();
        playerInput.ChangeComponent(animator);
    }
    IEnumerator ActiveGun(GameObject gun){
        yield return new WaitForSeconds(0.01f);
        previousGun.SetActive(false);
        gun.SetActive(true);
    }
}
