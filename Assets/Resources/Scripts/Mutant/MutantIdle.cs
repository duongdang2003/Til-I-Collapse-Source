using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantIdle : IState
{
    private Mutant mutant;
    public MutantIdle(Mutant mutant){
        this.mutant = mutant;
    }
    public void Enter()
    {
        // Debug.Log("mutant idle");
        mutant.state = "Idle";
        mutant.GetNavMeshAgent().speed = 0;
        mutant.Invoke(nameof(mutant.TransitionToWalking), Random.Range(1, 3));
    }

    public void Exit()
    {
        mutant.GetNavMeshAgent().speed = mutant.GetWalkingSpeed();
    }

    public void Update()
    {
        // Debug.Log("mutant idle update");
    }
}
