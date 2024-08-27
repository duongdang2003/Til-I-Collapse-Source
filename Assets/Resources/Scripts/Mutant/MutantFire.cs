using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantFire : IState
{
    private readonly Mutant mutant;
    public MutantFire(Mutant mutant){
        this.mutant = mutant;
    }
    public void Enter()
    {
        mutant.state = "fire";
        SoundManager.Instance.PlaySound(mutant.GetAudioSource(), SoundManager.Instance.mutantCast[0]);
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
