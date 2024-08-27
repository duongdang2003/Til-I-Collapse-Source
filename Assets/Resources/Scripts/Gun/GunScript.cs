using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    private GameObject player;
    private SoundController soundController;
    private AudioSource playerAudioSource;
    public int bullet = 35;
    private RaycastHit hit;
    private Text bulletCount;

    private void Awake() {
        soundController = GameObject.FindWithTag("SoundController").GetComponent<SoundController>();
        player = GameObject.FindWithTag("Player");
        playerAudioSource = player.GetComponent<AudioSource>();
        bulletCount = GameObject.FindWithTag("BulletUI").GetComponent<Text>();

    }
    // play sound
    public void InsertMagazine(){
        playerAudioSource.PlayOneShot(soundController.insertMagazine);
    }
    public void RemoveMagazine(){
        playerAudioSource.PlayOneShot(soundController.removeMagazine);
    }
    public void Loaded(){
        playerAudioSource.PlayOneShot(soundController.loaded);
    }
    public void SmgShoot(){
        playerAudioSource.PlayOneShot(soundController.smgShoot1);
    }
    public void SmgShoot2(){
        playerAudioSource.PlayOneShot(soundController.smgShoot2);
    }
    public void RevolverShoot(){
        playerAudioSource.PlayOneShot(soundController.revolverShoot);
    }
    public void FireSound(){
        bullet--;
        UpdateBulletNum(bullet);
        if(bullet != 0){
            float soundIndex = Random.Range(0, 2);
            if (soundIndex == 0) SmgShoot();
            else SmgShoot2();

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            // target layer
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, ~3)){
                // target
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Target")){
                    
                    hit.collider.gameObject.GetComponent<Target>().Hit();
                    // enemy head
                } else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("EnemyHead")){
                    if(!hit.collider.gameObject.transform.root.GetComponent<Enemy>().IsDead())
                    hit.collider.gameObject.transform.root.GetComponent<Enemy>().TakeDamage(player.GetComponent<PlayerShoot>().GetHeadShotDamage());
                } else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy")){
                    Boss boss;
                    if(hit.collider.gameObject.transform.root.TryGetComponent<Boss>(out boss)){
                        GameObject hitEffect = ObjectPool.Instance.GetObjectFromPool("hit");
                        hitEffect.transform.position = hit.point;
                        hit.collider.gameObject.transform.root.GetComponent<Boss>().UpdateHealth(-0.5f);
                    }
                }
            }
            player.GetComponent<PlayerInput>().AllowReload();
        } else {
            player.GetComponent<PlayerInput>().ReloadAction();

        }
        
    }
    public void FinishReload(){
        player.GetComponent<PlayerMovement>().FinishReload();
        bullet = 35;
        player.GetComponent<PlayerInput>().DenyReload();
        UpdateBulletNum(bullet);
    }
    public bool CheckIsMagazineEmty(){
        if (bullet <= 0) return true;
        else return false;
    }
    public bool CanReload(){
        Debug.Log(bullet);
        if (bullet < 35) return true;
        else return false;
    }
    public void UpdateBulletNum(int bullet){
        bulletCount.text = bullet + " / ~";
    }
    public void SwitchGun(){
        player.GetComponent<PlayerShoot>().SwitchGun();
    }
}
