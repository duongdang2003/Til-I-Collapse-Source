using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // component
    protected Rigidbody rb;
    protected Animator animator;
    protected NavMeshAgent navMeshAgent;

    // stat
    protected float health;
    protected float attackDamage;
    protected float attackSpeed;
    protected float speed;

    // player
    protected GameObject player;

    // status
    protected bool isDead = false;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }
    public virtual void TakeDamage(float damage){
        health -= damage;
        if(health > 0)
        animator.SetTrigger("Hurt");
        else {
            animator.SetTrigger("Death");
            navMeshAgent.isStopped = true;
            Death();
        }
    }
    public virtual void Death(){
        isDead = true;
    }
    public bool IsDead(){
        return isDead;
    }
}
