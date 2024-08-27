using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void Hit(){
        StartCoroutine(EnableTarget());
        gameObject.SetActive(false);
    }
    IEnumerator EnableTarget(){
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(true);
    }
}
