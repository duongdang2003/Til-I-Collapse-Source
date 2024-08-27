using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantDeath : IState
{
    private Mutant mutant;
    public MutantDeath(Mutant mutant){
        this.mutant = mutant;
    }
    public void Enter()
    {
        mutant.GetNavMeshAgent().speed = 0;
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        
    }
}
