using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantWalking : IState
{
    private readonly Mutant mutant;
    public MutantWalking(Mutant mutant){
        this.mutant = mutant;
    }
    public void Enter()
    {
        mutant.state = "walking";
        mutant.GetNavMeshAgent().speed = mutant.GetWalkingSpeed();
        mutant.Invoke(nameof(mutant.TransitionToAttack), Random.Range(1, 3));
        mutant.GetAnimator().SetTrigger("Walking");
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
