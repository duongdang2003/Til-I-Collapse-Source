using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MutantAccost : IState
{
    private Mutant mutant;
    private float accostSpeed = 70;
    private float currentSpeed;
    private bool isReaching = false;
    private NavMeshAgent navMeshAgent;
    public MutantAccost(Mutant mutant){
        this.mutant = mutant;
    }
    public void Enter()
    {
        navMeshAgent = mutant.GetNavMeshAgent();
        currentSpeed = navMeshAgent.speed;
        mutant.GetAnimator().SetTrigger("Accosting");
        isReaching = false;
    }

    public void Exit()
    {
    }

    public void Update()
    {
        if(!isReaching){
            currentSpeed = Mathf.Lerp(currentSpeed, accostSpeed, Time.deltaTime * 3);
            navMeshAgent.speed = currentSpeed;
        }
        

        if(navMeshAgent.remainingDistance < 32 && !isReaching){
            isReaching = true;
            // mutant.TransitionToAttack();
            // mutant.GetAnimator().SetTrigger("Melee");
            mutant.SetRandomMeleeAttack();
            navMeshAgent.speed = 0;
        }
    }
}
