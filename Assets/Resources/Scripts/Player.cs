using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // game objects
    protected GameObject currentGun;

    // script
    protected PlayerMovement playerMovement;
    protected PlayerInput playerInput;
    protected PlayerLook playerLook;
    protected PlayerSound playerSound;
    protected PlayerShoot playerShoot;
    protected PlayerStats playerStats;

    // component
    protected Rigidbody rb;
    protected Animator animator;
    protected PlayerInput playerInputSystem;
    protected AudioSource audioSource;

    // controller
    protected SoundController soundController;

    // stats
    protected float attackDamage;
    protected float health;

    protected void Awake() {
        // model
        currentGun = GetComponentsInChildren<Transform>()[1].gameObject;

        // script
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
        playerLook = GetComponent<PlayerLook>();
        playerSound = GetComponent<PlayerSound>();
        playerShoot = GetComponent<PlayerShoot>();
        playerStats = GetComponent<PlayerStats>();

        // component
        rb = GetComponent<Rigidbody>();
        animator = currentGun.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // controller
        soundController = GameObject.FindWithTag("SoundController").GetComponent<SoundController>();
    }
}
