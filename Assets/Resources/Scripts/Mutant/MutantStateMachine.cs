using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantStateMachine : StateMachine
{
    public MutantIdle MutantIdle { get; private set; }
    public MutantSwiping MutantSwiping { get; private set; }
    public MutantFire MutantFire{ get; private set; }
    public MutantWalking MutantWalking { get; private set; }
    public MutantCrystalLine MutantCrystalLine { get; private set; }
    public MutantCrystalShot MutantCrystalShot { get; private set; }
    public MutantAccost MutantAccost { get; private set; }
    public MutantRoar MutantRoar { get; private set; }
    public MutantDeath MutantDeath { get; private set; }
    public MutantStateMachine(Mutant mutant){
        this.MutantIdle = new MutantIdle(mutant);
        this.MutantSwiping = new MutantSwiping(mutant);
        this.MutantFire = new MutantFire(mutant);
        this.MutantWalking = new MutantWalking(mutant);
        this.MutantCrystalLine = new MutantCrystalLine(mutant);
        this.MutantCrystalShot = new MutantCrystalShot(mutant);
        this.MutantAccost = new MutantAccost(mutant);
        this.MutantRoar = new MutantRoar(mutant);
        this.MutantDeath = new MutantDeath(mutant);
    }
}
