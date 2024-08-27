using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    protected bool dealth = false;
    public virtual void UpdateHealth(float para){

    }
    public bool IsDeath() => dealth;
}
