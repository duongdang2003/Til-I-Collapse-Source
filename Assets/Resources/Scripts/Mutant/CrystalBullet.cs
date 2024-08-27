using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    public float speed;
    public float shootSpeed;
    private Vector3 endPoint;
    private bool lerp = false;
    private bool canHit = false;
    private AudioSource playerAudioSource;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        playerAudioSource = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
    }
    void Update()
    {
        transform.Rotate(4, 4, 4);
        if(lerp)
            transform.position = Vector3.Lerp(transform.position, endPoint, Time.deltaTime * 2);

    }
    public void Fire(){
        lerp = false;
        canHit = true;
        Vector3 dir = (player.transform.position - transform.position);
        dir.y += 7;
        dir = dir.normalized;
        rb.velocity = dir * speed;
    }
    public void FireFromMutant(Vector3 mutantDir){
        canHit = true;
        rb.velocity = mutantDir * shootSpeed;
    }
    public void SetEndPoint(Vector3 pos)
    {
        endPoint = pos;
        lerp = true;
    }
    private void OnTriggerEnter(Collider other) {
        if(canHit){
            Debug.Log(other.gameObject.name);
            gameObject.SetActive(false);
            canHit = false;
            GameObject explosion = ObjectPool.Instance.GetObjectFromPool("crystal explosion");
            explosion.transform.position = gameObject.transform.position;
            SoundManager.Instance.PlaySound(playerAudioSource, SoundManager.Instance.crystalShot);

            if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
                other.gameObject.GetComponent<PlayerStats>().UpdateHealth(-20);
            }
        }        
    }
}
