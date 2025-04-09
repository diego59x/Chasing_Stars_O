using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManagement : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene("RacingStars");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Menu");
    }
}
