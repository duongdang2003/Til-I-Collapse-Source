using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Player
{
    private float currentXP, currentHealth;
    private Slider healthBar, xpBar;
    private void Start() {
        health = 100;
        attackDamage = 10;
        currentHealth = health;
        currentXP = 0;

        healthBar = GameObject.FindWithTag("HealthBar").GetComponent<Slider>();
        xpBar = GameObject.FindWithTag("XPBar").GetComponent<Slider>();
        UpdateStats();
    }
    public void GainXP(float xp){
        currentXP += xp;
        if(currentXP >= 100){
            currentXP -= 100;
            LevelUp();
        }
        UpdateStats();
    }
    public void UpdateHealth(float delta){
        health += delta;
        UpdateStats();
        if(health <= 0){
            UiController.Instance.ActiveLoseMenu();
        }
    }
    public void UpdateStats(){
        currentHealth = health;
        healthBar.value = currentHealth;
        xpBar.value = currentXP;
    }
    public void LevelUp(){

    }
    public float GetAttackDamage(){
        return attackDamage;
    }
}
