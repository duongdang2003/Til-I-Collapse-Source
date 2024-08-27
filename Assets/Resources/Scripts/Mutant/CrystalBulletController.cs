using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBulletController : MonoBehaviour
{
    public GameObject bullet;
    public int bulletQuantity;
    private GameObject[] bulletsList;
    private GameObject circle;
    private void Awake() {
        bulletsList = new GameObject[bulletQuantity];
    }
    public void CreateBullet(){
        for(int i=0; i < bulletQuantity; i++){
            GameObject bullet = ObjectPool.Instance.GetObjectFromPool("crystal bullet");
            bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
            bulletsList[i] = bullet;

            Vector3 direction = (Random.onUnitSphere * Random.Range(8, 10)).normalized;
            Vector3 bulletPos = bullet.transform.position;
            bulletPos = transform.position + direction*Random.Range(15, 20);
            
            Vector3 endPoint = bulletPos;
            bulletPos = new Vector3(bulletPos.x, transform.parent.position.y, bulletPos.z);
            bullet.transform.position = bulletPos;
            bullet.GetComponent<CrystalBullet>().SetEndPoint(endPoint);
        }
    }
    public void FireBullet(){
        foreach(GameObject bullet in bulletsList){
            bullet.GetComponent<CrystalBullet>().Fire();
        }
        }
    public void BlueCircle(){
        circle = ObjectPool.Instance.GetObjectFromPool("blue circle");
        circle.transform.position = transform.parent.position;
        circle.GetComponent<Animator>().SetTrigger("Spread");
    }
    public void CloseBlueCircle(){
        if(circle)
            circle.GetComponent<Animator>().SetTrigger("Suppress");
    }
}
