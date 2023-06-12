using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ResetGameScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentScene.name);
    }
}