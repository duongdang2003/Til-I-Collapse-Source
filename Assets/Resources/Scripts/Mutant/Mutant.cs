using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Mutant : Boss
{
    private MutantStateMachine stateMachine;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private Transform player;
    private bool canDealDamage = false;
    private float targetDistance;
    private float behaviourCD;
    private GameObject[] crystalLines;
    private GameObject crystalShotPoint;
    private GameObject slashTrail;
    private GameObject iceExplosion;
    private AudioSource audioSource;
    private Slider healthBar;

    public float SWIP_RANGE;
    public float WALKING_SPEED;
    public Collider[] playerCheck;
    public string state;
    public CrystalBulletController crystalBulletController;
    public GameObject[] squareTrail;
    public Slider health;
    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerCheck = new Collider[1];
        player = GameObject.FindWithTag("Player").transform;
        crystalLines = GameObject.FindGameObjectsWithTag("CrystalLine");
        foreach(GameObject crystalLine in crystalLines){
            crystalLine.SetActive(false);
        }
        crystalShotPoint = GameObject.FindWithTag("CrystalShootPoint");
        slashTrail = GameObject.FindWithTag("SlashTrail");
        slashTrail.SetActive(false);
        squareTrail = GameObject.FindGameObjectsWithTag("SquareTrail");
        TurnOffSquareTrail();
        iceExplosion = GameObject.FindWithTag("IceExplosion");
        iceExplosion.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        health = GameObject.FindWithTag("BossHealthBar").GetComponent<Slider>();
        health.value = 100;
    }
    void Start()
    {
        stateMachine = new MutantStateMachine(this);
        stateMachine.TransitionTo(stateMachine.MutantIdle);
    }

    void Update()
    {
        navMeshAgent.SetDestination(player.position);
        targetDistance = navMeshAgent.remainingDistance;

        if(!dealth)
            stateMachine.Update();

    }
    public void BacktoIdle(){
        stateMachine.TransitionTo(stateMachine.MutantIdle);
    }
    public void TransitionToWalking(){
        stateMachine.TransitionTo(stateMachine.MutantWalking);
    }
    public void TransitionToAttack(){
        if(targetDistance < 26){
            SetRandomMeleeAttack();
        } else if(targetDistance < 100){
            GetRandomRangeAttack();
        } else {
            int index = Random.Range(0, 3);
            if(index <= 1){
                // stateMachine.TransitionTo(stateMachine.MutantAccost);
                stateMachine.TransitionTo(stateMachine.MutantRoar);
            } else
            GetRandomRangeAttack();
        }
    } 
    public void CrystalRising(){
        foreach(GameObject crystalLine in crystalLines){
            crystalLine.SetActive(true);
            crystalLine.GetComponent<CrystalLine>().GetCrystal();
        }
    }
    public void ShootCrystal(){
        crystalShotPoint.GetComponent<CrystalShot>().Shoot();
    }
    public void GetRandomRangeAttack(){
        int index = Random.Range(1, 5);
        if(index == 1 || index == 2){
            animator.SetFloat("LongRange", 0);
            stateMachine.TransitionTo(stateMachine.MutantCrystalLine);
        } else if(index == 3){
            animator.SetFloat("LongRange", 1);
            stateMachine.TransitionTo(stateMachine.MutantCrystalShot);
        } else if(index == 4){
            animator.SetFloat("LongRange", 2);
            stateMachine.TransitionTo(stateMachine.MutantFire);
        }
        animator.SetTrigger("RangeAttack");
        navMeshAgent.speed = 0;
    }
    public void SetRandomMeleeAttack(){
        animator.SetFloat("MeleeAttack", Random.Range(0, 3));
        animator.SetFloat("HeavyAttack", Random.Range(0, 3));
        animator.SetTrigger("Melee");
        navMeshAgent.speed = 0;
    }
    public NavMeshAgent GetNavMeshAgent() => navMeshAgent;
    public Animator GetAnimator() => animator;
    public void StartDealDamage(){
        canDealDamage = true;
        slashTrail.SetActive(true);
        PlaySnortingSound();
    }
    public void EndDealDamage() { 
        canDealDamage = false;
        slashTrail.SetActive(false);
    } 
    public void TurnOnSquareTrail(){
        foreach(GameObject trail in squareTrail){
            trail.SetActive(true);
        }
    }
    public void TurnOffSquareTrail(){
        foreach(GameObject trail in squareTrail){
            trail.SetActive(false);
        }
    }
    public void ToAccosting(){
        stateMachine.TransitionTo(stateMachine.MutantAccost);
    }
    public void PlaySnortingSound() {
        SoundManager.Instance.PlaySound(audioSource, SoundManager.Instance.MonsterSnorting[Random.Range(0, 5)]);
    } 
    public void PlayFootStepSound(){
        SoundManager.Instance.PlaySound(audioSource, SoundManager.Instance.mutantFootstep[Random.Range(1, 3)]);
    }
    public void PlayRunningSound(){
        SoundManager.Instance.PlaySound(audioSource, SoundManager.Instance.mutantFootstep[0]);
    }
    public void PlayRoarSoud(){
        SoundManager.Instance.PlaySound(audioSource, SoundManager.Instance.mutantRoar[0]);
    }
    public void PlayRoarSound2(){
        SoundManager.Instance.PlaySound(audioSource, SoundManager.Instance.mutantRoar[1]);
    }
    public bool CanDealDamage => canDealDamage;
    public float SetBehaviourCD() => behaviourCD = Random.Range(0.5f, 2);
    public float GetWalkingSpeed() => WALKING_SPEED;
    public StateMachine GetStateMachine() => stateMachine;
    public void CreateBullet() => crystalBulletController.CreateBullet();
    public void FireBullet() => crystalBulletController.FireBullet();
    public void OpenBlueCircle() => crystalBulletController.BlueCircle();
    public void CloseBlueCircle() => crystalBulletController.CloseBlueCircle();
    public void IceExplosion() => iceExplosion.SetActive(true);
    public AudioSource GetAudioSource() => audioSource;
    public override void UpdateHealth(float para)
    {
        
        health.value += para;

        if (health.value <= 0){
            animator.SetTrigger("Death");
            stateMachine.TransitionTo(stateMachine.MutantDeath);
            dealth = true;
            CloseBlueCircle();
            SoundManager.Instance.PlaySound(audioSource, SoundManager.Instance.mutantDie);
            StartCoroutine(GameObject.FindWithTag("MainUI").GetComponent<UiController>().ActiveWinMenu());            
        } 

    }
    // private void OnDrawGizmos() {
    //     Gizmos.DrawSphere(transform.position, SWIP_RANGE);
    // }
    private void OnTriggerEnter(Collider other) {
        if(canDealDamage && other.gameObject.layer == 8){
            other.gameObject.GetComponent<PlayerStats>().UpdateHealth(-10);
        }
    }
}
