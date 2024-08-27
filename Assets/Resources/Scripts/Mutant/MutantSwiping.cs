using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantSwiping : IState
{
    private readonly Mutant mutant;
    public MutantSwiping(Mutant mutant){
        this.mutant = mutant;
    }
    public void Enter()
    {
        mutant.state = "swiping";
        mutant.GetNavMeshAgent().speed = 0;
    }

    public void Exit()
    {
        mutant.GetNavMeshAgent().speed = 3;
    }

    public void Update()
    {
        
    }
}
