using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            other.gameObject.GetComponent<PlayerStats>().UpdateHealth(-10f);
    }
}
