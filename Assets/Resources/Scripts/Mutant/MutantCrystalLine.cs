using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantCrystalLine : IState

{
    private Mutant mutant;
    public MutantCrystalLine(Mutant mutant){
        this.mutant = mutant;
    }
    public void Enter()
    {
        mutant.GetNavMeshAgent().speed = 0;
        SoundManager.Instance.PlaySound(mutant.GetAudioSource(), SoundManager.Instance.crystalLineSound);
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
    public void Crystal(){
        
    }
}
