using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantCrystalShot : IState
{
    private Mutant mutant;
    public MutantCrystalShot(Mutant mutan){
        this.mutant = mutan;
    }
    public void Enter()
    {
        SoundManager.Instance.PlaySound(mutant.GetAudioSource(), SoundManager.Instance.mutantCast[1]);
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
