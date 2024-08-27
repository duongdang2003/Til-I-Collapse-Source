using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MutantRoar : IState
{
    private Mutant mutant;
    public MutantRoar(Mutant mutant){
        this.mutant = mutant;
    }
    public void Enter()
    {
        mutant.GetNavMeshAgent().speed = 0;
        mutant.GetAnimator().SetTrigger("Roar");
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
