using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    Scene curScene;

    private void Start()
    {
        curScene = SceneManager.GetActiveScene();
    }


    public void RestartScene()
    {
        SceneManager.LoadScene(curScene.buildIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
