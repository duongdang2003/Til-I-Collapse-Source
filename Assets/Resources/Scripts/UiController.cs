using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public GameObject WinMenu;
    public GameObject LoseMenu;
    public static UiController Instance;
    public UiController(){
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    // private void Awake() {
    //     DontDestroyOnLoad(Instance);
    // }
    public IEnumerator ActiveWinMenu(){
        yield return new WaitForSeconds(5f);
        WinMenu.GetComponent<Animator>().SetTrigger("Active");
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject.FindWithTag("Player").GetComponent<PlayerLook>().isDone = true;
    }
    public void ActiveLoseMenu(){
        LoseMenu.GetComponent<Animator>().SetTrigger("Active");
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject.FindWithTag("Player").GetComponent<PlayerLook>().isDone = true;
    }
}
