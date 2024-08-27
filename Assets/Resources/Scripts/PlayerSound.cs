using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : Player
{
    public void InsertMagazine(){
        audioSource.PlayOneShot(soundController.insertMagazine);
    }
    public void RemoveMagazine(){
        audioSource.PlayOneShot(soundController.removeMagazine);
    }
    public void Loaded(){
        audioSource.PlayOneShot(soundController.loaded);
    }
    public void CardChoose(){
        audioSource.PlayOneShot(soundController.cardChoose);
    }
}
