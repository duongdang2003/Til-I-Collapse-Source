using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossFade : MonoBehaviour
{
    private Animator animator;
    public enum Mode {
        NextScene,
        MainMenu
    }
    public static CrossFade Instance;
    public static Mode mode;
    public CrossFade(){
        mode = Mode.NextScene;
        Instance = this;
    }
    private void Awake() {
        animator = GetComponent<Animator>();
        DontDestroyOnLoad(Instance);
        Debug.Log("awake");
    }
    public void ChangeScene() {
        if (mode == Mode.NextScene) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else if (mode == Mode.MainMenu){
            SceneManager.LoadScene(0);
            mode = Mode.NextScene;
        }
        animator.SetTrigger("FadeIn");
        Time.timeScale = 1;
    }
    public void SetMode(Mode newMode){
        mode = newMode;
    }
    public void FadeOut(){
        animator.ResetTrigger("FadeIn");
        animator.SetTrigger("FadeOut");
    }
}
