using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rake : Enemy
{
    public GameObject rakeBody;
    public Material dissolve;
    private float dissolveValue = 1;
    private void Start() {
        dissolve = rakeBody.GetComponent<SkinnedMeshRenderer>().material;
        health = 50;
    }
    private void Update() {
        navMeshAgent.SetDestination(player.transform.position);
        
        if(isDead && dissolveValue < 1){
            dissolveValue += 0.005f;
            dissolve.SetFloat("_Dissolve", dissolveValue);
        }
    }
    public override void Death()
    {
        base.Death();
        player.GetComponent<PlayerStats>().GainXP(55);
    }
    public void Dissolve(){
        dissolveValue = 0;
    }
}
