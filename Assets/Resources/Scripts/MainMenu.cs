using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NextScene(){
        CrossFade.Instance.FadeOut();
    }
    public void Quit(){
        Application.Quit();
    }
    public void BackMainMenu(){
        CrossFade.Instance.SetMode(CrossFade.Mode.MainMenu);
        CrossFade.Instance.FadeOut();
    }
}
