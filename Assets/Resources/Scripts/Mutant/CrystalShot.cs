using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalShot : MonoBehaviour
{
    public float bulletSpeed;
    public void Shoot(){
        GameObject bullet = ObjectPool.Instance.GetObjectFromPool("crystal bullet");
        bullet.transform.position = gameObject.transform.position;
        bullet.GetComponent<CrystalBullet>().FireFromMutant(transform.root.forward);
    }
}
